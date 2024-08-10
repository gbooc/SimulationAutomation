using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulationAutomation.Views.Reports
{
    public partial class frm_ComparisonDemand : Form
    {
        DataTable _Months = new DataTable();
        DataTable _Summary = new DataTable();

        public frm_ComparisonDemand(DataTable Months, DataTable TotalData)
        {
            InitializeComponent();

            _Months = Months;
            _Summary = TotalData;

            this.dgvAllMonths.DataSource = TotalData;
            dgvAllMonths.Columns["model_name"].Frozen = true;
        }

        private void btnComparison_Click(object sender, EventArgs e)
        {
            var path = Path.Combine(Path.GetTempPath(), "ComparisonDemand.xlsx");
            var tempfile = new FileInfo(path);
            if (tempfile.Exists)
                tempfile.Delete();

            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            using (var excel = new ExcelPackage(tempfile))
            {
                ExcelWorksheet Sheet = excel.Workbook.Worksheets.Add("Comparison-Demand");
                Sheet.View.ShowGridLines = false;
                Sheet.Column(1).Width = 3;

                //Value
                Sheet.Cells["B3:B3"].Value = "CONSIDERATION:";
                Sheet.Cells["B4:B4"].Value = "LATEST PO ISSUED:";
                Sheet.Cells["B7:B7"].Value = "NEGATIVE";
                Sheet.Cells["B8:B8"].Value = "POSITIVE";
                Sheet.Cells["B9:B9"].Value = "DIFFERENCE BET.:";

                Sheet.Cells["C7:C7"].Value = "PUSH-OUT";
                Sheet.Cells["C8:C8"].Value = "PULL-IN";

                //Bold
                Sheet.Cells["B3:B3"].Style.Font.Bold = true;
                Sheet.Cells["B4:B4"].Style.Font.Bold = true;
                Sheet.Cells["B7:B7"].Style.Font.Bold = true;
                Sheet.Cells["B8:B8"].Style.Font.Bold = true;
                Sheet.Cells["B9:B9"].Style.Font.Bold = true;


                DataTable tbl_summary = new DataTable();

                //All months summary
                foreach (DataColumn column in _Summary.Columns)
                {
                    if (column.ColumnName == "model_name")
                        tbl_summary.Columns.Add(column.ColumnName, typeof(string));
                    else
                        tbl_summary.Columns.Add(column.ColumnName, typeof(int));
                }

                foreach (DataRow row in _Summary.Rows)
                {
                    if (_Months.Rows.Count > 0)
                        tbl_summary.Rows.Add(row.ItemArray);

                }
                //End All Months

                //Selected months details

                DataTable tbl_selecteddates1 = new DataTable();
                DataTable tbl_selecteddates2 = new DataTable();

                int lastrow = tbl_summary.Rows.Count + 15;

                string PrevDate = "";
                string FirstDate = "";
                string SecondDate = "";

                bool IsFirstTable = true;

                foreach (DataColumn column in _Months.Columns)
                {
 
                    if (column.ColumnName != "model_name" && column.ColumnName != "date_uploaded")
                    {
                        tbl_selecteddates1.Columns.Add(column.ColumnName, typeof(int));
                        tbl_selecteddates2.Columns.Add(column.ColumnName, typeof(int));
                    }
                    else
                    {
                        tbl_selecteddates1.Columns.Add(column.ColumnName, typeof(string));
                        tbl_selecteddates2.Columns.Add(column.ColumnName, typeof(string));
                    }
                }


                foreach (DataRow row in _Months.Rows)
                {
                    if (_Months.Rows.Count > 0)
                    {
                        if (PrevDate == "")
                        {
                            tbl_selecteddates1.Rows.Add(row.ItemArray);
                            PrevDate = row["date_uploaded"].ToString();
                        }
                        else
                        {
                            if (PrevDate == row["date_uploaded"].ToString() && IsFirstTable)
                            {
                                tbl_selecteddates1.Rows.Add(row.ItemArray);
                                FirstDate = Convert.ToDateTime(row["date_uploaded"]).ToShortDateString();
                            }
                            else
                            {
                                tbl_selecteddates2.Rows.Add(row.ItemArray);
                                IsFirstTable = false;
                                SecondDate = Convert.ToDateTime(row["date_uploaded"]).ToShortDateString();
                            }
                            PrevDate = row["date_uploaded"].ToString();
                        }
                    }

                }
                //END
                tbl_selecteddates1.Columns.Remove("date_uploaded");
                tbl_selecteddates2.Columns.Remove("date_uploaded");

                Sheet.Cells[11, 2].LoadFromDataTable(tbl_summary, true, OfficeOpenXml.Table.TableStyles.Medium14);

                //first uploaded date
                Sheet.Cells[lastrow - 1, 2].Value = FirstDate;
                Sheet.Cells[lastrow, 2].LoadFromDataTable(tbl_selecteddates1, true, OfficeOpenXml.Table.TableStyles.Light21);

                //Second uploaded date
                Sheet.Cells[lastrow - 1, 17].Value = SecondDate;
                Sheet.Cells[lastrow, 17].LoadFromDataTable(tbl_selecteddates2, true, OfficeOpenXml.Table.TableStyles.Light21);

                int FirstCol = 3;
                int SecondCol = 18;

                for (int i = (lastrow + 1); i <= lastrow + tbl_selecteddates1.Rows.Count; i++)
                {

                    for (int j = 1; j < tbl_selecteddates1.Rows.Count; j++)
                    {

                        try
                        {
                            if (!String.IsNullOrEmpty(Sheet.Cells[i, FirstCol].Value.ToString()) && !String.IsNullOrEmpty(Sheet.Cells[i, SecondCol].Value.ToString()))
                            {
                                if (Convert.ToInt32(Sheet.Cells[i, FirstCol].Value.ToString()) < Convert.ToInt32(Sheet.Cells[i, SecondCol].Value.ToString()))
                                {
                                    using (ExcelRange rng = Sheet.Cells[i, SecondCol])
                                    {
                                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                        rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Green);
                                        rng.Style.Font.Color.SetColor(Color.White);
                                    }

                                }
                                else if (Convert.ToInt32(Sheet.Cells[i, FirstCol].Value.ToString()) > Convert.ToInt32(Sheet.Cells[i, SecondCol].Value.ToString()))
                                {
                                    using (ExcelRange rng = Sheet.Cells[i, FirstCol])
                                    {
                                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                        rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Orange);
                                    }
                                }
                            }
                            FirstCol++;
                            SecondCol++;
                        }
                        catch
                        {


                        }
                    }
                    FirstCol = 3;
                    SecondCol = 18;
                }
                Sheet.Cells["A:AZ"].AutoFitColumns();

                excel.Save();
                //open the file
                Process.Start(tempfile.FullName);
            }
        }

        private void dgvAllMonths_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAllMonths.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgvAllMonths.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvAllMonths.Rows[selectedrowindex];


                var ModelName = selectedRow.Cells[0].Value.ToString();
                var Suffix = selectedRow.Cells[1].Value.ToString();

                var Summary = _Months.AsEnumerable()
                                     .Where(x => x.Field<string>("model_name") == selectedRow.Cells[0].Value.ToString())
                                     .CopyToDataTable();

                this.dgvComparisons.DataSource = Summary;
                dgvComparisons.Columns["date_uploaded"].Frozen = true;
                dgvComparisons.Columns["model_name"].Frozen = true;
            }
        }
    }
}
