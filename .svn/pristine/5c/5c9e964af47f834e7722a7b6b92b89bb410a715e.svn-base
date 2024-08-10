using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace SimulationAutomation.Util
{
    public class FileUtil
    {
        private static string FILE_EXT_XLSX = "xlsx";
        private static string FILE_EXT_XLS = "xls";
        private static string FILE_EXT_CSV = "csv";
        private static string FILENAME = "";

        /// <summary>
        /// Export data from datagrid to a file.
        /// </summary>
        /// <param name="dgv"></param>
        public static void ExportToFile(DataGridView dgv)
        {
            // if data grid is not empty,
            // export the data to file
            if (0 < dgv.Rows.Count)
            {
                //Prepare the file for export.
                SaveFileDialog saveFile = new SaveFileDialog();
                // allowed extension filenames: XLS, CSV, TXT
                saveFile.Filter = GlobalConstants.FILE_EXTENSION_EXCEL + "|"
                    + GlobalConstants.FILE_EXTENSION_EXCEL_2003 + "|"
                    + GlobalConstants.FILE_EXTENSION_CSV + "|"
                    + GlobalConstants.FILE_EXTENSION_TEXT;
                var result = saveFile.ShowDialog();

                if (DialogResult.OK != result)
                {
                    return;
                }

                bool isSuccess = true;
                string fileName = saveFile.FileName;

                // if file extension is XLS
                // write to Excel file
                if (fileName.EndsWith(FILE_EXT_XLS)
                    || fileName.EndsWith(FILE_EXT_XLSX))
                {
                    isSuccess = WriteExcelFile(dgv, fileName);
                }
                // if file extension is CSV
                // write as CSV file
                else if (fileName.EndsWith(FILE_EXT_CSV))
                {
                    isSuccess = WriteTextFile(dgv, fileName, separator: ",");
                }
                // otherwise, write to text file
                else
                {
                    isSuccess = WriteTextFile(dgv, fileName);
                }

                // if write to file is successful,
                // display success message
                if (isSuccess)
                {
                    MessageBox.Show(string.Format(Messages.DATA_EXPORTED, fileName),
                        Messages.SUCCESS_TITLE,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            // if data grid is empty,
            // display no data message
            else
            {
                MessageBox.Show(Messages.NO_EXPORT_DATA,
                    Messages.WARNING_TITLE,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Gets the value of the given cell
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        private static string GetValue(DataGridViewCell cell)
        {
            string value;
            bool output;
            // try to parse the formatted value of the cell to boolean
            // if value is a valid boolean,
            // get the parsed boolean and convert to string
            if (bool.TryParse(cell.FormattedValue.ToString(), out output))
            {
                value = output.ToString().ToUpper();
            }
            // otherwise, get the value of the cell
            else
            {
                value = cell.Value == null
                    ? string.Empty
                    : cell.Value.ToString();
            }
            return value;
        }

        /// <summary>
        /// Writes data grid to Excel file
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool WriteExcelFile(DataGridView dgv, string fileName)
        {
            bool result = true;
            // create new excel
            var excelApp = new Excel.Application();
            if (null == excelApp)
            {
                MessageBox.Show("Microsoft Excel is not installed in this computer.\n"
                    + "Please install Microsoft Excel first to be able to export data to Excel file.",
                    Messages.ERROR_TITLE,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            excelApp.Visible = false;
            excelApp.DisplayAlerts = false;
            Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);

            try
            {
                // get the active worksheet
                Excel.Worksheet worksheet = workbook.ActiveSheet;
                // index of Excel cell starts with 1
                int rowIndex = 1;
                int colIndex = 1;
                // get the column count of the datagrid
                int columnCount = dgv.Columns.Count;

                // loop through the headers
                for (int i = 0; i < columnCount; i++)
                {
                    // get the header text of each column
                    worksheet.Cells[rowIndex, colIndex] = dgv.Columns[i].HeaderText;
                    colIndex++;
                }

                // next row is 2
                // set column index back to 1 for the next row
                rowIndex = 2;
                colIndex = 1;

                // loop through each row of datagrid
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    // loop through each cell of the current row
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        worksheet.Cells[rowIndex, colIndex] = GetValue(cell);
                        colIndex++;
                    }
                    // set the column index back to 1 for the next row
                    colIndex = 1;
                    rowIndex++;
                }

                // save the workbook
                workbook.SaveAs(fileName);
            }
            catch (Exception ex)
            {
                result = false;
                // display exception message
                MessageBox.Show(ex.Message,
                    Messages.ERROR_TITLE,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                excelApp.Quit();
                workbook = null;
                excelApp = null;
            }
            return result;
        }

        /// <summary>
        /// Writes data grid to TXT file
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool WriteTextFile(DataGridView dgv, string fileName, string separator = "\t")
        {
            StringBuilder sb = new StringBuilder();
            int columnCount = dgv.Columns.Count;

            try
            {
                // append the header titles
                List<string> headerTitles = new List<string>();
                for (int i = 0; i < columnCount; i++)
                {
                    headerTitles.Add(dgv.Columns[i].HeaderText);
                }
                sb.AppendLine(string.Join(separator, headerTitles.ToArray()));

                // append the data
                List<string> columns;
                // loop through each row
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    // instantiate columns for the current row
                    columns = new List<string>();
                    // get the value of each cell of the row
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        columns.Add(GetValue(cell));
                    }
                    // join the columns separated by tab
                    sb.AppendLine(string.Join(separator, columns.ToArray()));
                }
                // write the string to a text file
                System.IO.File.WriteAllText(fileName, sb.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    Messages.ERROR_TITLE,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Import data from file.
        /// </summary>
        /// <returns></returns>
        public static string ImportFromFile()
        {
            //Select file to import.
            OpenFileDialog importFile = new OpenFileDialog();
            importFile.Filter = GlobalConstants.FILE_EXTENSION_EXCEL + "|"
                + GlobalConstants.FILE_EXTENSION_EXCEL_2003 + "|"
                + GlobalConstants.FILE_EXTENSION_CSV + "|"
                + GlobalConstants.FILE_EXTENSION_TEXT;

            DialogResult dialogResult = importFile.ShowDialog();
            if (DialogResult.OK == dialogResult)
            {
                try
                {
                    string fileName = importFile.FileName;
                    string content;
                    // if file extension is XLS,
                    // read as Excel file
                    if (fileName.EndsWith(FILE_EXT_XLS)
                        || fileName.EndsWith(FILE_EXT_XLSX))
                    {
                        bool isSuccess = ReadExcelFile(fileName, out content);
                        if (!isSuccess)
                        {
                            return null;
                        }
                    }
                    // if file extension is CSV,
                    // read the file in text
                    // split the CSV data and join them with tab
                    else if (fileName.EndsWith(FILE_EXT_CSV))
                    {
                        content = System.IO.File.ReadAllText(fileName);
                        content = string.Join("\t", content.Split(','));
                    }
                    // otherwise, read as text file
                    else
                    {
                        content = System.IO.File.ReadAllText(fileName);
                    }

                    // if content is empty, display warning message
                    if (string.Empty.Equals(content.Trim()))
                    {
                        MessageBox.Show("Invalid Data Format.\n please check your data",//Messages.NO_DATA_IMPORTED,
                            Messages.WARNING_TITLE,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button1);
                        return null;
                    }
                    else
                    {
                        return content;
                    }
                }
                catch (Exception ex)
                {
                    // display exception message
                    MessageBox.Show(ex.Message,
                        Messages.ERROR_TITLE,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1);
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Reads excel file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool ReadExcelFile(string fileName, out string content)
        {
            bool result = true;

            Excel.Application excelApp = new Excel.Application();
            if (null == excelApp)
            {
                content = "";
                MessageBox.Show("Microsoft Excel is not installed in this computer.\n"
                    + "Please install Microsoft Excel first to be able to import data from Excel file.",
                    Messages.ERROR_TITLE,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            excelApp.Visible = false;
            excelApp.DisplayAlerts = false;
            Excel.Workbook workbook;

            List<string> data;
            StringBuilder sb = new StringBuilder();

            try
            {
                // open Excel file
                workbook = excelApp.Workbooks.Open(fileName);
                // get the used range of the active worksheet
                Excel.Range range = workbook.ActiveSheet.UsedRange;

                // get the count of rows and columns of the used range
                int rowCount = range.Rows.Count;
                int columnCount = range.Columns.Count;

                // loop through each row of Excel
                for (int row = 1; row <= rowCount; row++)
                {
                    data = new List<string>();
                    // loop through each column of Excel
                    for (int col = 1; col <= columnCount; col++)
                    {
                        // get the value of the current cell
                        // and convert to string
                        data.Add(Convert.ToString((range.Cells[row, col] as Excel.Range).Value2));
                    }
                    // join the data into one string separated by tab
                    sb.AppendLine(string.Join("\t", data.ToArray()));
                }
            }
            catch (Exception ex)
            {
                result = false;
                // show exception message
                MessageBox.Show(ex.Message,
                    Messages.ERROR_TITLE,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }
            finally
            {
                excelApp.Quit();
                workbook = null;
                excelApp = null;
            }

            content = sb.ToString();
            return result;
        }

        public static List<string> GetExcelSheets(out string PathFileName)
        {
            List<string> ListOfSheets = new List<string>();
            string ReturFileName = "";

            //Select file to import.
            OpenFileDialog importFile = new OpenFileDialog();
            importFile.Filter = GlobalConstants.FILE_EXTENSION_EXCEL + "|"
                + GlobalConstants.FILE_EXTENSION_EXCEL_2003 + "|"
                + GlobalConstants.FILE_EXTENSION_CSV + "|"
                + GlobalConstants.FILE_EXTENSION_TEXT;

            DialogResult dialogResult = importFile.ShowDialog();
            if (DialogResult.OK == dialogResult)
            {
                try
                {
                    string fileName = importFile.FileName;

                    Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel.Workbook excelBook = xlApp.Workbooks.Open(fileName);

                    ReturFileName = xlApp.ActiveWorkbook.Name;

                    String[] excelSheets = new String[excelBook.Worksheets.Count];
                    int i = 0;
                    foreach (Microsoft.Office.Interop.Excel.Worksheet wSheet in excelBook.Worksheets)
                    {
                        if (!wSheet.Name.ToLower().Contains("sched") && i < excelBook.Worksheets.Count)
                        {
                            excelSheets[i] = wSheet.Name;
                            ListOfSheets.Add(i.ToString());
                        }
                            i++;
                    }
                    SetFilePath(fileName);

                    excelBook.Close();
                    xlApp.Quit();
                }
                catch (Exception ex)
                {
                    ListOfSheets = null;

                    // show exception message
                    MessageBox.Show(ex.Message,
                        Messages.ERROR_TITLE,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1);
                }
            }

            PathFileName = ReturFileName;
            return ListOfSheets;
        }

        public static string GetSheetContent(string FileName, int ExcelSheet)
        {
            try
            {
                var fileName = FileName;
                string content;

                // if file extension is XLS,
                // read as Excel file
                if (fileName.EndsWith(FILE_EXT_XLS)
                    || fileName.EndsWith(FILE_EXT_XLSX))
                {
                    bool isSuccess = GetSelectedSheet(fileName, out content, (ExcelSheet + 1));
                    if (!isSuccess)
                        return null;
                }
                // if file extension is CSV,
                // read the file in text
                // split the CSV data and join them with tab
                else if (fileName.EndsWith(FILE_EXT_CSV))
                {
                    content = System.IO.File.ReadAllText(fileName);
                    content = string.Join("\t", content.Split(','));
                }
                // otherwise, read as text file
                else
                    content = System.IO.File.ReadAllText(fileName);

                // if content is empty, display warning message
                if (string.Empty.Equals(content.Trim()))
                {
                   return null;
                }
                else
                {
                    return content;
                }
            }
            catch (Exception ex)
            {
                // display exception message
                MessageBox.Show(ex.Message,
                    Messages.ERROR_TITLE,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
                return null;
            }
        }

        public static bool GetSelectedSheet(string fileName, out string content, int ExcelSheet)
        {
            bool result = true;

            Excel.Application excelApp = new Excel.Application();
            if (null == excelApp)
            {
                content = "";
                MessageBox.Show("Microsoft Excel is not installed in this computer.\n"
                    + "Please install Microsoft Excel first to be able to import data from Excel file.",
                    Messages.ERROR_TITLE,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            excelApp.Visible = false;
            excelApp.DisplayAlerts = false;
            Excel.Workbook workbook;

            List<string> data;
            StringBuilder sb = new StringBuilder();

            try
            {
                // open Excel file
                workbook = excelApp.Workbooks.Open(fileName);

                Worksheet sheet = (Worksheet)workbook.Worksheets[ExcelSheet];
                sheet.Activate();

                // get the used range of the active worksheet
                Excel.Range range = workbook.ActiveSheet.UsedRange;
                // get the count of rows and columns of the used range
                int rowCount = range.Rows.Count;
                int columnCount = range.Columns.Count;


                // loop through each row of Excel
                for (int row = 1; row <= rowCount; row++)
                {
                    data = new List<string>();
                    // loop through each column of Excel
                    for (int col = 1; col <= columnCount; col++)
                    {
                        // get the value of the current cell
                        // and convert to string
                        data.Add(Convert.ToString((range.Cells[row, col] as Excel.Range).Value2));
                    }
                    // join the data into one string separated by tab
                    sb.AppendLine(string.Join("\t", data.ToArray()));
                }
            }
            catch (Exception ex)
            {
                result = false;
                // show exception message
                MessageBox.Show(ex.Message,
                    Messages.ERROR_TITLE,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }

            excelApp.Quit();
            workbook = null;
            excelApp = null;

            content = sb.ToString();
            return result;
        }

        public static void OpenExcel(string Path)
        {
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook excelBook = xlApp.Workbooks.Open(Path);

            xlApp.Visible = true;
        }

        public static string SetFilePath(string Filaname)
        {
            FILENAME = Filaname;
            return FILENAME;
        }
        public static string GetFilePath()
        {
            return FILENAME;
        }
    }
}
