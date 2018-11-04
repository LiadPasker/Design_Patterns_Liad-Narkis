using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop;
using Microsoft.Office.Interop.Excel;

namespace Model
{
    public class OfficeManager
    {
        private readonly int r_FirstSheetRow = 1;
        private readonly int r_LastSheetRow = 11;
        private readonly int r_FirstSheetColumn = 1;
        private readonly int r_LastSheetColumn = 8;
        private readonly int r_RowsHeight=60;
        private readonly int r_ColumnWidth = 15;
        public Application excelFile { get; private set; } = null;

        public bool ExportToExcel(System.Data.DataTable i_Data, string i_ExcelFilePath = null)
        {
            bool isSuccessfulExportaion = false;

            try
            {
                if (i_Data == null || i_Data.Columns.Count == 0)
                {
                    throw new Exception("Exporting Failed!");
                }

                excelFile = new Application();
                excelFile.Workbooks.Add();
                _Worksheet workSheet = excelFile.ActiveSheet;
                workSheet.Columns.ColumnWidth = r_ColumnWidth;
                workSheet.Name = i_Data.TableName;
                changeHeadlineColor(workSheet);
                setColumnsHeight(workSheet);
                setSheetBorders(workSheet);
                fillExcelWorksheetWithData(workSheet, i_Data);
                isSuccessfulExportaion = DecideFileVisibilityByFilePathGiven(workSheet, i_ExcelFilePath);
                insertTotalEventsFormula(workSheet);
            }
            catch (Exception e)
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
            i_WorkSheet.get_Range(excelRangeGenerator(r_FirstSheetColumn, r_FirstSheetRow, r_LastSheetColumn,r_LastSheetRow)).Cells.Borders.LineStyle = XlLineStyle.xlContinuous;
        }
        private void setColumnsHeight(_Worksheet i_WorkSheet)
        {
            for (int i = 2; i < r_LastSheetRow; i += 2)
            {
                i_WorkSheet.get_Range(excelRangeGenerator(r_FirstSheetColumn, r_FirstSheetRow+i, r_LastSheetColumn, r_FirstSheetRow + i)).RowHeight = r_RowsHeight;
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
        private bool DecideFileVisibilityByFilePathGiven(Microsoft.Office.Interop.Excel._Worksheet i_CurrentWorkSheet,string i_FilePath)
        {
            bool isSaved = false;

            if (string.IsNullOrEmpty(i_FilePath) == false)
            {
                try
                {
                    i_CurrentWorkSheet.SaveAs(i_FilePath);
                    excelFile.Quit();
                    isSaved = true;
                }
                catch (Exception ex)
                {
                    throw new Exception("Excel file could not be saved! Check filepath\n");
                }
            }
            else
            { // no file path is given
                excelFile.Visible = true;
            }

            return isSaved;
        }
        private void insertTotalEventsFormula(_Worksheet i_Worksheet)
        {
            Range formulaHolder;
            i_Worksheet.Cells[r_FirstSheetRow, r_FirstSheetColumn] = "Total Busy Days:";
            for (int i = 2; i < r_LastSheetRow; i += 2)
            {
                formulaHolder = i_Worksheet.get_Range(excelRangeGenerator(r_FirstSheetColumn, r_FirstSheetRow + i, r_FirstSheetColumn, r_FirstSheetRow + i));
                formulaHolder.Formula = string.Format(@"=COUNTIF({0},""*"")",
                    excelRangeGenerator(r_FirstSheetColumn + 1, r_FirstSheetRow + i, r_LastSheetColumn, r_FirstSheetRow + i));
                formulaHolder.Interior.Color = XlRgbColor.rgbLightGoldenrodYellow;
            }
        }
    }
}
