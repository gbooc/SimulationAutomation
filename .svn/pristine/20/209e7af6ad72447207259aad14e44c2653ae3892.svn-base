using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace SimulationAutomation.Views.Reports
{
    public partial class frmPerformanceReport : Form
    {
        public frmPerformanceReport()
        {
            InitializeComponent();
        }

        private void btnViewPerformance_Click(object sender, EventArgs e)
        {
            try
            {
                int yearMonthFrom = int.Parse(this.dtpYearMonthFrom.Value.ToString(Util.GlobalConstants.YEARMONTH));
                int yearMonthTo = int.Parse(this.dtpYearMonthTo.Value.ToString(Util.GlobalConstants.YEARMONTH));

                DataTable dt = new Controllers.Reports.PerformanceReportController().GetPerformanceReport(yearMonthFrom, yearMonthTo);
                this.dgvPerformanceReport.DataSource = dt;
                this.dgvPerformanceReport.Columns["FASP"].Visible = false;
                this.dgvPerformanceReport.Columns["FAPS"].Visible = false;
                this.dgvPerformanceReport.Columns["tat"].HeaderText = "Customer Part Number";
                this.dgvPerformanceReport.Columns["tat"].Width = 85;
                this.dgvPerformanceReport.Columns["tat"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvPerformanceReport.Columns["FAIT"].HeaderText = "Item No.";
                this.dgvPerformanceReport.Columns["FAIT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvPerformanceReport.Columns["FAIT"].Width = 80;

                this.dgvPerformanceReport.Columns["TTL Exported"].Width = 60;
                //this.dgvPerformanceReport.Columns["TTL Exported"].DefaultCellStyle.Format = "#,##0";
                this.dgvPerformanceReport.Columns["TTL Plan"].Width = 70;
                //this.dgvPerformanceReport.Columns["TTL Plan"].DefaultCellStyle.Format = "#,##0";

                this.dgvPerformanceReport.Columns["FASD"].HeaderText = "Suffix";
                this.dgvPerformanceReport.Columns["FASD"].Width = 50;

                string[] notInclude = { "destination", "tat", "Cust_name", "FAIT", "FASD", "FASP", "FAPS", "TTL Exported", "TTL Plan" };

                int shippingResult_Last_Index = 0;

                foreach (DataGridViewColumn col in this.dgvPerformanceReport.Columns)
                {
                    if (!notInclude.Contains(col.Name))
                    {
                        col.Width = 50;
                        col.DefaultCellStyle.Format = "#,##0";
                    }

                    if (col.Name == DateTime.Now.AddMonths(-1).ToString(Util.GlobalConstants.YEARMONTH))
                    {
                        shippingResult_Last_Index = col.Index;
                    }
                }

                foreach (DataGridViewRow row in this.dgvPerformanceReport.Rows)
                {
                    int tTL_Exported = 0;
                    int tTL_Plan = 0;

                    foreach (DataGridViewColumn col in this.dgvPerformanceReport.Columns)
                    {
                        if (!notInclude.Contains(col.Name))
                        {
                            if (int.Parse(col.Name) <= int.Parse(DateTime.Now.AddMonths(-1).ToString(Util.GlobalConstants.YEARMONTH)))
                            {
                                tTL_Exported += (string.IsNullOrEmpty(row.Cells[col.Name].Value.ToString()) ? 0 : int.Parse(row.Cells[col.Name].Value.ToString()));
                            }
                            else
                            {
                                tTL_Plan += (string.IsNullOrEmpty(row.Cells[col.Name].Value.ToString()) ? 0 : int.Parse(row.Cells[col.Name].Value.ToString()));
                            }
                        }
                    }
                    row.Cells["TTL Exported"].Value = tTL_Exported.ToString("#,##0");
                    row.Cells["TTL Plan"].Value = tTL_Plan.ToString("#,##0");
                }

                dt.Rows.Add("", "", "", "", "", "", "", "TTL MONTHLY");

                foreach (DataGridViewColumn col in this.dgvPerformanceReport.Columns)
                {
                    int tTL_Month = 0;
                    if (!notInclude.Contains(col.Name))
                    {
                        foreach (DataGridViewRow row in this.dgvPerformanceReport.Rows)
                        {
                            tTL_Month += string.IsNullOrEmpty(row.Cells[col.Name].Value.ToString()) ? 0 : int.Parse(row.Cells[col.Name].Value.ToString());
                        }
                    }
                    if (tTL_Month != 0)
                    {
                        this.dgvPerformanceReport.Rows[this.dgvPerformanceReport.RowCount - 1].Cells[col.Name].Value = tTL_Month;

                    }
                }

                List<Util.DataGridView_Merge_Column_Header.MultiHeader> headers = new List<Util.DataGridView_Merge_Column_Header.MultiHeader>();

                headers.Add(new Util.DataGridView_Merge_Column_Header.MultiHeader
                {
                    Text = "Shipping Result",
                    FirstColumn = 8,
                    LastColumn = shippingResult_Last_Index,
                    Level = 1,
                    BackColor = Color.SeaShell,
                    ForeColor = Color.Black
                });

                headers.Add(new Util.DataGridView_Merge_Column_Header.MultiHeader
                {
                    Text = "Expected Shipment",
                    FirstColumn = shippingResult_Last_Index + 1,
                    LastColumn = this.dgvPerformanceReport.Columns[this.dgvPerformanceReport.ColumnCount - 1].Index,
                    Level = 1,
                    BackColor = Color.SkyBlue,
                    ForeColor = Color.Black
                });

                Util.DataGridView_Merge_Column_Header.MultiHeaderRenderer multiHeaderRenderer = new Util.DataGridView_Merge_Column_Header.MultiHeaderRenderer(this.dgvPerformanceReport, headers);
                this.dgvPerformanceReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                this.btnExport.Tag = shippingResult_Last_Index;
            }
            catch (Exception ex)
            {
                Util.MessageUtil.ShowError(ex.Message, string.Format(Util.Messages.ERROR_FOUND ,""));
            }
        }

        private void frmPerformanceReport_Load(object sender, EventArgs e)
        {
            this.dtpYearMonthFrom.Value = DateTime.Now.AddMonths(-12);
            this.dtpYearMonthTo.Value = DateTime.Now.AddMonths(12);
        }

        private void dgvPerformanceReport_Paint(object sender, PaintEventArgs e)
        {
            //if (this.dgvPerformanceReport.RowCount > 0)
            //{
            //    Util.CommonUtil.DrawRectangle(4, "Shipping Result", e, this.dgvPerformanceReport, 10);
            //}
        }
        private string CellAddress(Excel._Worksheet worksheet, int row, int col)
        {
            Excel.Range rng = worksheet.Cells[row, col];
            return rng.get_AddressLocal(false, false, Excel.XlReferenceStyle.xlA1);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.btnExport.Tag == null)
                {
                    Util.MessageUtil.ShowWarning("No data found!.", "No Data Found!");
                    return;
                }
                Excel.Application excelApp = null;
                Excel.Workbook workbook = null;
                Excel.Workbooks workbooks = null;

                excelApp = new Excel.Application();
                Excel._Worksheet worksheet = null;
                workbooks = excelApp.Workbooks;
                workbook = workbooks.Add(1);
                worksheet = (Excel.Worksheet)workbook.Sheets[1];
                excelApp.Windows.Application.ActiveWindow.DisplayGridlines = false;
                excelApp.Visible = true;
                worksheet.Name = "Performance Report";
                object misValue = System.Reflection.Missing.Value;

                int colIndex = 2;
                int rowIndex = 2;

                Excel.Range range = excelApp.get_Range(this.CellAddress(worksheet, rowIndex + 1, colIndex), this.CellAddress(worksheet, this.dgvPerformanceReport.RowCount + 2, this.dgvPerformanceReport.ColumnCount - 1));

                range.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlDot;
                range.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlDot;
                range.Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlMedium;
                range.Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlMedium;
                range.Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = Excel.XlBorderWeight.xlMedium;
                range.Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlMedium;

                range = excelApp.get_Range(this.CellAddress(worksheet, rowIndex + 1, colIndex), this.CellAddress(worksheet, this.dgvPerformanceReport.RowCount + 2, int.Parse(this.btnExport.Tag.ToString())));

                range.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlDot;
                range.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlDot;
                range.Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlMedium;
                range.Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlMedium;
                range.Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = Excel.XlBorderWeight.xlMedium;
                range.Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlMedium;


                range = excelApp.get_Range(this.CellAddress(worksheet, rowIndex + 1, colIndex), this.CellAddress(worksheet, this.dgvPerformanceReport.RowCount + 2, 7));
                range.Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = Excel.XlBorderWeight.xlMedium;


                worksheet.Range[worksheet.Cells[rowIndex - 1, 8], worksheet.Cells[rowIndex - 1, int.Parse(this.btnExport.Tag.ToString())]].Merge();
                worksheet.Range[worksheet.Cells[rowIndex - 1, 8], worksheet.Cells[rowIndex - 1, int.Parse(this.btnExport.Tag.ToString())]] = "Shipping Result";
                worksheet.Range[worksheet.Cells[rowIndex - 1, 8], worksheet.Cells[rowIndex - 1, int.Parse(this.btnExport.Tag.ToString())]].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                worksheet.Range[worksheet.Cells[rowIndex - 1, 8], worksheet.Cells[rowIndex - 1, int.Parse(this.btnExport.Tag.ToString())]].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                worksheet.Range[worksheet.Cells[rowIndex - 1, 8], worksheet.Cells[rowIndex - 1, int.Parse(this.btnExport.Tag.ToString())]].Interior.Color = Color.Pink;

                worksheet.Range[worksheet.Cells[rowIndex - 1, int.Parse(this.btnExport.Tag.ToString()) + 1], worksheet.Cells[rowIndex - 1, this.dgvPerformanceReport.ColumnCount - 1]].Merge();
                worksheet.Range[worksheet.Cells[rowIndex - 1, int.Parse(this.btnExport.Tag.ToString()) + 1], worksheet.Cells[rowIndex - 1, this.dgvPerformanceReport.ColumnCount - 1]] = "Expected Shipment";
                worksheet.Range[worksheet.Cells[rowIndex - 1, int.Parse(this.btnExport.Tag.ToString()) + 1], worksheet.Cells[rowIndex - 1, this.dgvPerformanceReport.ColumnCount - 1]].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                worksheet.Range[worksheet.Cells[rowIndex - 1, int.Parse(this.btnExport.Tag.ToString()) + 1], worksheet.Cells[rowIndex - 1, this.dgvPerformanceReport.ColumnCount - 1]].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                worksheet.Range[worksheet.Cells[rowIndex - 1, int.Parse(this.btnExport.Tag.ToString()) + 1], worksheet.Cells[rowIndex - 1, this.dgvPerformanceReport.ColumnCount - 1]].Interior.Color = Color.Green;

                foreach (DataGridViewColumn col in this.dgvPerformanceReport.Columns)
                {
                    if (col.Visible)
                    {
                        int intValue;

                        if (!int.TryParse(col.Name.ToString(), out intValue))
                        {
                            worksheet.Range[worksheet.Cells[rowIndex - 1, colIndex], worksheet.Cells[rowIndex, colIndex]].Merge();
                            worksheet.Range[worksheet.Cells[rowIndex - 1, colIndex], worksheet.Cells[rowIndex, colIndex]] = col.HeaderText.ToUpper();
                            worksheet.Range[worksheet.Cells[rowIndex - 1, colIndex], worksheet.Cells[rowIndex, colIndex]].WrapText = true;
                            worksheet.Range[worksheet.Cells[rowIndex - 1, colIndex], worksheet.Cells[rowIndex, colIndex]].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            worksheet.Range[worksheet.Cells[rowIndex - 1, colIndex], worksheet.Cells[rowIndex, colIndex]].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                            if (col.HeaderText == "Customer Part Number")
                                worksheet.Range[worksheet.Cells[rowIndex - 1, colIndex], worksheet.Cells[rowIndex, colIndex]].ColumnWidth = 14;
                            else if(col.HeaderText == "destination")
                                worksheet.Range[worksheet.Cells[rowIndex - 1, colIndex], worksheet.Cells[rowIndex, colIndex]].ColumnWidth = 12;
                        }
                        else
                        {
                            //worksheet.Range[worksheet.Cells[rowIndex - 1, colIndex], worksheet.Cells[rowIndex, colIndex]] = col.HeaderText;
                            worksheet.Cells[rowIndex, colIndex] = col.HeaderText;
                        }
                        colIndex++;
                    }
                }

                foreach (DataGridViewRow row in this.dgvPerformanceReport.Rows)
                {
                    rowIndex++;
                    colIndex = 2;
                    foreach (DataGridViewColumn col in this.dgvPerformanceReport.Columns)
                    {
                        if (col.Visible)
                        {
                             int intValue;

                             if (int.TryParse(col.Name.ToString(), out intValue))
                             {
                                 worksheet.Cells[rowIndex, colIndex] = row.Cells[col.Index].Value.ToString() == ""? "" : Convert.ToInt32(row.Cells[col.Index].Value.ToString()).ToString("#,##0");
                             }
                             else if (!int.TryParse(col.Name.ToString(), out intValue))
                             {
                                 if (row.Cells[col.Index].Value.ToString() == "TTL MONTHLY")
                                 {
                                     worksheet.Cells[rowIndex, colIndex] = row.Cells[col.Index].Value.ToString();
                                     worksheet.Range[worksheet.Cells[rowIndex, colIndex - 1], worksheet.Cells[rowIndex, colIndex]].Merge();
                                     worksheet.Range[worksheet.Cells[rowIndex, colIndex - 1], worksheet.Cells[rowIndex, colIndex]].HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                                 }
                                 else
                                 {
                                     worksheet.Cells[rowIndex, colIndex] = row.Cells[col.Index].Value.ToString();
                                 }
                                 
                             }
                            colIndex++;
                        }
                    }
                }


                this.releaseObject(worksheet);
                this.releaseObject(workbook);
                this.releaseObject(excelApp);
            }
            catch (Exception ex)
            {

            }
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                System.Windows.Forms.MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (this.dgvPerformanceReport.DataSource != null)
                (this.dgvPerformanceReport.DataSource as DataTable).DefaultView.RowFilter = string.Format("FAIT LIKE '%{0}%' OR tat LIKE '%{0}%'", this.txtSearch.Text.Trim().Replace("%", "").Replace("'", "").Replace("[", ""));
        }
    }
}