using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;
using Microsoft.Office.Interop;
using Microsoft.Office.Interop.Excel;

/*
 IMPORTANT NOTICE:
 This class requires 'Microsoft.Office.Interop' reference which is under 'Office Developer Tools For Visual Studio' package.
*/
namespace Model
{
    public class OfficeManager 
    {
        private readonly int r_FirstSheetRow = 1;
        private readonly int r_LastSheetRow = 11;
        private readonly int r_FirstSheetColumn = 1;
        private readonly int r_LastSheetColumn = 8;
        private readonly int r_RowsHeight = 60;
        private readonly int r_ColumnWidth = 15;

        public event Observer.NotiFyer OnLoad;

        public Application ExcelFile { get; private set; } = null;

        public bool ExportToExcel(string i_SheetName, UserManager i_UserManager, string i_ExcelFilePath = null)
        {
            System.Data.DataTable dataTable = initializeCalenderTable(i_SheetName, i_UserManager);
            bool isSuccessfulExportaion = false;

            try
            {
                if (dataTable == null || dataTable.Columns.Count == 0)
                {
                    throw new Exception("Exporting Failed!");
                }

                ExcelFile = new Application();
                ExcelFile.Workbooks.Add();
                _Worksheet workSheet = ExcelFile.ActiveSheet;
                workSheet.Columns.ColumnWidth = r_ColumnWidth;
                workSheet.Name = dataTable.TableName;
                changeHeadlineColor(workSheet);
                setColumnsHeight(workSheet);
                setSheetBorders(workSheet);
                fillExcelWorksheetWithData(workSheet, dataTable);
                isSuccessfulExportaion = DecideFileVisibilityByFilePathGiven(workSheet, i_ExcelFilePath);
                insertTotalEventsFormula(workSheet);
            }
            catch (Exception)
            {
                throw new Exception("Error Occured");
            }

            return isSuccessfulExportaion;
        }

        private void fillExcelWorksheetWithData(_Worksheet i_WorkSheet, System.Data.DataTable i_Data)
        {
            for (int i = 0; i < i_Data.Columns.Count; i++)
            {
                i_WorkSheet.Cells[r_FirstSheetRow, i_Data.Columns.Count - i + 1] = i_Data.Columns[i].ColumnName;
            }

            for (int i = 0; i < i_Data.Rows.Count; i++)
            {
                for (int j = 0; j < i_Data.Columns.Count; j++)
                {
                    i_WorkSheet.Cells[i + 2, i_Data.Columns.Count - j + 1] = i_Data.Rows[i][j];
                }
            }
        }

        private void setSheetBorders(_Worksheet i_WorkSheet)
        {
            i_WorkSheet.get_Range(excelRangeGenerator(r_FirstSheetColumn, r_FirstSheetRow, r_LastSheetColumn, r_LastSheetRow)).Cells.Borders.LineStyle = XlLineStyle.xlContinuous;
        }

        private void setColumnsHeight(_Worksheet i_WorkSheet)
        {
            for (int i = 2; i < r_LastSheetRow; i += 2)
            {
                i_WorkSheet.get_Range(excelRangeGenerator(r_FirstSheetColumn, r_FirstSheetRow + i, r_LastSheetColumn, r_FirstSheetRow + i)).RowHeight = r_RowsHeight;
            }
        }

        private void changeHeadlineColor(_Worksheet i_Worksheet)
        {
            Range heading = i_Worksheet.Range[excelRangeGenerator(r_FirstSheetColumn, r_FirstSheetRow, r_LastSheetColumn, r_FirstSheetRow)];
            heading.Interior.Color = XlRgbColor.rgbRoyalBlue;
            for (int i = 1; i < r_LastSheetRow; i += 2)
            {
                Range MonthDays = i_Worksheet.Range[excelRangeGenerator(r_FirstSheetColumn, r_FirstSheetRow + i, r_LastSheetColumn, r_FirstSheetRow + i)];
                MonthDays.Interior.Color = XlRgbColor.rgbLightSkyBlue;
            }
        }

        private string excelRangeGenerator(int i_ColumnsFrom, int i_RowFrom, int i_ColumnTo, int i_RowTo)
        {
            return string.Format("{0}{1}:{2}{3}", (char)('A' + i_ColumnsFrom - 1), i_RowFrom, (char)('A' + i_ColumnTo - 1), i_RowTo);
        }

