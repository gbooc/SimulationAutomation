using OfficeOpenXml;
using OfficeOpenXml.Style;
using SimulationAutomation.Views.Maintenance;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulationAutomation.Views
{
    public partial class FrmCustomerOrder : Form
    {

        #region Form events
        private string customer_partnumber = "";

        public FrmCustomerOrder()
        {
            InitializeComponent();
            this._modelist = new Models.Maintenance.RinksModelList();
            this._POFormat = new Models.Maintenance.POFormatRows();
            this._customerOrderList = new Models.Maintenance.CustomerOrderList();
            this._customerOrderController = new Controllers.Maintenance.CustomerOrderController();
            this._modelController = new Controllers.Maintenance.ModelsController();
            this._toAdd = new List<DataGridViewRow>();
            this.ExcelSheets = new List<string>();
        }

        private Models.Maintenance.RinksModelList _modelist;
        private Models.Maintenance.POFormatRows _POFormat;
        private Models.Maintenance.CustomerOrderList _customerOrderList;
        private Controllers.Maintenance.CustomerOrderController _customerOrderController;
        private Controllers.Maintenance.ModelsController _modelController;

        private bool _isNewUploaded = false;
        private string ExcelPath;

        private List<DataGridViewRow> _toAdd;
        List<string> ExcelSheets = new List<string>();

        private bool isSearch = false;
        int _version = 0;
        int NoGood = 0;
        int Good = 0;
        int FC = 0;
        bool _isImport = false;
        #region form load and constructor


        private void FrmCustomerOrder_Load(object sender, EventArgs e)
        {
            this.dtpMonthUploadedInto.Format = DateTimePickerFormat.Custom;
            this.dtpMonthUploadedInto.CustomFormat = "MMMM yyyy";
            this.dtpMonthUploadedInto.ShowUpDown = true;


            this.cmbDestination.SelectedIndex = 0;
            this.dgvCustomerOrder.AutoResizeColumns();
            this.dgvCustomerOrder.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(this.dgvCustomerOrder, true, null);
            // this.ControlBox = false;

            this.dgvCustomerOrder.DefaultCellStyle.Font = new Font("Tahoma", 8);
            this.dgvUploadSummary.DefaultCellStyle.Font = new Font("Tahoma", 8);

            var POFormat = _customerOrderController.POFormat().ToList();

            Dictionary<string, string> cbItems = new Dictionary<string, string>();
           
            foreach(var items in POFormat)
            {
                cbItems.Add(items.Destination, items.FormatID.ToString());
            }

            this.cbCustomerType.DataSource = new BindingSource(cbItems, null);
            this.cbCustomerType.DisplayMember = "Key";
            this.cbCustomerType.ValueMember = "Value";


            loadUploadedSummary();

            //Load Models and versions
            this._modelist = new Controllers.Maintenance.ModelsController().CheckUploadedModel();
            this.LoadVersion();
        }

        #endregion

        #region btnsearch | btnDelete | btnRefresh | btnImport | btnExport | btnSaveAll

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.LoadVersion();
            this.SearchCustomerOrder();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.btnSearch.PerformClick();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            //Show loader indicator
            string PathFileName = "";

            ExcelSheets = Util.FileUtil.GetExcelSheets(out PathFileName);

            this.txtPath.Text = Util.FileUtil.GetFilePath();
            this.lblFileName.Text = PathFileName;

            DialogResult result = Util.MessageUtil.Confirm(
                     "Get Data Now?",
                     "Excel Successfully Imported.",
                     defaultButton: MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                this.btnGetData.PerformClick();
                this.btnGetData.Enabled = true;
                this._isImport = true;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var path = Path.Combine(Path.GetTempPath(), "CustomerOrder.xlsx");
            var tempfile = new FileInfo(path);
            if (tempfile.Exists)
                tempfile.Delete();

            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (var excel = new ExcelPackage(tempfile))
            {
                ExcelWorksheet Sheet = excel.Workbook.Worksheets.Add("Report");

                Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#e6e6e6");
                Color colValue = System.Drawing.ColorTranslator.FromHtml("#f2f2f2");

                //Header Title

                //Customer Order Label Title
                Sheet.Cells["A1:G1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                Sheet.Cells["A1:G1"].Style.Fill.BackgroundColor.SetColor(colFromHex);
                Sheet.Cells["A1:G1"].Style.Font.Color.SetColor(Color.Black);
                Sheet.Cells["A1:G1"].Style.Font.Size = 15;
                Sheet.Cells["A1:G1"].Style.Font.Bold = true;
                Sheet.Cells["A1:A1"].Value = "Customer Order RT1 Simulator";

                //Destination Date Uploaded
                Sheet.Cells["A2:G3"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                Sheet.Cells["A2:G3"].Style.Fill.BackgroundColor.SetColor(colValue);
                Sheet.Cells["A2:G3"].Style.Font.Color.SetColor(Color.Black);
                Sheet.Cells["A2:G3"].Style.Font.Size = 12;
                Sheet.Cells["A3:A3"].Value = "Date Uploaded:";
                Sheet.Cells["B3:B3"].Value = Convert.ToDateTime(this.dgvUploadSummary.Tag.ToString()).ToString("yyyy-dd-MM"); //this.dtpMonthUploadedInto.Value.Date.ToString("yyyy-dd-MM");

                //Summary
                Sheet.Cells["A4:G4"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                Sheet.Cells["A4:G4"].Style.Fill.BackgroundColor.SetColor(colFromHex);
                Sheet.Cells["A4:G4"].Style.Font.Color.SetColor(Color.Black);
                Sheet.Cells["A4:G4"].Style.Font.Size = 12;
                Sheet.Cells["A4:B4"].Style.Font.Bold = true;
                Sheet.Cells["A4:A4"].Value = "Summary";

                //Summary Details
                Sheet.Cells["A5:G7"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                Sheet.Cells["A5:G7"].Style.Fill.BackgroundColor.SetColor(colValue);
                Sheet.Cells["A5:G7"].Style.Font.Color.SetColor(Color.Black);
                Sheet.Cells["A5:G7"].Style.Font.Size = 12;
                Sheet.Cells["A5:A5"].Value = "Good:";
                Sheet.Cells["B5:B5"].Value = this.txtGoodModel.Text.ToString();
                Sheet.Cells["A6:A6"].Value = "NG:";
                Sheet.Cells["B6:B6"].Value = this.txtNoGoodModel.Text.ToString();
                Sheet.Cells["A7:A7"].Value = "FC:";
                Sheet.Cells["B7:B7"].Value = this.txtFcCount.Text.ToString();

                //Col titles
                Sheet.Cells["A10:G10"].Style.Font.Size = 12;
                Sheet.Cells["A10:G10"].Style.Font.Bold = true;
                Sheet.Cells["A10:A10"].Value = "RINS ITEM #";
                Sheet.Cells["B10:B10"].Value = "Parts #";
                Sheet.Cells["C10:C10"].Value = "RINS PO #";
                Sheet.Cells["D10:D10"].Value = "PO QTY";
                Sheet.Cells["E10:E10"].Value = "ETD";
                Sheet.Cells["F10:F10"].Value = "REMARKS";
                Sheet.Cells["G10:G10"].Value = "Details";

                Sheet.Cells["A10:G10"].Style.Border.Top.Style = ExcelBorderStyle.Medium;
                Sheet.Cells["A10:G10"].Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                Sheet.Cells["A10:G10"].Style.Border.Left.Style = ExcelBorderStyle.Medium;
                Sheet.Cells["A10:G10"].Style.Border.Right.Style = ExcelBorderStyle.Medium;

                //END

                int rows = 11;
                int row_index = 0;
                foreach (DataGridViewRow row in this.dgvCustomerOrder.Rows)
                {
                    try
                    {
                        string Rinks = row.Cells[0].Value.ToString();
                        string PO = row.Cells[1].Value.ToString();
                        string QTY = row.Cells[5].Value.ToString();
                        string ETD = row.Cells[6].Value.ToString();
                        string Remarks = row.Cells[9].Value.ToString();
                        string Parts = row.Cells[2].Value.ToString();
                        string Destination = row.Cells[3].Value.ToString().ToLower().Trim() == "toto shanghai" ? "HK" : "JPN";
                        string Details = "";

                        if (Remarks.Trim().Equals("NG"))
                        {
                            Sheet.Cells[string.Format("F{0}", rows)].Style.Font.Color.SetColor(Color.Red);
                            Sheet.Cells[string.Format("F{0}", rows)].Style.Font.Bold = true;

                            if (!Rinks.Trim().Equals(row.Cells[10].Value.ToString()))
                                Details += "Rins = unmatch " + Environment.NewLine;

                            if (!PO.Trim().Equals(row.Cells[11].Value.ToString()) && !PO.Trim().ToLower().Equals("f/c"))
                                Details += "PO = unmatch " + Environment.NewLine;

                            if (!QTY.Trim().Equals(row.Cells[12].Value.ToString()))
                                Details += "QTY = unmatch " + Environment.NewLine;

                            if (!ETD.Trim().Equals(row.Cells[13].Value.ToString()))
                                Details += "ETD = unmatch " + Environment.NewLine;
                        }

                        Sheet.Cells[string.Format("A{0}:F{0}", rows)].Style.Font.Size = 10;
                        Sheet.Cells[string.Format("G{0}", rows)].Style.WrapText = true;

                        Sheet.Cells[string.Format("A{0}", rows)].Value = Rinks;
                        Sheet.Cells[string.Format("B{0}", rows)].Value = Parts;
                        Sheet.Cells[string.Format("C{0}", rows)].Value = PO;
                        Sheet.Cells[string.Format("D{0}", rows)].Value = Destination;
                        Sheet.Cells[string.Format("E{0}", rows)].Value = Convert.ToInt32(QTY);
                        Sheet.Cells[string.Format("F{0}", rows)].Value = ETD;
                        Sheet.Cells[string.Format("G{0}", rows)].Value = Remarks;
                        Sheet.Cells[string.Format("H{0}", rows)].Value = Details;


                        //Borders
                        Sheet.Cells[string.Format("A{0}", rows)].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        Sheet.Cells[string.Format("B{0}", rows)].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        Sheet.Cells[string.Format("C{0}", rows)].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        Sheet.Cells[string.Format("D{0}", rows)].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        Sheet.Cells[string.Format("E{0}", rows)].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        Sheet.Cells[string.Format("F{0}", rows)].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        Sheet.Cells[string.Format("G{0}", rows)].Style.Border.Top.Style = ExcelBorderStyle.Thin;

                        Sheet.Cells[string.Format("A{0}", rows)].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        Sheet.Cells[string.Format("B{0}", rows)].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        Sheet.Cells[string.Format("C{0}", rows)].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        Sheet.Cells[string.Format("D{0}", rows)].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        Sheet.Cells[string.Format("E{0}", rows)].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        Sheet.Cells[string.Format("F{0}", rows)].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        Sheet.Cells[string.Format("G{0}", rows)].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                        Sheet.Cells[string.Format("A{0}", rows)].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        Sheet.Cells[string.Format("B{0}", rows)].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        Sheet.Cells[string.Format("C{0}", rows)].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        Sheet.Cells[string.Format("D{0}", rows)].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        Sheet.Cells[string.Format("E{0}", rows)].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        Sheet.Cells[string.Format("F{0}", rows)].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        Sheet.Cells[string.Format("G{0}", rows)].Style.Border.Right.Style = ExcelBorderStyle.Thin;

                        Sheet.Cells[string.Format("A{0}", rows)].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        Sheet.Cells[string.Format("B{0}", rows)].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        Sheet.Cells[string.Format("C{0}", rows)].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        Sheet.Cells[string.Format("D{0}", rows)].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        Sheet.Cells[string.Format("E{0}", rows)].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        Sheet.Cells[string.Format("F{0}", rows)].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        Sheet.Cells[string.Format("G{0}", rows)].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        rows++;
                        row_index++;
                    }
                    catch
                    {
                        // Do nothing
                    }
                }
                Sheet.Column(1).Width = 20;
                Sheet.Column(2).Width = 20;
                Sheet.Column(3).Width = 20;
                Sheet.Column(4).Width = 20;
                Sheet.Column(5).Width = 20;
                Sheet.Column(6).Width = 20;
                Sheet.Column(7).Width = 25;
                ////Sheet.Cells["A:AZ"].AutoFitColumns();
                //Sheet.Cells["A:AZ"].Style.Font.Name = "ＭＳ Ｐゴシック";
                //string FileName = "RT1-CustomerOrder-" + Convert.ToDateTime(this.dgvUploadSummary.Tag.ToString()).ToString("yyyyMMdd");//this.dtpDateUploaded.Value.Date.ToString("yyyyMMdd");
                //Path = "C:\\Users\\" + Environment.UserName.Trim() + "\\Desktop\\" + FileName + ".xlsx";
                //FileInfo excelFile = new FileInfo(Path);
                ////try
                //try
                //{
                //    excel.SaveAs(excelFile);
                //}
                //catch (InvalidOperationException ex)
                //{
                //    Util.MessageUtil.Confirm("File name with " + FileName + " already open please close the file or do you want to read only ?", string.Format(Util.Messages.ERROR_FOUND, "Open file"), MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2);
                //}
                excel.Save();
                //open the file
                Process.Start(tempfile.FullName);
            }

            //New upload, send email
            if (_isNewUploaded)
                Util.Email.SendApprovedFile(ExcelPath, "", "");

            //else
            //{
            //    excel.Save();
            //    //open the file
            //    Process.Start(tempfile.FullName);
            //}

            btnSave.Enabled = false;
            _isNewUploaded = false;
            ExcelPath = "";
        }

        private void btnSaveAll_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private void cmbVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PopulateDatagridview("All");
        }

        #endregion

        #region Functions/Methods
        //Get All customer order add to list per version, by default version 1 | Author: Gbooc
        private void AllCustomerOrder(string MonthUploaded, string DateUploaded)
        {
            var CustomerByMonth = new Controllers.Maintenance.CustomerOrderController()
                                                                 .GetCustomerOrder(this.dtpMonthUploadedInto.Text.ToUpper().Trim());

            this._customerOrderList._List = CustomerByMonth._List.Where(x => x.date_uploaded.Equals(DateUploaded)).ToList();

            if (!string.IsNullOrEmpty(this._customerOrderList.Error))
                Util.MessageUtil.ShowError(this._customerOrderList.Error);

            else if (this._customerOrderList._List.Count == 0)
                Util.MessageUtil.ShowInfo(string.Format(Util.Messages.NO_REGISTERED_PO, this.dtpMonthUploadedInto.Text));
        }

        //Populate data to datagrid | Author: GBooc
        private void PopulateDatagridview(string Grid)
        {

            if (Grid.Equals("All"))
            {
                int good = 0;
                int ng = 0;
                int FC = 0;
                if (this.dgvCustomerOrder.RowCount > 0)
                    this.dgvCustomerOrder.Rows.Clear();

                string monthUploadedInto = this.dtpMonthUploadedInto.Text.ToUpper();
                string destination = this.cmbDestination.Text;
                int row_index = 0;
              
                var togrid = !isSearch ? _customerOrderList._List
                                                     .Where(x => x.month_uploaded_into.Trim() == monthUploadedInto.Trim())
                                                     .ToList()
                                                     : _customerOrderList._List
                                                                         .Where(x => x.month_uploaded_into.Trim() == monthUploadedInto.Trim() &&
                                                                               (
                                                                                x.rinks_no.Trim().ToLower().Contains(this.txtSearchBox.Text.Trim().ToLower()) ||
                                                                                x.rins_po_no.Trim().ToLower().Contains(this.txtSearchBox.Text.Trim().ToLower())
                                                                               ))
                                                                          .ToList();

                foreach (var customerOrder in togrid)
                {
                    if ((customerOrder.rins_po_no.ToLower().Trim() == "f/c" || customerOrder.rins_po_no.ToLower().Trim() == "fc") && !customerOrder.remarks.Equals("NG"))
                        FC++;


                    this.dgvCustomerOrder.Rows.Add(
                       customerOrder.rinks_no,
                       customerOrder.rins_po_no,
                       customerOrder.TAT,
                       customerOrder.CustomerDestination,
                       customerOrder.isFc,
                       customerOrder.po_qty,
                       customerOrder.etd.ToString("yyyyMMdd"),
                       customerOrder.eta_fukuoka,
                       customerOrder.eta_customer,
                       customerOrder.remarks,
                       customerOrder.rinks_no,
                       customerOrder.MFSODP_PO,
                       customerOrder.MFSODP_QTY,
                       customerOrder.MFSODP_ETD
                       );

                    if (customerOrder.remarks.Trim().Equals("NG"))
                    {
                        this.dgvCustomerOrder.Columns["colRemarks"].DefaultCellStyle.ForeColor = Color.Black;
                        this.dgvCustomerOrder.Columns["colRemarks"].DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
                        this.dgvCustomerOrder.Rows[row_index].Cells[colRemarks.Index].Style.ForeColor = Color.Red;
                        ng++;
                    }
                    else
                        good++;
                    row_index++;
                }

                txtGoodModel.Text = good.ToString();
                txtNoGoodModel.Text = ng.ToString();
                txtFcCount.Text = FC.ToString();
            
            }
            else if (Grid.Equals("Summary"))
            {
                foreach (var customerOrder in this._customerOrderList._List)
                {

                    this.dgvUploadSummary.Rows.Add(
                       customerOrder.month_uploaded_into,
                       Convert.ToDateTime(customerOrder.date_uploaded).ToString("yyyy-MM-dd"),
                       customerOrder.ModelCount
                       );
                }
            }

            isSearch = false;
        }

        //Search customer order | Author: Gbooc
        private void SearchCustomerOrder()
        {
            this.PopulateDatagridview("All");
        }

        //Load version and add to version combo box | Author: GBooc
        private void LoadVersion()
        {
            var TmpVersion = this._customerOrderController.AllVersion();
            _version = TmpVersion.Count == 0 ? 1 : TmpVersion.Max(x => x.version) + 1;
        }

        //Empty datagrid view | Author: GBooc
        private void EmptyDataGridView()
        {
            if (this.dgvCustomerOrder.RowCount > 0)
            {
                this.dgvCustomerOrder.Rows.Clear();
                this._toAdd.Clear();
            }
        }
        private void ImportFileToDataGridView()
        {

            Cursor = Cursors.WaitCursor;
            Models.Maintenance.CustomerOrderModel customerOrderModel = new Models.Maintenance.CustomerOrderModel();
            //Format columns

            this.btnImport.Enabled = false;

            //Get valid columns
            _POFormat = new Controllers.Maintenance.CustomerOrderController().POFormationDetails(Convert.ToInt32(((KeyValuePair<string, string>)this.cbCustomerType.SelectedItem).Value));

            //All active sheets
            for (int i = 0; i < ExcelSheets.Count; i++)
            {
                //Number of active sheets
                int Sheetnum = Convert.ToInt32(ExcelSheets[i]);

                if (ExcelSheets[i] != "")
                {
                    //Get sheets value
                    string SheetsValue = Util.FileUtil.GetSheetContent(this.txtPath.Text, Sheetnum);


                    if (!String.IsNullOrEmpty(SheetsValue))
                    {
                        string SheeetLine;
                        StringReader SheetSR = new StringReader(SheetsValue);

                        //Iterate sheets value, to check format
                        while ((SheeetLine = SheetSR.ReadLine()) != null)
                        {
                            string[] columns = SheeetLine.Split('\t');

                            try
                            {

                                //Check if all columns has value and valid
                                if (!string.IsNullOrEmpty(columns[(int)_POFormat.ModelName]) &&
                                   !string.IsNullOrEmpty(columns[(int)_POFormat.PONumber]) &&
                                   !string.IsNullOrEmpty(columns[(int)_POFormat.QTY]) &&
                                   !string.IsNullOrEmpty(columns[(int)_POFormat.ETD])
                                  )
                                {
                                    //check if qty column is int. This is to verify the row is not header
                                    int n;
                                    bool isNumeric = int.TryParse(columns[(int)_POFormat.QTY], out n);

                                    if (isNumeric) // qty should be int
                                    {
                                        string RinksNo = "";
                                        string Suffix = "";
                                        string Remarks = "";
                                        int DateETD = 0;
                                        bool isAllValid = true;

                                        string tmp = columns[(int)_POFormat.ModelName];

                                        //Remove and get suffix
                                        if (columns[(int)_POFormat.ModelName].Trim().Length <= 8)
                                            RinksNo = columns[(int)_POFormat.ModelName].Trim();
                                        else
                                        {
                                            RinksNo = columns[(int)_POFormat.ModelName].ToString().Substring(0, columns[(int)_POFormat.ModelName].ToString().Length - 1).Trim();
                                            Suffix = columns[(int)_POFormat.ModelName].Substring(columns[(int)_POFormat.ModelName].Length - 1);
                                        }

                                        string PONumber = columns[(int)_POFormat.PONumber].Trim().ToLower().Equals("f/c") ||
                                                    columns[(int)_POFormat.PONumber].Trim().ToLower().Equals("fc") ? "" :
                                                    Regex.Replace(columns[(int)_POFormat.PONumber], @"\t|\n|\r", "").Trim().ToLower(); //else | remove unwanted char and spaces

                                        //Convert excel date delivery to int, to match in mfsodp column format
                                        try
                                        {
                                            DateETD = Convert.ToInt32(Convert.ToDateTime(DateTime.FromOADate(Convert.ToDouble(columns[(int)_POFormat.ETD]))).ToString("yyyyMMdd"));
                                        }
                                        catch
                                        {
                                            // Do nothing
                                        }

                                        //Check if rinks exist
                                        var Summary = this._modelist._List
                                                                    .Where(x => x.RinksNo.Trim().ToLower()
                                                                                                .Equals(RinksNo.ToLower()))
                                                                                                .ToList();

                                        if (Summary.Count() > 0) //Rinks found
                                        {

                                            //Check if the suffix is match
                                            var MSuffix = Summary.Where(x => x.Suffix.ToLower().Trim()
                                                                              .Equals(Suffix.ToLower().Trim()) &&
                                                                                      x.PONumber.Trim().ToLower().Equals(PONumber))
                                                                  .Select(x => x.Suffix)
                                                                  .FirstOrDefault();
                                            //Determine if the po is match
                                            var PONum = Summary
                                                               .Where(x => x.PONumber.Trim().ToLower().Equals(PONumber))
                                                               .Select(x => x.PONumber)
                                                               .FirstOrDefault();

                                            //Check if the qty is match
                                            var QTY = Summary
                                                             .Where(x => Convert.ToInt32(x.Qty) == Convert.ToInt32(columns[(int)_POFormat.QTY]) &&
                                                                          x.PONumber.Trim().ToLower().Equals(PONumber))
                                                             .Select(x => x.Qty)
                                                             .FirstOrDefault();

                                            //Determine if the etd is match 
                                            var DateDelivery = Summary
                                                              .Where(x => x.DateDelivery == DateETD &&
                                                                          x.PONumber.Trim().ToLower().Equals(PONumber))
                                                              .Select(x => x.DateDelivery)
                                                              .FirstOrDefault();

                                            //Validate import and mfsodp | to determine NG | Good                                   
                                            if (MSuffix == null)
                                                isAllValid = false;
                                            else customerOrderModel.MFSODP_Rinks = RinksNo;

                                            if (PONum == null || String.IsNullOrEmpty(PONumber.Trim()))
                                            {
                                                //Determine if fc
                                                if (String.IsNullOrEmpty(PONumber.Trim()))
                                                {
                                                    //Check if fc's qty and etd exist, if exist consider it to be the fc item
                                                    var FC_QTY_ETD = Summary
                                                                            .Where(x => Convert.ToInt32(x.Qty) == Convert.ToInt32(columns[(int)_POFormat.QTY]) &&
                                                                                                        x.DateDelivery == DateETD)
                                                                            .FirstOrDefault();

                                                    if (FC_QTY_ETD == null)
                                                        isAllValid = false;
                                                    else
                                                    {
                                                        customerOrderModel.MFSODP_QTY = Convert.ToInt32(FC_QTY_ETD.Qty);
                                                        customerOrderModel.MFSODP_ETD = FC_QTY_ETD.DateDelivery.ToString();
                                                        customerOrderModel.MFSODP_PO = "F/C";
                                                        customerOrderModel.MFSODP_Rinks = columns[(int)_POFormat.ModelName].ToString().Trim();

                                                        isAllValid = true;
                                                    }
                                                    FC++;
                                                } //Not fc, but PO not found
                                                else isAllValid = false;
                                            }
                                            else
                                            { //
                                                customerOrderModel.MFSODP_PO = PONumber.ToString();

                                                if (QTY == null)
                                                    isAllValid = false;
                                                else customerOrderModel.MFSODP_QTY = Convert.ToInt32(QTY);

                                                if (DateDelivery == null)
                                                    isAllValid = false;
                                                else customerOrderModel.MFSODP_ETD = DateDelivery.ToString();
                                                //End of validation
                                            }

                                            if (!isAllValid)
                                            {
                                                Remarks = "NG";
                                                NoGood++;
                                            }
                                            else
                                                Good++;
                                        }
                                        else
                                        {
                                            Remarks = "NG";
                                            NoGood++;
                                        }

                                        // assign values to rows
                                        try
                                        {
                                            //   Modelrinks_no = RinksNo;
                                            customerOrderModel.rinks_no = RinksNo;
                                            customerOrderModel.rins_po_no = String.IsNullOrEmpty(PONumber) ? "F/C" : PONumber;
                                            //  string destination = "";//Format.Equals("HK") ? HKDestination : "佐鳥電機 Satori Electric";
                                            customerOrderModel.po_qty = Convert.ToInt32(columns[(int)_POFormat.QTY]);
                                            customerOrderModel.etd = DateTime.FromOADate(Convert.ToDouble(columns[(int)_POFormat.ETD]));
                                        }
                                        catch
                                        {
                                            // For empty columns | Do nothing
                                        }

                                        if (!(String.IsNullOrEmpty(Remarks)) && (customerOrderModel.rins_po_no.ToLower() != "f/c" || customerOrderModel.rins_po_no.ToLower() != "fc"))
                                        {
                                            this.dgvCustomerOrder.Columns["colRemarks"].DefaultCellStyle.ForeColor = Color.Red;
                                            this.dgvCustomerOrder.Columns["colRemarks"].DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
                                        }

                                        //Load to datagrid
                                        this.dgvCustomerOrder.Rows.Add(
                                        customerOrderModel.rinks_no,
                                        customerOrderModel.rins_po_no,
                                        "",
                                        "",
                                        customerOrderModel.po_qty,
                                        customerOrderModel.etd,
                                        Remarks,
                                        String.IsNullOrEmpty(customerOrderModel.MFSODP_Rinks) ? RinksNo + "_mismatch" : customerOrderModel.MFSODP_Rinks,
                                        String.IsNullOrEmpty(customerOrderModel.MFSODP_PO) ? customerOrderModel.rins_po_no + "_mismatch" : customerOrderModel.MFSODP_PO,
                                        customerOrderModel.MFSODP_QTY,
                                        String.IsNullOrEmpty(customerOrderModel.MFSODP_ETD) ? customerOrderModel.etd + "_mismatch" : customerOrderModel.MFSODP_ETD,
                                        Suffix);

                                        this._toAdd.Add(this.dgvCustomerOrder.Rows[this.dgvCustomerOrder.RowCount]);

                                        //   this.cmbDestination.Text = Format.Equals("HK") || Format.Equals("USA") ? HKCBDestination : Format;
                                        Remarks = "";

                                    }
                                }
                            }
                            catch
                            {
                                //do nothing
                            }

                        }
                    }
                }
            }

            this.txtNoGoodModel.Text = NoGood.ToString();
            this.txtGoodModel.Text = Good.ToString();
            this.txtFcCount.Text = FC.ToString();

            this.btnImport.Enabled = true;
            this.btnSave.Enabled = true;
            this.btnClearAll.Enabled = true;

            NoGood = 0;
            Good = 0;
            FC = 0;
            Cursor = Cursors.Hand;
        }

        public void IdentifyImport(string[] columns, Models.Maintenance.CustomerOrderModel data, string Format)
        {
            string RinksNo = "";
            //iterate columns
            //foreach (var cols in _formatrowList._List)
            //{
            //    //Remove suffix
            //    if(cols.HeaderName.Equals(""))
            //    {

            //    }
            //    RinksNo = columns[Index[0]].Length <= 8 ? columns[Index[0]].Trim() :
            //                                      columns[Index[0]].ToString().Substring(0, columns[Index[0]].ToString().Length - 1).Trim();
            //} 

        }
        //Add model value accordingly from datagrid row
        public Models.Maintenance.CustomerOrderModel assignRowToModels(DataGridViewRow row)
        {
            Models.Maintenance.CustomerOrderModel model = new Models.Maintenance.CustomerOrderModel();

            var ETD = Convert.ToString(row.Cells["colETD"].Value);
            var MonthYear = DateTime.Today.ToString("MMMM yyyy").ToUpper();

            model.month_uploaded_into = MonthYear;
            model.date_uploaded = this.dtpDateUploaded.Value.Date.ToString("yyyyy-MM-dd");
            model.version = this._version;
            model.rins_po_no = Convert.ToString(row.Cells["colRinsPONo"].Value);
            model.rinks_no = Convert.ToString(row.Cells["colRinksNo"].Value);
            model.destination = Convert.ToString(this.cmbDestination.Text);
            model.remarks = Convert.ToString(row.Cells["colRemarks"].Value);
            model.po_qty = Convert.ToInt32(row.Cells["colPOQty"].Value);
            model.etd = DateTime.ParseExact(ETD,
                                  "yyyyMMdd",
                                   CultureInfo.InvariantCulture);

            model.eta_fukuoka = row.Cells["colETAFukuoka"].Value == null ? (DateTime?)null :
                                                 Convert.ToDateTime(row.Cells["colETAFukuoka"].Value).Date;
            model.eta_customer = row.Cells["colETACustomer"].Value == null ? (DateTime?)null :
                                                Convert.ToDateTime(row.Cells["colETACustomer"].Value).Date;
            model.TAT = Convert.ToString(row.Cells["colTat"].Value);
            model.CustomerDestination = Convert.ToString(row.Cells["colDestination"].Value);

            model.MFSODP_Rinks = Convert.ToString(row.Cells["colMRinks"].Value);
            model.MFSODP_PO = Convert.ToString(row.Cells["colMPO"].Value);
            model.MFSODP_QTY = Convert.ToInt32(row.Cells["colMQTY"].Value);
            model.MFSODP_ETD = Convert.ToString(row.Cells["colMEtd"].Value);
            model.Suffix = Convert.ToString(row.Cells["colSuffix"].Value);

            //model.Action = "Grace Booc"; // to be modify
            //model.DateCreated = DateTime.Now;
            //model.DateModified = null;
            //model.UserLog = "added";
            //model.remarks = "";

            return model;
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            Models.Maintenance.CustomerOrderModel result = new Models.Maintenance.CustomerOrderModel();

            string generalEx = "";
            int duplicates = 0;
            int rowSaved = 0;

            foreach (DataGridViewRow row in this._toAdd)
            {
                result = this.assignRowToModels(row);

                string RinksNo = result.rinks_no.Length <= 8 ? result.rinks_no.Trim() :
                                             result.rinks_no.ToString().Substring(0, result.rinks_no.ToString().Length - 1).Trim();

                Models.Maintenance.RinksModel models = new Models.Maintenance.RinksModel();

                ///Check if model is already in the model maintenance
                var ModelMaintenance = this._modelController.GetAllModels()._List
                                                       .Where(x => x.RinksNo.Trim().ToLower().Equals(RinksNo.ToLower()))
                                                       .Select(x => x.RinksNo)
                                                       .FirstOrDefault();

                ///If not exist, add to system model maintenance
                if (ModelMaintenance == null)
                {
                    models.RinksNo = RinksNo;
                    models.TAT = result.TAT;
                    models.CustomerName = result.CustomerDestination;

                    this._modelController.AddModel(models);
                }

                result = _customerOrderController.InsertCustomerOrder(result);

                //if (!this._customerOrderController.IsExist(result.rinks_no, result.rins_po_no.Trim(), Convert.ToInt32(result.po_qty), result.etd))
                //    result = _customerOrderController.InsertCustomerOrder(result);

                if (result.Error == "Duplicates entry")
                    duplicates++;
                else if (duplicates == 0 && !String.IsNullOrEmpty(generalEx))
                    generalEx = result.Error;

                _isNewUploaded = true;
                rowSaved++;
            }

            //Check for errors
            if (duplicates > 0)
                Util.MessageUtil.ShowError("You already saved the " + duplicates + " entries.", "Duplicates Found");
            else if (!String.IsNullOrEmpty(generalEx))
                Util.MessageUtil.ShowError(generalEx, "Something went wrong");

            //No error found
            if (duplicates == 0 && String.IsNullOrEmpty(generalEx) && rowSaved > 0)
                Util.MessageUtil.ShowInfo("Successfully saved entries", Util.Messages.SUCCESS_TITLE);

            lblMessage.Text = "This will be saved.";
            this.btnExport.PerformClick();

            this._toAdd.Clear();
            this.loadUploadedSummary();
            this._isImport = false;
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            this.LoadVersion();
            //  this.AllCustomerOrder();
            loadUploadedSummary();
            this._toAdd.Clear();
        }

        private void dgvCustomerOrder_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void dgvUploadSummary_SelectionChanged(object sender, EventArgs e)
        {
            if (_isImport && !isSearch)
            {
                Util.MessageUtil.ShowWarning(string.Format(Util.Messages.SAVE_CHANGES_FIRST, Util.Messages.WARNING_TITLE));
                return;
            }

            if (dgvUploadSummary.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgvUploadSummary.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvUploadSummary.Rows[selectedrowindex];

                string MonthUpload = Convert.ToString(selectedRow.Cells["colUpdMonth"].Value).Trim();
                string DateUploaded = Convert.ToString(selectedRow.Cells["colUpdDate"].Value).Trim();
                this.dgvUploadSummary.Tag = DateUploaded;
                AllCustomerOrder(MonthUpload, "0" + DateUploaded);
                PopulateDatagridview("All");
            }
        }

        private void dgvCustomerOrder_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCustomerOrder.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgvCustomerOrder.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvCustomerOrder.Rows[selectedrowindex];

                string Rinks = Convert.ToString(selectedRow.Cells["colMRinks"].Value).Trim();
                string PO = Convert.ToString(selectedRow.Cells["colMPO"].Value).Trim();
                string QTY = Convert.ToString(selectedRow.Cells["colMQTY"].Value).Trim();
                string ETD = Convert.ToString(selectedRow.Cells["colMEtd"].Value).Trim();

                var ExcelRinks = Convert.ToString(selectedRow.Cells["colRinksNo"].Value).Trim();
                var ExcelPO = Convert.ToString(selectedRow.Cells["colRinsPONo"].Value).Trim();
                var ExcelQTY = Convert.ToString(selectedRow.Cells["colPOQty"].Value).Trim();
                var ExcelETD = Convert.ToInt32((selectedRow.Cells["colETD"].Value));

                lblExcelRinks.Text = ExcelRinks;
                lblMRinks.Text = Rinks.ToString();

                lblExcelPo.Text = ExcelPO;
                lblMPo.Text = PO.ToString();

                lblExcelQTY.Text = ExcelQTY;
                lblMQTY.Text = QTY.ToString();

                lblExcelEtd.Text = ExcelETD.ToString();
                lblMEtd.Text = ETD.ToString();

                if (Rinks.Trim().Equals("") || Rinks.Contains("mismatch"))
                {
                    lblMRinks.ForeColor = Color.Red;
                    lblMRinks.Text = "Mismatch";
                }
                else
                {
                    lblMRinks.ForeColor = Color.Black;
                    lblMRinks.Text = Rinks;
                }

                if (PO.Contains("mismatch") && !String.IsNullOrEmpty(ExcelPO))
                {
                    lblMPo.ForeColor = Color.Red;
                    lblMPo.Text = "Mismatch";
                }
                else
                {
                    lblMPo.ForeColor = Color.Black;
                    lblMPo.Text = PO;
                }
                if (QTY.Equals("0"))
                {
                    lblMQTY.ForeColor = Color.Red;
                    lblMQTY.Text = "Mismatch";
                }
                else
                {
                    lblMQTY.ForeColor = Color.Black;
                    lblMQTY.Text = QTY;
                }
                if (ETD.Contains("mismatch"))
                {
                    lblMEtd.ForeColor = Color.Red;
                    lblMEtd.Text = "Mismatch";
                }
                else
                {
                    lblMEtd.ForeColor = Color.Black;
                    lblMEtd.Text = ETD;
                }
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {

            if (this._toAdd.Count == 0)
            {
                this.EmptyDataGridView();
                this.ImportFileToDataGridView();
            }
            else
                Util.MessageUtil.ShowWarning(Util.Messages.SAVE_CHANGES_FIRST);

        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {

            this.EmptyDataGridView();
            this.btnSave.Enabled = true;
            this.btnGetData.Enabled = true;
            this.btnClearAll.Enabled = true;
            _isImport = false;
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(200);
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        #region IMPORT FORMAT


        public void IdentifyImport1(string[] columns, Models.Maintenance.CustomerOrderModel data, string Format)
        {

            string remarks = "";
            string destination = "";
            string RinksNo = "";
            string Suffix = "";
            string PONumber = "";
            string HKDestination = "";
            string HKCBDestination = "";

            int DateETD = 0;
            int row_index = 0;
            bool isAllValid = true;

            string[] Headers = new string[3];
            int[] Index = new int[6];

            //Set header names and columns index according to destination
            if (Format.Equals("HK"))
            {
                Headers[0] = "rins item#";
                Headers[1] = "toto parts#";
                Headers[2] = "toto po#";

                Index[0] = 0; //RinksNo
                Index[1] = 2; //PO No
                Index[2] = 6; //QTY
                Index[3] = 5; //Date
                Index[4] = 3; //ETA Airport
                Index[5] = 4;//ETA Customer

                customer_partnumber = columns[1];

                HKDestination = "TOTO SHANGHAI";
                HKCBDestination = "HK-SH";


            }
            else if (Format.Equals("VN"))
            {
                Headers[0] = "rins item#";
                Headers[1] = "toto parts#";
                Headers[2] = "toto vn po#";

                Index[0] = 0; //RinksNo
                Index[1] = 2; //PO No
                Index[2] = 7; //QTY
                Index[3] = 6; //Date
                Index[4] = 5; //ETA Airport
                Index[5] = 6;//ETA Customer

                customer_partnumber = columns[1];

                HKDestination = "TOTO Vietnam";
                HKCBDestination = "HK( TVN )";
            }
            else if (Format.Equals("USA"))
            {
                Headers[0] = "rins item#";
                Headers[1] = "toto parts#";
                Headers[2] = "totos po#";

                Index[0] = 0; //RinksNo
                Index[1] = 2; //PO No
                Index[2] = 7; //QTY
                Index[3] = 6; //Date
                Index[4] = 4; //ETA Airport
                Index[5] = 5;//ETA Customer

                customer_partnumber = columns[1];

                //Identify HS/TVN/USA
                if (this.lblFileName.Text.Trim().ToLower().Contains("usa"))
                {
                    HKDestination = "TOTO USA";
                    HKCBDestination = "HK-US";
                }
            }
            else //JPN
            {
                Headers[0] = "";
                Headers[1] = "rins po no.";
                Headers[2] = "po qty";

                Index[0] = 0; //RinksNo
                Index[1] = 1; //PO No
                Index[2] = 2; //QTY
                Index[3] = 3; //Date
                Index[4] = 4; //ETA Airport
                Index[5] = 5;//ETA Customer

            }

            //Exclude header
            if (!(columns[0].ToString().Trim().ToLower().Equals(Headers[0])) &&
                !(columns[1].ToString().Trim().ToLower().Equals(Headers[1])) &&
               (!(columns[2].ToString().Trim().ToLower().Equals(Headers[2])) || (Headers[2].Equals(""))))
            {
                RinksNo = columns[Index[0]].Length <= 8 ? columns[Index[0]].Trim() :
                                                  columns[Index[0]].ToString().Substring(0, columns[Index[0]].ToString().Length - 1).Trim(); // remove suffix

                PONumber = columns[Index[1]].Trim().ToLower().Equals("f/c") ||
                           columns[Index[1]].Trim().ToLower().Equals("fc") ? "" :
                           Regex.Replace(columns[Index[1]], @"\t|\n|\r", "").Trim().ToLower(); //else | remove unwanted char and spaces

                //identify suffix
                if (columns[Index[0]].Length > 8) // has suffix
                    Suffix = columns[Index[0]].Substring(columns[Index[0]].Length - 1);
                else
                    Suffix = "";

                //convert date delivery to int
                try
                {
                    DateETD = Convert.ToInt32(Convert.ToDateTime(DateTime.FromOADate(Convert.ToDouble(columns[Index[3]]))).ToString("yyyyMMdd"));
                }
                catch
                {
                    // Do nothing
                }

                //Check if rinks exist
                var Summary = this._modelist._List
                                            .Where(x => x.RinksNo.Trim().ToLower()
                                                                        .Equals(RinksNo.ToLower()))
                                                                        .ToList();

                if (Summary.Count() > 0) //Rinks found
                {

                    //Determine if the suffix is match
                    var MSuffix = Summary.Where(x => x.Suffix.ToLower().Trim()
                                                      .Equals(Suffix.ToLower().Trim()) &&
                                                              x.PONumber.Trim().ToLower().Equals(PONumber))
                                          .Select(x => x.Suffix)
                                          .FirstOrDefault();
                    //Determine if the po is match
                    var PONum = Summary
                                       .Where(x => x.PONumber.Trim().ToLower().Equals(PONumber))
                                       .Select(x => x.PONumber)
                                       .FirstOrDefault();
                    //Determie if the qty is match
                    var QTY = Summary
                                     .Where(x => Convert.ToInt32(x.Qty) == Convert.ToInt32(columns[Index[2]]) &&
                                                  x.PONumber.Trim().ToLower().Equals(PONumber))
                                     .Select(x => x.Qty)
                                     .FirstOrDefault();

                    //Determine if the etd is match 
                    var DateDelivery = Summary
                                      .Where(x => x.DateDelivery == DateETD &&
                                                  x.PONumber.Trim().ToLower().Equals(PONumber))
                                      .Select(x => x.DateDelivery)
                                      .FirstOrDefault();

                    //Validate import and mfsodp | to determine NG | Good                                   
                    if (MSuffix == null)
                        isAllValid = false;
                    else data.MFSODP_Rinks = RinksNo;

                    if (PONum == null || String.IsNullOrEmpty(PONumber.Trim()))
                    {
                        //Determine if fc
                        if (String.IsNullOrEmpty(PONumber.Trim()))
                        {
                            //Check if fc's qty and etd exist, if exist consider it to be the fc item
                            var FC_QTY_ETD = Summary
                                                    .Where(x => Convert.ToInt32(x.Qty) == Convert.ToInt32(columns[Index[2]]) &&
                                                                                x.DateDelivery == DateETD)
                                                    .FirstOrDefault();

                            if (FC_QTY_ETD == null)
                                isAllValid = false;
                            else
                            {
                                data.MFSODP_QTY = Convert.ToInt32(FC_QTY_ETD.Qty);
                                data.MFSODP_ETD = FC_QTY_ETD.DateDelivery.ToString();
                                data.MFSODP_PO = "F/C";
                                data.MFSODP_Rinks = columns[Index[0]].ToString().Trim();

                                isAllValid = true;
                            }
                            FC++;
                        } //Not fc, but PO not found
                        else isAllValid = false;
                    }
                    else
                    { //
                        data.MFSODP_PO = PONumber.ToString();

                        if (QTY == null)
                            isAllValid = false;
                        else data.MFSODP_QTY = Convert.ToInt32(QTY);

                        if (DateDelivery == null)
                            isAllValid = false;
                        else data.MFSODP_ETD = DateDelivery.ToString();
                        //End of validation
                    }

                    if (!isAllValid)
                    {
                        remarks = "NG";
                        NoGood++;
                    }
                    else
                        Good++;
                }
                else
                {
                    remarks = "NG";
                    NoGood++;
                }

                // assign values to rows
                try
                {
                    data.rinks_no = RinksNo;
                    data.rins_po_no = String.IsNullOrEmpty(PONumber) ? "F/C" : PONumber;
                    destination = Format.Equals("HK") ? HKDestination : "佐鳥電機 Satori Electric";
                    data.po_qty = Convert.ToInt32(columns[Index[2]]);
                    data.etd = DateTime.FromOADate(Convert.ToDouble(columns[Index[3]]));
                    data.eta_fukuoka = DateTime.FromOADate(Convert.ToDouble(columns[Index[4]]));
                    data.eta_customer = DateTime.FromOADate(Convert.ToDouble(columns[Index[5]]));
                }
                catch
                {
                    // For empty columns | Do nothing
                }

                if (!(String.IsNullOrEmpty(remarks)) && (data.rins_po_no.ToLower() != "f/c" || data.rins_po_no.ToLower() != "fc"))
                {
                    this.dgvCustomerOrder.Columns["colRemarks"].DefaultCellStyle.ForeColor = Color.Red;
                    this.dgvCustomerOrder.Columns["colRemarks"].DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
                }

                //Load to datagrid
                this.dgvCustomerOrder.Rows.Add(
                data.rinks_no,
                data.rins_po_no,
                customer_partnumber,
                destination,
                0,
                data.po_qty,
                data.etd.ToString("yyyyMMdd"),
                data.eta_fukuoka,
                data.eta_customer,
                remarks,
                String.IsNullOrEmpty(data.MFSODP_Rinks) ? RinksNo + "_mismatch" : data.MFSODP_Rinks,
                String.IsNullOrEmpty(data.MFSODP_PO) ? data.rins_po_no + "_mismatch" : data.MFSODP_PO,
                data.MFSODP_QTY,
                String.IsNullOrEmpty(data.MFSODP_ETD) ? data.etd + "_mismatch" : data.MFSODP_ETD,
                Suffix);

                this._toAdd.Add(this.dgvCustomerOrder.Rows[this.dgvCustomerOrder.RowCount - 1]);

                this.cmbDestination.Text = Format.Equals("HK") || Format.Equals("USA") ? HKCBDestination : Format;
                row_index++;
                remarks = "";
            }
        }
        public void loadUploadedSummary()
        {
            if (this.dgvUploadSummary.RowCount > 0)
            {
                this.dgvCustomerOrder.Rows.Clear();
                this.dgvUploadSummary.Rows.Clear();
            }

            try
            {
                this._customerOrderList._List = new Controllers.Maintenance.CustomerOrderController()
                                                                           .GetAllUploadedPO()
                                                                           .Where(x => x.month_uploaded_into.ToUpper().Trim().Equals(this.dtpMonthUploadedInto.Text.ToUpper().Trim()))
                                                                           .ToList();
                PopulateDatagridview("Summary");
            }
            catch
            {
                //Table is empty, do nothing
            }
        }
        #endregion

        private void BtnSearchGrid_Click(object sender, EventArgs e)
        {
            isSearch = true;
            PopulateDatagridview("All");
        }

        private void BtnReload_Click(object sender, EventArgs e)
        {
            PopulateDatagridview("All");
            this.txtSearchBox.Text = string.Empty;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void GetImportedPO()
        {

        }
    }
}