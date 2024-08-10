using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulationAutomation.Views.Reports
{
    public partial class frm_CriticalPartsSimulation : Form
    {
        DataTableCollection tableCollection;
        string itemno = string.Empty;
        string stocks = string.Empty;
        string mp6080 = string.Empty;
        string ap8000 = string.Empty;
        string issue = string.Empty;
        string limit = string.Empty;
        public frm_CriticalPartsSimulation()
        {
            InitializeComponent();
        }

        public void getItem()
        {
            var item = new Controllers.Reports.ItemNoController().GetAllModels()._List.ToList();

            foreach (var i in item)
            {
                cbxitem.Items.Add(i.CGITCH);
            }

        }
        private void frm_CriticalPartsSimulation_Load(object sender, EventArgs e)
        {
            getItem();
        }

        private void btnsimulation_Click(object sender, EventArgs e)
        {
            dgvmodeluse.Rows.Clear();
            dgvSimulate.Rows.Clear();
            if (cbxsection.Text == string.Empty)
            {
                MessageBox.Show("Please select section");
                return;
            }
            string etddate = dtpetddate.Value.Date.ToString("M/dd/yyyy");
            int _year = dtpetddate.Value.Year;
            int _month = dtpetddate.Value.Month;
            int _dates = dtpetddate.Value.Day + 7;
            if(_dates != DateTime.Now.Day)
            {
                _dates = DateTime.DaysInMonth(_year, _month) - dtpetddate.Value.Day;
                if(_dates > 7)
                {
                    _dates =_dates  - 7;
                }
                else
                {
                    _dates = 7 - _dates;
                }
                _month = _month + 1;
                
            }
            string etadate = new DateTime(_year, _month, _dates).ToString("M/dd/yyyy");
            int rowIndex = this.dgvSimulate.Rows.Add();
            var row = this.dgvSimulate.Rows[rowIndex];
            if (cbxwpstocks.Checked && !cbxmpstocks.Checked && !cbxapstocks.Checked)
            {
                if (txtMP8068.Text == "")
                {
                    txtMP8068.Text = "0";
                }
                if (txtAP8000.Text == "")
                {
                    txtAP8000.Text = "0";
                }
                int MP = Convert.ToInt32(txtMP8068.Text);
                int AP = Convert.ToInt32(txtAP8000.Text);
                var qry = new Controllers.Reports.ItemStocksController().GetWP8100stocks(cbxitem.Text.Trim())._List.Select(x => x.stocks).Sum();
                row.Cells[6].Value = Convert.ToInt32(qry + MP + AP).ToString();
                stocks = Convert.ToInt32(qry + MP + AP).ToString();
            }
            else if (cbxmpstocks.Checked && !cbxwpstocks.Checked && !cbxapstocks.Checked)
            {
                var qry = new Controllers.Reports.ItemStocksController().GetMP8068stocks(cbxitem.Text.Trim())._List.Select(x => x.stocks).Sum();
                row.Cells[6].Value = qry;
            }
            else if (cbxapstocks.Checked && !cbxwpstocks.Checked && !cbxmpstocks.Checked)
            {
                var qry = new Controllers.Reports.ItemStocksController().GetAP8000stocks(cbxitem.Text.Trim())._List.Select(x => x.stocks).Sum();
                row.Cells[6].Value = qry;
            }
            else if (cbxwpstocks.Checked && cbxmpstocks.Checked && !cbxapstocks.Checked)
            {
                var qry = new Controllers.Reports.ItemStocksController().GetWPMPstocks(cbxitem.Text.Trim())._List.Select(x => x.stocks).Sum();
                row.Cells[6].Value = qry;
            }
            else if (cbxwpstocks.Checked && !cbxmpstocks.Checked && cbxapstocks.Checked)
            {
                var qry = new Controllers.Reports.ItemStocksController().GetWPAPstocks(cbxitem.Text.Trim())._List.Select(x => x.stocks).Sum();
                row.Cells[6].Value = qry;
            }
            else if (cbxwpstocks.Checked && cbxmpstocks.Checked && cbxapstocks.Checked)
            {
                var qry = new Controllers.Reports.ItemStocksController().GetALLstocks(cbxitem.Text.Trim())._List.Select(x => x.stocks).Sum();
                row.Cells[6].Value = qry;
            }
            var rdd = new Controllers.Reports.DeliveryDateController().getlist("PP")._List.ToList();
            var modeluse = new Controllers.Reports.ItemNoController().getParentList(cbxitem.Text.Trim())._List.ToList();

            int StartMonths = DateTime.Now.Month;
            int StartDates = DateTime.Now.Day;
            int StartYears = DateTime.Now.Year;

            int EndDates = 0;
            int EndMonths = 0;
            int EndYears = 0;
           
             
           int month  = Convert.ToInt32(DateTime.Now.Month + 6);
            if(month > 12)
            {
                EndYears = Convert.ToInt32(DateTime.Now.Year + 1);
                EndDates = DateTime.DaysInMonth(EndYears, Convert.ToInt32(DateTime.Now.Month + 6));
                EndMonths = Convert.ToInt32(DateTime.Now.Month + 6);
                 //EndDate = new DateTime(DateTime.Now.Year, Convert.ToInt32(DateTime.Now.Month + 6), DateTime.DaysInMonth(DateTime.Now.Year, Convert.ToInt32(DateTime.Now.Month + 6))).ToString("yyyy/M/dd");
            }
            else
            {
                EndYears = Convert.ToInt32(DateTime.Now.Year);
                EndDates = DateTime.DaysInMonth(EndYears, Convert.ToInt32(DateTime.Now.Month + 6));
                EndMonths = Convert.ToInt32(DateTime.Now.Month + 6);
                //string EndDates = new DateTime(DateTime.Now.Year, Convert.ToInt32(DateTime.Now.Month + 6), DateTime.DaysInMonth(DateTime.Now.Year, Convert.ToInt32(DateTime.Now.Month + 6))).ToString("yyyy/M/dd");
            }
            DateTime StartDate = new DateTime(StartYears, StartMonths, StartDates);
            DateTime EndDate = new DateTime(EndYears, EndMonths, EndDates);
           
            for (var dt = StartDate; dt <= EndDate; dt = dt.AddDays(1))
            {
                int rowIndexs = this.dgvSimulate.Rows.Add();
                var rows = this.dgvSimulate.Rows[rowIndexs];
                rows.Cells[1].Value = dt.Date.ToString("M/dd/yyyy");
                rows.Cells[5].Value = "0";
                if (etddate == dt.Date.ToString("M/dd/yyyy"))
                {
                    rows.Cells[3].Value = txtedtamount.Text;
                }
                else if (etadate == dt.Date.ToString("M/dd/yyyy"))
                {
                    rows.Cells[4].Value = txtedtamount.Text;
                }
            }
            foreach (var r in rdd)
            {
                if(r.itemnumber.Trim() == cbxitem.Text.Trim())
                {
                    for (int index = 1; index < dgvSimulate.Rows.Count; index++)
                    {
                        DateTime date = Convert.ToDateTime(dgvSimulate.Rows[index].Cells["cdate"].Value == null ? "" : dgvSimulate.Rows[index].Cells["cdate"].Value.ToString().Trim());
                        long d = long.Parse(date.ToString("yyyyMMdd"));
                        string dates = r.date.ToString();
                        if (dates == d.ToString().Trim())
                        {
                            dgvSimulate.Rows[index].Cells[2].Value = r.quantity.ToString();
                        }
                    }
                }
               
            }

            if (cbxsection.Text == "Electrical")
            {

                var submodeluse = new Controllers.Reports.ItemNoController().getParentLists(cbxitem.Text.Trim())._List.ToList();
                var inputdata = new Controllers.Reports.ItemNoController().getSimulationElectrical(cbxitem.Text.Trim())._List.ToList();
                dgvmodeluse.Columns[3].Visible = true;
                dgvmodeluse.Columns[4].Visible = true;
                dgvmodeluse.Columns[5].Visible = true;
                foreach (var i in modeluse)
                {
                    int rowIndexs = this.dgvmodeluse.Rows.Add();
                    var rows = this.dgvmodeluse.Rows[rowIndexs];
                    rows.Cells[0].Value = i.item;
                    rows.Cells[1].Value = i.suffix;
                    rows.Cells[2].Value = i.quantity;
                    rows.Cells["cparentqtys"].Value = i.quantity;

                    foreach (var s in submodeluse)
                    {
                        if (s.subparent.Trim() == i.item.Trim())
                        {
                            int subrowIndex = this.dgvmodeluse.Rows.Add();
                            var subrows = this.dgvmodeluse.Rows[subrowIndex];
                            subrows.Cells["cparentqtys"].Value = i.quantity;
                            subrows.Cells[3].Value = s.item;
                            subrows.Cells[4].Value = s.suffix;
                            subrows.Cells[5].Value = s.quantity;
                        }
                    }

                }

                foreach (var i in inputdata)
                {
                    for (int index = 0; index < dgvSimulate.Rows.Count; index++)
                    {
                        string date = dgvSimulate.Rows[index].Cells["cdate"].Value == null ? "" : dgvSimulate.Rows[index].Cells["cdate"].Value.ToString().Trim();
                        string dates = Convert.ToDateTime(i.date.ToString()).ToString("M/dd/yyyy").Trim();
                        if (dates == date.Trim())
                        {
                            for (int modeluses = 0; modeluses < dgvmodeluse.Rows.Count; modeluses++)
                            {
                                string model = dgvmodeluse.Rows[modeluses].Cells["cparentmodel"].Value == null ? "" : dgvmodeluse.Rows[modeluses].Cells["cparentmodel"].Value.ToString().Trim();
                                int qty = Convert.ToInt32(dgvmodeluse.Rows[modeluses].Cells["cparentqtys"].Value);
                                if (i.itemno.Trim() == model)
                                {

                                    int sum = Convert.ToInt32(i.inputquantity);
                                    dgvSimulate.Rows[index].Cells[5].Value = Convert.ToInt32(Convert.ToInt32(i.inputquantity) * qty).ToString();
                                }

                            }

                        }
                    }

                }
            }
            else
            {
                dgvmodeluse.Columns[3].Visible = false;
                dgvmodeluse.Columns[4].Visible = false;
                dgvmodeluse.Columns[5].Visible = false;
                foreach (var i in modeluse)
                {
                    int rowIndexs = this.dgvmodeluse.Rows.Add();
                    var rows = this.dgvmodeluse.Rows[rowIndexs];
                    rows.Cells[0].Value = i.item;
                    rows.Cells[1].Value = i.suffix;
                    rows.Cells[2].Value = i.quantity;
                }
                var inputdata = new Controllers.Reports.ItemNoController().getSimulation(cbxitem.Text.Trim())._List.ToList();
                foreach (var i in inputdata)
                {
                    for (int index = 0; index < dgvSimulate.Rows.Count; index++)
                    {
                        string date = dgvSimulate.Rows[index].Cells["cdate"].Value == null ? "" : dgvSimulate.Rows[index].Cells["cdate"].Value.ToString().Trim();
                        string dates = Convert.ToDateTime(i.date.ToString()).ToString("M/dd/yyyy").Trim();
                        if (dates == date.Trim())
                        {
                            for (int modeluses = 0; modeluses < dgvmodeluse.Rows.Count; modeluses++)
                            {
                                string model = dgvmodeluse.Rows[modeluses].Cells["cmodel"].Value == null ? "" : dgvmodeluse.Rows[modeluses].Cells["cmodel"].Value.ToString().Trim();
                                int qty = Convert.ToInt32(dgvmodeluse.Rows[modeluses].Cells["cqty"].Value);
                                if (i.itemno.Trim() == model)
                                {
                                    dgvSimulate.Rows[index].Cells[5].Value = Convert.ToInt32(Convert.ToInt32(i.inputquantity) * qty).ToString();
                                }

                            }

                        }
                    }

                }

            }
 
            for (int i = 0; i < dgvSimulate.Rows.Count - 1; i++)
            {

                int stocks = Convert.ToInt32(dgvSimulate.Rows[i].Cells[6].Value);
                int quantity = Convert.ToInt32(dgvSimulate.Rows[i + 1].Cells[5].Value);
                int eta = 0;
                string ETArows = dgvSimulate.Rows[i + 1].Cells[4].Value == null ? "" : dgvSimulate.Rows[i + 1].Cells[4].Value.ToString();
                if (ETArows != "")
                {
                    eta = Convert.ToInt32(dgvSimulate.Rows[i + 1].Cells[4].Value);
                }

                int inputquantity = Convert.ToInt32(stocks + eta) - quantity;
                dgvSimulate.Rows[i + 1].Cells[6].Value = inputquantity;
                if (inputquantity < 0)
                {
                    dgvSimulate.Rows[i + 1].Cells[6].Style.BackColor = Color.Red;
                }
            }
            for (int i = 0; i < dgvSimulate.Rows.Count - 1; i++)
            {
                if (dgvSimulate.Rows[i + 1].Cells[6].Style.BackColor == Color.Red)
                {
                    dtpstockslimits.Text = dgvSimulate.Rows[i + 1].Cells[1].Value.ToString();
                    break;
                }
            }

        }

        private void btnAddEtd_Click(object sender, EventArgs e)
        {
        }

        private void btnexport_Click(object sender, EventArgs e)
        {
            if(dgvSimulate.RowCount != 0)
            {
                itemno = cbxitem.Text.Trim();
                mp6080 = txtMP8068.Text.Trim();
                ap8000 = txtAP8000.Text.Trim();
                issue = richTextBox1.Text.Trim();
                limit = dtpstockslimits.Text;
                lblready.Text = "Please wait..";
                backgroundWorker1.RunWorkerAsync(); 
            }
           
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            
            var excel = new Microsoft.Office.Interop.Excel.Application();
            excel.SheetsInNewWorkbook = 1;

            var workbook = excel.Workbooks.Add(Type.Missing);

            var sheet = workbook.Worksheets[1];
            sheet.name = "SUMMARY";
            excel.Windows.Application.ActiveWindow.DisplayGridlines = false;
            excel.Windows.Application.ActiveWindow.Zoom = 85;
            sheet.Columns[1].ColumnWidth = 1;
            sheet.Columns[2].ColumnWidth = 10;
            sheet.Columns[3].ColumnWidth = 10;
            sheet.Columns[4].ColumnWidth = 10;
            sheet.Columns[5].ColumnWidth = 10;
            sheet.Columns[6].ColumnWidth = 20;
            sheet.Columns[9].ColumnWidth = 30;
            sheet.Columns[11].ColumnWidth = 12;
            sheet.Columns[12].ColumnWidth = 4;
            sheet.Columns[13].ColumnWidth = 5;
            sheet.Columns[14].ColumnWidth = 15;
            sheet.Columns[15].ColumnWidth = 15;
            sheet.Columns[16].ColumnWidth = 15;
          


            sheet.Cells[2, 2].Font.Size = 16;
            sheet.Cells[2, 2].Font.Bold = true;
            sheet.Cells[2, 2].Value2 = "CRITICAL PARTS SIMULATION:";
            sheet.Cells[3, 2].Font.Size = 12;
            sheet.Cells[3, 2].Font.Bold = true;
            sheet.Cells[3, 2].Value2 = "Item no:";
            sheet.Cells[4, 2].Font.Size = 12;
            sheet.Cells[4, 2].Font.Bold = true;
            sheet.Cells[3, 6].Value2 = itemno;
            sheet.Cells[4, 6].Font.Size = 12;
            sheet.Cells[4, 6].Font.Bold = true;
            sheet.Cells[4, 2].Value2 = "Consideration";
            sheet.Cells[5, 2].Font.Size = 12;
            sheet.Cells[5, 2].Font.Bold = true;
            sheet.Cells[5, 2].Value2 = "Single Stocks";
            sheet.Cells[5, 4].Font.Size = 12;
            sheet.Cells[5, 4].Value2 = "WP8100 / WP9084";
            sheet.Cells[5, 6].Font.Size = 12;
            sheet.Cells[5, 6].Value2 = stocks;
            sheet.Cells[6, 4].Font.Size = 12;
            sheet.Cells[6, 4].Value2 = "MP8068 / MP9068";
            sheet.Cells[6, 6].Font.Size = 12;
            sheet.Cells[6, 6].Value2 = mp6080;
            sheet.Cells[7, 4].Font.Size = 12;
            sheet.Cells[7, 4].Value2 = "AP8000 / MP9078";
            sheet.Cells[7, 6].Font.Size = 12;
            sheet.Cells[7, 6].Value2 = ap8000;

            sheet.Cells[3, 9].Value2 = "Background of the Issue";
            sheet.Cells[3, 9].Font.Size = 12;
            sheet.Cells[3, 9].Font.Bold = true;
            sheet.Cells[3, 10].Value2 = issue;
            sheet.Cells[3, 10].Font.Size = 12;


            sheet.Cells[2, 13].Value2 = "Date:";
            sheet.Cells[2, 13].Font.Size = 12;
            sheet.Cells[2, 13].Font.Bold = true;
            sheet.Cells[2, 14].Value2 = DateTime.Now.ToString("M/dd/yyyy");
            sheet.Cells[2, 14].Font.Size = 12;

            sheet.Cells[4, 9].Value2 = "Stock Limit Date";
            sheet.Cells[4, 9].Font.Size = 12;
            sheet.Cells[4, 9].Font.Bold = true;
            sheet.Cells[4, 10].Value2 = limit;
            sheet.Cells[4, 10].Font.Size = 12;


            for (int i = 1; i < dgvSimulate.Columns.Count; i++)
            {
                sheet.Cells[11, i + 1] = dgvSimulate.Columns[i].HeaderText;
                sheet.Cells[11, i + 1].Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                sheet.Cells[11, i + 1].Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;
                sheet.Cells[11, i + 1].Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                sheet.Cells[11, i + 1].Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;
                sheet.Cells[11, i + 1].Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                sheet.Cells[11, i + 1].Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;
                sheet.Cells[11, i + 1].Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                sheet.Cells[11, i + 1].Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;
            }
            //storing Each row and column value to excel sheet  
            for (int i = 0; i < dgvSimulate.Rows.Count; i++)
            {

                for (int j = 0; j < dgvSimulate.Columns.Count ; j++)
                {

                    sheet.Cells[i + 12, j + 1] = dgvSimulate.Rows[i].Cells[j].Value == null ? "" : dgvSimulate.Rows[i].Cells[j].Value.ToString();
                    string a = dgvSimulate.Rows[i].Cells[j].Value == null ? "" : dgvSimulate.Rows[i].Cells[j].Value.ToString();
                    if (a.StartsWith("-"))
                    {
                       

                        sheet.Cells[i + 12, j + 1].NumberFormat = "#,##0;[Red]▲#,##0";
                        //sheet.Cells[i + 12, j + 1].EntireColumn.NumberFormat = "[Yellow][<0](General);General_)";
                        //sheet.Cells[i + 12, j + 1].NumberFormat = "#.00;[Red]#.00;0.00;\"product: \"@";
                        //sheet.Cells[i + 12, j + 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                    }
                   
                }
                Microsoft.Office.Interop.Excel.Range HRange = excel.get_Range("B12", "G" + Convert.ToInt32(i + 12));
                HRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                HRange.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;

            }

            for (int i = 0; i < dgvSimulate.Rows.Count - 1; i++)
            {

                for (int j = 0; j < dgvSimulate.Columns.Count; j++)
                {
                    sheet.Cells[i + 13, 7] = "=SUM(G" + Convert.ToInt32(i + 12) + "+E" + Convert.ToInt32(i + 13) + "-F" + Convert.ToInt32(i + 13) + ")";
                   
                }

            }

            for (int i = 0; i < dgvmodeluse.Columns.Count - 1 ; i++)
            {
                sheet.Cells[11, i + 11] = dgvmodeluse.Columns[i].HeaderText;
                sheet.Cells[11, i + 11].Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                sheet.Cells[11, i + 11].Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;
                sheet.Cells[11, i + 11].Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                sheet.Cells[11, i + 11].Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;
                sheet.Cells[11, i + 11].Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                sheet.Cells[11, i + 11].Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;
                sheet.Cells[11, i + 11].Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                sheet.Cells[11, i + 11].Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;
            }

            for (int i = 0; i < dgvmodeluse.Rows.Count; i++)
            {

                for (int j = 0; j < dgvmodeluse.Columns.Count - 1; j++)
                {

                    sheet.Cells[i + 12, j + 11] = dgvmodeluse.Rows[i].Cells[j].Value == null ? "" : dgvmodeluse.Rows[i].Cells[j].Value.ToString();
                   
                }
                Microsoft.Office.Interop.Excel.Range HRange2 = excel.get_Range("K12", "P" + Convert.ToInt32(i + 12));
                HRange2.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                HRange2.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;

            }
           

            workbook.SaveAs("C:\\CriticalParts\\CriticalParts.xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            workbook.Close(1);
            excel.Quit();
        }

        private void frm_CriticalPartsSimulation_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.backgroundWorker1.IsBusy)
            {
                Util.MessageUtil.ShowWarning("The simulation is running \n please wait until finished.", string.Format(Util.Messages.ERROR_FOUND, ""));
                e.Cancel = true;
            }

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblready.Text = "Finished";
            MessageBox.Show("Exported Successfully");
        }

        private void btnImport_Click(object sender, EventArgs e)
        {

            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel 97-2007 Workbook|*.xls|Excel Workbook|*xlsx" })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        tstxtfilename.Text = ofd.FileName;
                        using (var stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read))
                        {
                            using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                            {
                                DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                                {
                                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                                });

                                tableCollection = result.Tables;
                                tscbsheet.Items.Clear();

                                foreach (DataTable table in tableCollection)
                                    tscbsheet.Items.Add(table.TableName);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please close the excel file first");
                tstxtfilename.Text = string.Empty;
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {

        }
    }
}