        private bool DecideFileVisibilityByFilePathGiven(_Worksheet i_CurrentWorkSheet, string i_FilePath)
        {
            bool isSaved = false;

            if (string.IsNullOrEmpty(i_FilePath) == false)
            {
                try
                {
                    i_CurrentWorkSheet.SaveAs(i_FilePath);
                    ExcelFile.Quit();
                    isSaved = true;
                }
                catch (Exception)
                {
                    throw new Exception("Excel file could not be saved! Check filepath\n");
                }
            }
            else
            { // no file path is given
                ExcelFile.Visible = true;
            }

            OnLoad.Invoke();
            return isSaved;
        }

        private void insertTotalEventsFormula(_Worksheet i_Worksheet)
        {
            Range formulaHolder;
            i_Worksheet.Cells[r_FirstSheetRow, r_FirstSheetColumn] = "Total Busy Days:";
            for (int i = 2; i < r_LastSheetRow; i += 2)
            {
                formulaHolder = i_Worksheet.get_Range(excelRangeGenerator(r_FirstSheetColumn, r_FirstSheetRow + i, r_FirstSheetColumn, r_FirstSheetRow + i));
                formulaHolder.Formula = string.Format(
                    @"=COUNTIF({0},""*"")",
                    excelRangeGenerator(r_FirstSheetColumn + 1, r_FirstSheetRow + i, r_LastSheetColumn, r_FirstSheetRow + i));
                formulaHolder.Interior.Color = XlRgbColor.rgbLightGoldenrodYellow;
            }
        }

        private System.Data.DataTable initializeCalenderTable(string i_TableName, UserManager i_UserManager)
        {
            int numOfDaysInCurrentMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            string[] events;
            string[] birthdays;
            try
            {
                events = getEventsCalendarically(numOfDaysInCurrentMonth);
            }
            catch (Exception)
            {
                events = null;
            }

            try
            {
                birthdays = getBirthdaysCalendarically(numOfDaysInCurrentMonth, i_UserManager);
            }
            catch (Exception)
            {
                birthdays = null;
            }

            return buildDataTable(i_TableName, numOfDaysInCurrentMonth, birthdays, events);
        }

        private System.Data.DataTable buildDataTable(string i_TableName, int numOfDaysInCurrentMonth, string[] birthdays, string[] events)
        {
            System.Data.DataTable userHighLights = new System.Data.DataTable(i_TableName);
            DateTime monthDay = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1); // initializes to the first day of the current month
            DataRow dayRow = userHighLights.NewRow();
            DataRow occasionRow = userHighLights.NewRow();
            string day = monthDay.DayOfWeek.ToString();

            for (int days = (int)DayOfWeek.Sunday; days <= (int)DayOfWeek.Saturday; days++)
            {
                userHighLights.Columns.Add(((DayOfWeek)days).ToString());
            }

            for (int i = 1; i <= numOfDaysInCurrentMonth; i++)
            {
                dayRow[day] = i;
                if (birthdays?[i - 1] != null || events?[i - 1] != null)
                {
                    occasionRow[day] = string.Format("{0}\n{1}", birthdays?[i - 1], events?[i - 1]);
                }

                if (day == DayOfWeek.Saturday.ToString() || i == DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month))
                {
                    userHighLights.Rows.Add(dayRow);
                    userHighLights.Rows.Add(occasionRow);
                    dayRow = userHighLights.NewRow();
                    occasionRow = userHighLights.NewRow();
                }

                monthDay = monthDay.AddDays(1);
                day = monthDay.DayOfWeek.ToString();
            }

            return userHighLights;
        }

        private string[] getBirthdaysCalendarically(int i_numOfDaysInCurrentMonth, UserManager i_UserManager)
        {
            string[] birthdays = new string[i_numOfDaysInCurrentMonth];

            try
            {
                List<User> friends = i_UserManager.GetConnectedUserFriendsSortedByBirthdays(false);
                foreach (User friend in friends)
                {
                    DateTime birthdayDate = DateTime.ParseExact(friend.Birthday, "MM/dd/yyyy", null);
                    if (OccasionHandler.IsOccasionSoon(friend.Birthday, 0, true))
                    {
                        birthdays[birthdayDate.Day - 1] += string.Format("{0} have a Birthday\n", friend.Name);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return birthdays;
        }

        private string[] getEventsCalendarically(int i_numOfDaysInCurrentMonth)
        {
            string[] events = new string[i_numOfDaysInCurrentMonth];

            try
            {
                FacebookObjectCollection<Event> ConnectedUserEvents = FacebookAuthentication.FAuthInstance.LoggedInUser.Events;
                foreach (Event currentEvent in ConnectedUserEvents)
                {
                    DateTime? eventDate = currentEvent.StartTime;
                    if (OccasionHandler.IsOccasionSoon(eventDate.ToString(), 0))
                    {
                        events[eventDate.Value.Day - 1] += string.Format("{0}\n", currentEvent.Name);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return events;
        }
    }
}
