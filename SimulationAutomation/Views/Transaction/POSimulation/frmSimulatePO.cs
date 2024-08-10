using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace SimulationAutomation.Views.Transaction.POSimulation
{
    public partial class frmSimulatePO : Form
    {
        public frmSimulatePO()
        {
            InitializeComponent();
        }

        private Models.Transaction.POSimulationList _poList;

        private void frmSimulatePO_Load(object sender, EventArgs e)
        {
            this._poList = new Controllers.Transaction.POSimulationController().Get_New_PO();

            if (!string.IsNullOrEmpty(_poList.Error))
            {
                Util.MessageUtil.ShowError(_poList.Error);
                return;
            }

            foreach (var item in _poList.List.OrderBy(x => x.no))
            {
                this.dataGridView1.Rows.Add(item.no, item.PONumber, item.ItemNo, item.Suffix, item.tat, item.destination, item.PoBalance, item.DeliveryDate, item.Remarks);

                this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Cells[this.colRemarks.Index].Style.ForeColor = (item.Remarks == Util.GlobalConstants.NO_MODEL || item.Remarks == Util.GlobalConstants.NO_CAPCITY_SETUP) ? Color.Red : Color.Black;
                this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Cells[this.colRemarks.Index].Style.Font = (item.Remarks == Util.GlobalConstants.NO_MODEL || item.Remarks == Util.GlobalConstants.NO_CAPCITY_SETUP) ? new Font(DataGridView.DefaultFont, FontStyle.Bold) : new Font(DataGridView.DefaultFont, FontStyle.Regular);
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string poNo = this.dataGridView1.Rows[e.RowIndex].Cells[this.colPONo.Index].Value.ToString();
            string itemNo = this.dataGridView1.Rows[e.RowIndex].Cells[this.colItemNo.Index].Value.ToString();
            string suffix = this.dataGridView1.Rows[e.RowIndex].Cells[this.colSuffix.Index].Value.ToString();
            string model = this.dataGridView1.Rows[e.RowIndex].Cells[this.colModel.Index].Value.ToString();
            string poNumber = this.dataGridView1.Rows[e.RowIndex].Cells[this.colPONo.Index].Value.ToString();
            int deliveryDate = int.Parse(this.dataGridView1.Rows[e.RowIndex].Cells[this.colDeliveryDate.Index].Value.ToString());
            var poName = this._poList.List
                                     .Where(x => x.PONumber.Equals(poNo)
                                              && x.ItemNo.Equals(itemNo)
                                              && x.Suffix.Equals(suffix)
                                              && x.tat.Equals(model)
                                              && x.PONumber.Equals(poNumber)
                                              && x.DeliveryDate.Equals(deliveryDate))
                                     .OrderBy(x => x.no)
                                     .FirstOrDefault();
            if (e.ColumnIndex == this.colPOBalance.Index)
                poName.PoBalance = int.Parse(this.dataGridView1.Rows[e.RowIndex].Cells[this.colPOBalance.Index].Value.ToString());
            else if (e.ColumnIndex == this.colNo.Index)
                poName.no = int.Parse(this.dataGridView1.Rows[e.RowIndex].Cells[this.colNo.Index].Value.ToString());

        }

        private void dataGridView1_DataGridViewButtonClick1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string poNo = this.dataGridView1.Rows[e.RowIndex].Cells[this.colPONo.Index].Value.ToString();
                string itemNo = this.dataGridView1.Rows[e.RowIndex].Cells[this.colItemNo.Index].Value.ToString();
                string suffix = this.dataGridView1.Rows[e.RowIndex].Cells[this.colSuffix.Index].Value.ToString();
                string model = this.dataGridView1.Rows[e.RowIndex].Cells[this.colModel.Index].Value.ToString();
                string poNumber = this.dataGridView1.Rows[e.RowIndex].Cells[this.colPONo.Index].Value.ToString();
                //int order = int.Parse(this.dataGridView1.Rows[e.RowIndex].Cells[this.colOrder.Index].Value.ToString());
                int poBalance = int.Parse(this.dataGridView1.Rows[e.RowIndex].Cells[this.colPOBalance.Index].Value.ToString());
                int deliveryDate = int.Parse(this.dataGridView1.Rows[e.RowIndex].Cells[this.colDeliveryDate.Index].Value.ToString());
                var poName = this._poList.List
                                         .Where(x => x.PONumber.Equals(poNo)
                                                  && x.ItemNo.Equals(itemNo)
                                                  && x.Suffix.Equals(suffix)
                                                  && x.tat.Equals(model)
                                                  && x.PONumber.Equals(poNumber)
                                             //&& x.no.Equals(order)
                                                  && x.PoBalance.Equals(poBalance)
                                                  && x.DeliveryDate.Equals(deliveryDate))
                                         .OrderBy(x => x.no)
                                         .FirstOrDefault();

                this._poList.List.Remove(poName);
                this.dataGridView1.Rows.RemoveAt(e.RowIndex);
            }
            catch (Exception ex)
            {
                Util.MessageUtil.ShowError(ex.Message, string.Format(Util.Messages.ERROR_FOUND, ""));
            }
        }

        private void btnSimulatePO_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in this.dataGridView1.Rows)
                {
                    if (row.Cells[this.colRemarks.Index].Value.ToString() == Util.GlobalConstants.NO_MODEL)
                    {
                        Util.MessageUtil.ShowWarning("No Model found! please set up model in model maintenance", Util.Messages.WARNING_TITLE);
                        return;
                    }
                    else if (row.Cells[this.colRemarks.Index].Value.ToString() == Util.GlobalConstants.NO_CAPCITY_SETUP)
                    {
                        Util.MessageUtil.ShowWarning("No Capacity setup found! please set up capacity in capacity setup.", Util.Messages.WARNING_TITLE);
                        return;
                    }
                }
                if (!this.backgroundWorker1.IsBusy)
                {
                    if (this.dataGridView1.RowCount > 0)
                    {
                        Models.Transaction.CapacityList capacityList = new Controllers.Transaction.POSimulationController().GetCapacity();
                        if (!string.IsNullOrEmpty(capacityList.Error))
                        {
                            Util.MessageUtil.ShowError(capacityList.Error, string.Format(Util.Messages.ERROR_FOUND, ""));
                            return;
                        }
                        int version = new Controllers.Transaction.POSimulationController().GetLatestSimulationVersion();
                        DateTime start_of_Process = DateTime.Now.AddDays(0).Date;
                        this.btnExportToExcel.Tag = version;
                        Tuple<int, DateTime, Models.Transaction.CapacityList> argument = new Tuple<int, DateTime, Models.Transaction.CapacityList>(version, start_of_Process.Date, capacityList);
                        this.backgroundWorker1.RunWorkerAsync(argument);
                    }
                    else
                    {
                        Util.MessageUtil.ShowWarning("No data found!.", Util.Messages.WARNING_TITLE);
                        return;
                    }

                }
                else
                {
                    Util.MessageUtil.ShowWarning("Simulation is running please wait...", Util.Messages.WARNING_TITLE);
                    return;
                }
            }
            catch (Exception ex)
            {
                Util.MessageUtil.ShowError(ex.Message, Util.Messages.ERROR_TITLE);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            Tuple<int, DateTime, Models.Transaction.CapacityList> start_of_Process = e.Argument as Tuple<int, DateTime, Models.Transaction.CapacityList>;
            int version = start_of_Process.Item1;
            DateTime dateProcess = start_of_Process.Item2;
            Models.Transaction.CapacityList capacity = start_of_Process.Item3;

            Models.Transaction.RT1_Simulation_CalendarList result = new Controllers.Transaction.POSimulationController().GetCalendar();

            string[] lines = { "A", "B" };
            int ctrl = 1;
            foreach (Models.Transaction.RT1_Simulation_Calendar item in result.List)
            {
                foreach (var line in lines)
                {
                    if (line == Util.GlobalConstants.LINE_A)
                    {
                        bool specialCase = false;
                        int firstRemainingQuantity = 0;
                        int capacity_Value = 0;
                        Models.Transaction.Simulator simulator = new Models.Transaction.Simulator();
                        var poName = this._poList.List
                                                 .Where(x => x.Line_A == 1
                                                          && x.PoBalance > 0)
                                                 .OrderBy(x => x.no)
                                                 .FirstOrDefault();

                        if (poName != null)
                        {
                            var shiftDate = capacity.List
                                                   .Where(x => x.CODE.Equals(item.ShiftCode)
                                                            && x.WorkScheme.Equals(item.ShiftWorkScheme)
                                                            && x.Model.Equals(poName.ItemNo)
                                                            && x.Line.Equals(line))
                                                   .FirstOrDefault();
                            
                            if (shiftDate == null) return;


                            simulator.id = ctrl;
                            simulator.version = version;
                            simulator.Date = item.Date;
                            simulator.ItemNo = poName.ItemNo;
                            simulator.Suffix = poName.Suffix;
                            simulator.Model = poName.tat;
                            simulator.Seq = poName.no.Value;
                            simulator.PO = poName.PONumber;
                            simulator.PO_Qty = poName.PO_Qty;
                            simulator.PO_Balance = poName.PoBalance;
                            if (simulator.PO_Balance > shiftDate.capacity)
                            {
                                simulator.Quota = shiftDate.capacity;
                                poName.PoBalance = poName.PoBalance - simulator.Quota;
                            }
                            else if (simulator.PO_Balance <= shiftDate.capacity)
                            {
                                specialCase = true;

                                firstRemainingQuantity = simulator.PO_Balance;
                                simulator.Quota = simulator.PO_Balance;
                                //capacity_Value = (simulator.Quota - simulator.Capacity);
                                capacity_Value = shiftDate.capacity;
                                poName.PoBalance = poName.PoBalance - simulator.Quota;
                            }
                            simulator.ShiftName = item.shiftname;
                            simulator.ShiftCode = item.ShiftCode;
                            simulator.ShiftWorkScheme = item.ShiftWorkScheme;
                            simulator.ShiftHours = item.ShiftHours.Value;
                            simulator.Line = line;
                            simulator.Capacity = shiftDate.capacity;
                            simulator.DeliveryDate = poName.DeliveryDate;
                            simulator.Status = "Processing";
                            //shiftDate.capacity = (shiftDate.capacity - simulator.Quota);
                            new Controllers.Transaction.POSimulationController().InsertSimulator(simulator);

                        SimualateNewPO:
                            if (specialCase)
                            {
                                ctrl++;
                                //hourlyRate = capacity/ shifthours
                                //double firstHourlyRate = Convert.ToDouble(shiftDate.capacity) / Convert.ToDouble(item.ShiftHours);
                                double firstHourlyRate = Convert.ToDouble(capacity_Value) / Convert.ToDouble(item.ShiftHours);
                                //remainingHours = shiftHours - firstHourlyRate
                                double firstRemainingHours = Convert.ToDouble(item.ShiftHours) - (Convert.ToDouble(firstRemainingQuantity) / firstHourlyRate);

                                var poName1 = this._poList.List
                                                     .Where(x => x.Line_A == 1
                                                              && x.PoBalance > 0)
                                                     .OrderBy(x => x.no)
                                                     .FirstOrDefault();
                                if (poName1 != null)
                                {
                                    var shiftDate1 = capacity.List
                                                        .Where(x => x.CODE.Equals(item.ShiftCode)
                                                                 && x.WorkScheme.Equals(item.ShiftWorkScheme)
                                                                 && x.Model.Equals(poName1.ItemNo)
                                                                 && x.Line.Equals(line))
                                                        .FirstOrDefault();
                                    
                                    if (shiftDate1 == null) return;

                                    int qoutaPerHour = Convert.ToInt32(Convert.ToDouble(shiftDate1.capacity) / Convert.ToDouble(item.ShiftHours));

                                    int newCapacity = Convert.ToInt32(firstRemainingHours * qoutaPerHour);

                                    bool canSimulateNewPO = false;

                                    Models.Transaction.Simulator simulator1 = new Models.Transaction.Simulator();
                                    simulator1.id = ctrl;
                                    simulator1.version = version;
                                    simulator1.Date = item.Date;
                                    simulator1.ItemNo = poName1.ItemNo;
                                    simulator1.Suffix = poName1.Suffix;
                                    simulator1.Model = poName1.tat;
                                    simulator1.Seq = poName1.no.Value;
                                    simulator1.PO = poName1.PONumber;
                                    simulator1.PO_Qty = poName1.PO_Qty;
                                    simulator1.PO_Balance = poName1.PoBalance;
                                    if (simulator1.PO_Balance > newCapacity)
                                    {
                                        simulator1.Quota = newCapacity;
                                        poName1.PoBalance = poName1.PoBalance - simulator1.Quota;
                                    }
                                    else if (simulator1.PO_Balance <= newCapacity)
                                    {
                                        canSimulateNewPO = true;

                                        firstRemainingQuantity = simulator1.PO_Balance;
                                        simulator1.Quota = simulator1.PO_Balance;
                                        capacity_Value = newCapacity;
                                        poName1.PoBalance = poName1.PoBalance - simulator1.Quota;
                                    }
                                    simulator1.ShiftName = item.shiftname;
                                    simulator1.ShiftCode = item.ShiftCode;
                                    simulator1.ShiftWorkScheme = item.ShiftWorkScheme;
                                    simulator1.ShiftHours = item.ShiftHours.Value;
                                    simulator1.Line = line;
                                    simulator1.Capacity = newCapacity;
                                    simulator1.DeliveryDate = poName1.DeliveryDate;
                                    simulator1.Status = "Processing";

                                    //shiftDate1.capacity = (simulator1.Quota - shiftDate1.capacity);
                                    new Controllers.Transaction.POSimulationController().InsertSimulator(simulator1);

                                    if (canSimulateNewPO)
                                        goto SimualateNewPO;
                                }
                            }

                            //poName.PoBalance = poName.PoBalance - simulator.Quota;

                            ctrl++;
                        }
                    }
                    else if (line == Util.GlobalConstants.LINE_B)
                    {
                        bool specialCase = false;
                        int firstRemainingQuantity = 0;
                        int capacity_Value = 0;
                        Models.Transaction.Simulator simulator = new Models.Transaction.Simulator();
                        var poName = this._poList.List
                                         .Where(x => x.Line_B == 1
                                                  && x.PoBalance > 0)
                                         .OrderBy(x => x.no)
                                         .FirstOrDefault();

                        if (poName != null)
                        {
                            var shiftDate = capacity.List
                                                  .Where(x => x.CODE.Equals(item.ShiftCode)
                                                           && x.WorkScheme.Equals(item.ShiftWorkScheme)
                                                           && x.Model.Equals(poName.ItemNo)
                                                           && x.Line.Equals(line))
                                                  .FirstOrDefault();

                            if (shiftDate == null) return;

                            simulator.id = ctrl;
                            simulator.version = version;
                            simulator.Date = item.Date;
                            simulator.ItemNo = poName.ItemNo;
                            simulator.Suffix = poName.Suffix;
                            simulator.Model = poName.tat;
                            simulator.Seq = poName.no.Value;
                            simulator.PO = poName.PONumber;
                            simulator.PO_Qty = poName.PO_Qty;
                            simulator.PO_Balance = poName.PoBalance;
                            if (simulator.PO_Balance > shiftDate.capacity)
                            {
                                simulator.Quota = shiftDate.capacity;
                                poName.PoBalance = poName.PoBalance - simulator.Quota;
                            }
                            else if (simulator.PO_Balance <= shiftDate.capacity)
                            {
                                specialCase = true;

                                firstRemainingQuantity = simulator.PO_Balance;
                                simulator.Quota = simulator.PO_Balance;
                                capacity_Value = shiftDate.capacity;
                                poName.PoBalance = poName.PoBalance - simulator.Quota;
                            }

                            simulator.ShiftName = item.shiftname;
                            simulator.ShiftCode = item.ShiftCode;
                            simulator.ShiftWorkScheme = item.ShiftWorkScheme;
                            simulator.ShiftHours = item.ShiftHours.Value;
                            simulator.Line = line;
                            simulator.Capacity = shiftDate.capacity;
                            simulator.DeliveryDate = poName.DeliveryDate;
                            simulator.Status = "Processing";
                            //shiftDate.capacity = (simulator.Quota - shiftDate.capacity);

                            new Controllers.Transaction.POSimulationController().InsertSimulator(simulator);

                        SimualateNewPO:
                            if (specialCase)
                            {
                                ctrl++;
                                //hourlyRate = capacity/ shifthours
                                //double firstHourlyRate = Convert.ToDouble(shiftDate.capacity) / Convert.ToDouble(item.ShiftHours);
                                double firstHourlyRate = Convert.ToDouble(capacity_Value) / Convert.ToDouble(item.ShiftHours);
                                //remainingHours = shiftHours - firstHourlyRate
                                double firstRemainingHours = Convert.ToDouble(item.ShiftHours) - (Convert.ToDouble(firstRemainingQuantity) / firstHourlyRate);

                                var poName1 = this._poList.List
                                                     .Where(x => x.Line_B == 1
                                                              && x.PoBalance > 0)
                                                     .OrderBy(x => x.no)
                                                     .FirstOrDefault();
                                if (poName1 != null)
                                {
                                    var shiftDate1 = capacity.List
                                                        .Where(x => x.CODE.Equals(item.ShiftCode)
                                                                 && x.WorkScheme.Equals(item.ShiftWorkScheme)
                                                                 && x.Model.Equals(poName1.ItemNo)
                                                                 && x.Line.Equals(line))
                                                        .FirstOrDefault();

                                    if (shiftDate1 == null) return;

                                    int qoutaPerHour = Convert.ToInt32(Convert.ToDouble(shiftDate1.capacity) / Convert.ToDouble(item.ShiftHours));

                                    int newCapacity = Convert.ToInt32(firstRemainingHours * qoutaPerHour);

                                    bool canSimulateNewPO = false;

                                    Models.Transaction.Simulator simulator1 = new Models.Transaction.Simulator();
                                    simulator1.id = ctrl;
                                    simulator1.version = version;
                                    simulator1.Date = item.Date;
                                    simulator1.ItemNo = poName1.ItemNo;
                                    simulator1.Suffix = poName1.Suffix;
                                    simulator1.Model = poName1.tat;
                                    simulator1.Seq = poName1.no.Value;
                                    simulator1.PO = poName1.PONumber;
                                    simulator1.PO_Qty = poName1.PO_Qty;
                                    simulator1.PO_Balance = poName1.PoBalance;
                                    if (simulator1.PO_Balance > newCapacity)
                                    {
                                        simulator1.Quota = newCapacity;
                                        poName1.PoBalance = poName1.PoBalance - simulator1.Quota;
                                    }
                                    else if (simulator1.PO_Balance <= newCapacity)
                                    {
                                        canSimulateNewPO = true;

                                        firstRemainingQuantity = simulator1.PO_Balance;
                                        simulator1.Quota = simulator1.PO_Balance;
                                        capacity_Value = newCapacity;
                                        poName1.PoBalance = poName1.PoBalance - simulator1.Quota;
                                    }
                                    simulator1.ShiftName = item.shiftname;
                                    simulator1.ShiftCode = item.ShiftCode;
                                    simulator1.ShiftWorkScheme = item.ShiftWorkScheme;
                                    simulator1.ShiftHours = item.ShiftHours.Value;
                                    simulator1.Line = line;
                                    simulator1.Capacity = newCapacity;
                                    simulator1.DeliveryDate = poName1.DeliveryDate;
                                    simulator1.Status = "Processing";

                                    //shiftDate1.capacity = (simulator1.Quota - shiftDate1.capacity);
                                    new Controllers.Transaction.POSimulationController().InsertSimulator(simulator1);

                                    if (canSimulateNewPO)
                                        goto SimualateNewPO;
                                }

                                //poName.PoBalance = poName.PoBalance - simulator.Quota;
                            }
                            ctrl++;
                        }
                    }
                }
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Util.MessageUtil.ShowInfo("Done", Util.Messages.SUCCESS_TITLE);
            this.btnExportToExcel.Enabled = true;
            this.dataGridView1.Rows.Clear();
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.btnExportToExcel.Tag == null)
                {
                    Util.MessageUtil.ShowWarning("No process found!.", Util.Messages.WARNING_TITLE);
                    return;
                }

                int version = (int)this.btnExportToExcel.Tag;
                DataTable simulationData = new Controllers.Transaction.POSimulationController().GetSimulationData(version);

                //this.pbDataGridView1.DataSource = simulationData;

                Models.Transaction.Report_Simulation_for_POBalanceList poBalanceList = new Controllers.Transaction.POSimulationController().GetReport_Simulation_for_POBalance(version);

                if (!string.IsNullOrEmpty(poBalanceList.Error))
                {
                    Util.MessageUtil.ShowError(poBalanceList.Error, string.Format(Util.Messages.ERROR_FOUND, ""));
                    return;
                }

                Models.Transaction.ModelList modelList = new Controllers.Transaction.POSimulationController().GetModel();

                if (!string.IsNullOrEmpty(modelList.Error))
                {
                    Util.MessageUtil.ShowError(modelList.Error, string.Format(Util.Messages.ERROR_FOUND, ""));
                    return;
                }

                List<Tuple<DateTime, string, int>> workScheme_and_shifting = new Controllers.Transaction.POSimulationController().Get_WS_Shifting(Util.GlobalConstants.RT1);

                var simulationOutput = new Controllers.Transaction.POSimulationController().GetPlanOutput(version).ToList();

                if (!this.bgw_Export_To_Excel.IsBusy)
                {
                    object[] data = { simulationData, workScheme_and_shifting, poBalanceList, modelList, simulationOutput };
                    this.bgw_Export_To_Excel.RunWorkerAsync(data);
                }

            }
            catch (Exception ex)
            {
                Util.MessageUtil.ShowError(ex.Message, Util.Messages.ERROR_TITLE);
            }
        }

        private string CellAddress(Excel._Worksheet worksheet, int row, int col)
        {
            Excel.Range rng = worksheet.Cells[row, col];
            return rng.get_AddressLocal(false, false, Excel.XlReferenceStyle.xlA1);
        }

        private void WorkSheet1(Excel.Workbook workbook, Excel.Application excelApp, object misValue, object argument)
        {

            Excel.Worksheet worksheet = workbook.Sheets.Add(misValue, misValue, 1, misValue) as Excel.Worksheet;
            worksheet.Name = "Simulation";
            excelApp.Windows.Application.ActiveWindow.DisplayGridlines = false;

            object[] data = argument as object[];
            DataTable dt = data[0] as DataTable;
            List<Tuple<DateTime, string, int>> workScheme_Shifting = data[1] as List<Tuple<DateTime, string, int>>;
            Models.Transaction.Report_Simulation_for_POBalanceList poBalance = data[2] as Models.Transaction.Report_Simulation_for_POBalanceList;
            Models.Transaction.ModelList model = data[3] as Models.Transaction.ModelList;
            List<EntitiesServices.DB.Simulator_PlanOutput> simulator_PlanOutput = data[4] as List<EntitiesServices.DB.Simulator_PlanOutput>;

            var xFactoryList = poBalance.List.Where(x => x.XX_Factory.HasValue).ToList();
            var xFactory_Reply3List = poBalance.List.Where(x => x.Reply3.HasValue).ToList();

            int col_Start = 2;
            int col_Index = col_Start;
            int row_Index = 20;
            int line_A_Index = 0;
            int line_B_Index = 0;

            worksheet.Cells[1, col_Index] = "RT1 PRODUCTION " + DateTime.Now.ToString("MMM dd, yyyy");
            worksheet.Cells[1, col_Index].Font.Bold = true;
            worksheet.Cells[1, col_Index].Font.Size = 22;

            worksheet.Cells[2, col_Index + 17] = "Pres";
            worksheet.Cells[2, col_Index + 17].Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = 3d;
            worksheet.Cells[2, col_Index + 17].Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = 3d;
            worksheet.Cells[2, col_Index + 18] = "PMD";
            worksheet.Cells[2, col_Index + 18].Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = 3d;
            worksheet.Cells[2, col_Index + 19] = "RT1";
            worksheet.Cells[2, col_Index + 19].Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = 3d;
            worksheet.Cells[2, col_Index + 19].Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = 3d;

            worksheet.Cells[3, col_Index + 17] = "GM";
            worksheet.Cells[3, col_Index + 17].Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = 2d;
            worksheet.Cells[3, col_Index + 17].Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = 2d;
            worksheet.Cells[3, col_Index + 17].Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = 3d;
            worksheet.Cells[3, col_Index + 18] = "QMD";
            worksheet.Cells[3, col_Index + 18].Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = 2d;
            worksheet.Cells[3, col_Index + 18].Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = 2d;
            worksheet.Cells[3, col_Index + 19] = "PCD";
            worksheet.Cells[3, col_Index + 19].Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = 2d;
            worksheet.Cells[3, col_Index + 19].Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = 2d;
            worksheet.Cells[3, col_Index + 19].Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = 3d;

            worksheet.Cells[4, col_Index + 17] = "AGM";
            worksheet.Cells[4, col_Index + 17].Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = 3d;
            worksheet.Cells[4, col_Index + 17].Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = 3d;
            worksheet.Cells[4, col_Index + 18] = "TD";
            worksheet.Cells[4, col_Index + 18].Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = 3d;
            worksheet.Cells[4, col_Index + 19] = "RIM";
            worksheet.Cells[4, col_Index + 19].Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = 3d;
            worksheet.Cells[4, col_Index + 19].Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = 3d;


            worksheet.Range[worksheet.Cells[2, 22], worksheet.Cells[3, 24]].Merge();
            worksheet.Range[worksheet.Cells[2, 22], worksheet.Cells[3, 24]].Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = 3d;
            worksheet.Range[worksheet.Cells[2, 25], worksheet.Cells[3, 27]].Merge();
            worksheet.Range[worksheet.Cells[2, 25], worksheet.Cells[3, 27]].Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = 3d;
            worksheet.Range[worksheet.Cells[2, 25], worksheet.Cells[3, 27]].Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = 3d;
            worksheet.Range[worksheet.Cells[2, 25], worksheet.Cells[3, 27]].Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = 3d;
            worksheet.Range[worksheet.Cells[2, 28], worksheet.Cells[3, 30]].Merge();
            worksheet.Range[worksheet.Cells[2, 28], worksheet.Cells[3, 30]].Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = 3d;
            worksheet.Range[worksheet.Cells[2, 28], worksheet.Cells[3, 30]].Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = 3d;
            worksheet.Range[worksheet.Cells[2, 28], worksheet.Cells[3, 30]].Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = 3d;
            worksheet.Range[worksheet.Cells[2, 31], worksheet.Cells[3, 33]].Merge();
            worksheet.Range[worksheet.Cells[2, 31], worksheet.Cells[3, 33]].Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = 3d;
            worksheet.Range[worksheet.Cells[2, 31], worksheet.Cells[3, 33]].Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = 3d;

            worksheet.Range[worksheet.Cells[4, 22], worksheet.Cells[4, 24]].Merge();
            worksheet.Range[worksheet.Cells[4, 22], worksheet.Cells[4, 24]] = "Mr. Izumi, T.";
            worksheet.Range[worksheet.Cells[4, 22], worksheet.Cells[4, 24]].Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = 2d;
            worksheet.Range[worksheet.Cells[4, 22], worksheet.Cells[4, 24]].Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = 3d;
            worksheet.Range[worksheet.Cells[4, 25], worksheet.Cells[4, 27]].Merge();
            worksheet.Range[worksheet.Cells[4, 25], worksheet.Cells[4, 27]] = "Mr. Manacap, J";
            worksheet.Range[worksheet.Cells[4, 25], worksheet.Cells[4, 27]].Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = 2d;
            worksheet.Range[worksheet.Cells[4, 25], worksheet.Cells[4, 27]].Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = 3d;
            worksheet.Range[worksheet.Cells[4, 25], worksheet.Cells[4, 27]].Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = 3d;
            worksheet.Range[worksheet.Cells[4, 25], worksheet.Cells[4, 27]].Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = 3d;
            worksheet.Range[worksheet.Cells[4, 28], worksheet.Cells[4, 30]].Merge();
            worksheet.Range[worksheet.Cells[4, 28], worksheet.Cells[4, 30]] = "Ms. Bayles, E.";
            worksheet.Range[worksheet.Cells[4, 28], worksheet.Cells[4, 30]].Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = 2d;
            worksheet.Range[worksheet.Cells[4, 28], worksheet.Cells[4, 30]].Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = 3d;
            worksheet.Range[worksheet.Cells[4, 28], worksheet.Cells[4, 30]].Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = 3d;
            worksheet.Range[worksheet.Cells[4, 31], worksheet.Cells[4, 33]].Merge();
            worksheet.Range[worksheet.Cells[4, 31], worksheet.Cells[4, 33]] = "Ms. Dagohoy, JR.";
            worksheet.Range[worksheet.Cells[4, 31], worksheet.Cells[4, 33]].Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = 2d;
            worksheet.Range[worksheet.Cells[4, 31], worksheet.Cells[4, 33]].Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = 3d;
            worksheet.Range[worksheet.Cells[4, 31], worksheet.Cells[4, 33]].Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = 3d;

            worksheet.Cells[2, col_Index] = "Revision";
            worksheet.Cells[3, col_Index] = "Consideration:";
            worksheet.Cells[3, col_Index + 5] = "Consideration:";

            worksheet.Cells[4, col_Index] = "Working Schedule:";
            worksheet.Cells[5, col_Index] = "Customer Order:";
            worksheet.Cells[6, col_Index] = "JPN PO Version:";
            worksheet.Cells[7, col_Index] = "HK PO Version:";

            #region
            //Header columns
            worksheet.Cells[row_Index, col_Index + 3].ColumnWidth = 12; //LINE Width
            worksheet.Cells[row_Index, col_Index + 2].ColumnWidth = 15; //Model Width
            worksheet.Cells[row_Index, col_Index + 1].ColumnWidth = 5; //LINE Width
            Excel.Range range = excelApp.get_Range(this.CellAddress(worksheet, row_Index - 3, col_Index + 4), this.CellAddress(worksheet, row_Index - 2, dt.Columns.Count + 1));

            range.NumberFormat = Util.GlobalConstants.MMDD;
            range.Font.Size = 9;
            range.ColumnWidth = 6;
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            range.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlDot;
            range.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlDot;
            range.Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlMedium;
            range.Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlMedium;
            range.Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = Excel.XlBorderWeight.xlMedium;
            range.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;

            //Header columns
            range = excelApp.get_Range(this.CellAddress(worksheet, row_Index - 1, col_Index + 4), this.CellAddress(worksheet, row_Index, dt.Columns.Count + 1));

            range.Font.Size = 9;
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            range.Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlMedium;
            range.Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = Excel.XlBorderWeight.xlMedium;

            //details
            range = excelApp.get_Range(this.CellAddress(worksheet, row_Index + 1, col_Index + 4), this.CellAddress(worksheet, dt.Rows.Count + row_Index, dt.Columns.Count + 1));

            //range.NumberFormat = Util.GlobalConstants.MMDD;
            range.Font.Size = 9;
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            range.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlDot;
            range.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlDot;
            range.Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlMedium;
            range.Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlMedium;
            range.Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = Excel.XlBorderWeight.xlMedium;
            range.Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlMedium;

            //details _Header
            range = excelApp.get_Range(this.CellAddress(worksheet, row_Index + 1, col_Index), this.CellAddress(worksheet, dt.Rows.Count + row_Index, 5));

            //range.NumberFormat = Util.GlobalConstants.MMDD;
            range.Font.Size = 9;
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            range.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlDot;
            range.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlDot;
            range.Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlMedium;
            range.Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlMedium;
            range.Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = Excel.XlBorderWeight.xlMedium;
            range.Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlMedium;

            //Header Sum value

            range = excelApp.get_Range(this.CellAddress(worksheet, row_Index - 7, col_Index + 4), this.CellAddress(worksheet, row_Index - 5, dt.Columns.Count + 1));
            range.Font.Size = 9;
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            range.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlDot;
            range.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlDot;
            range.Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlMedium;
            range.Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlMedium;
            range.Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = Excel.XlBorderWeight.xlMedium;
            range.Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlMedium;
            #endregion

            #region HEADER
            foreach (DataColumn col in dt.Columns)
            {
                DateTime date;
                if (DateTime.TryParse(col.ColumnName.ToString(), out date))
                {
                    string list_of_Range_LineA = string.Format("{0}:{1}", this.CellAddress(worksheet, row_Index + 1, line_A_Index), this.CellAddress(worksheet, dt.Rows.Count + row_Index, line_A_Index));
                    string list_of_Sum_Range_LineA = string.Format("{0}:{1}", this.CellAddress(worksheet, row_Index + 1, col_Index), this.CellAddress(worksheet, dt.Rows.Count + row_Index, col_Index));

                    string list_of_Range_LineB = string.Format("{0}:{1}", this.CellAddress(worksheet, row_Index + 1, line_A_Index), this.CellAddress(worksheet, dt.Rows.Count + row_Index, line_B_Index));
                    string list_of_Sum_Range_LineB = string.Format("{0}:{1}", this.CellAddress(worksheet, row_Index + 1, col_Index), this.CellAddress(worksheet, dt.Rows.Count + row_Index, col_Index));

                    worksheet.Cells[row_Index - 7, col_Index] = string.Format("=SUMIF({0},{1},{2})", list_of_Range_LineA, this.CellAddress(worksheet, row_Index - 7, line_A_Index), list_of_Sum_Range_LineA);
                    worksheet.Cells[row_Index - 6, col_Index] = string.Format("=SUMIF({0},{1},{2})", list_of_Range_LineB, this.CellAddress(worksheet, row_Index - 6, line_B_Index), list_of_Sum_Range_LineB);
                    worksheet.Cells[row_Index - 5, col_Index] = string.Format("=SUM({0}:{1})", this.CellAddress(worksheet, row_Index - 7, col_Index), this.CellAddress(worksheet, row_Index - 6, col_Index));

                    //Console.WriteLine(dateTime);
                    worksheet.Cells[row_Index - 3, col_Index] = col.ColumnName.ToString();
                    worksheet.Cells[row_Index - 2, col_Index] = string.Format("={0}", this.CellAddress(worksheet, row_Index - 3, col_Index));
                    worksheet.Cells[row_Index - 2, col_Index].NumberFormat = Util.GlobalConstants.DDD;

                    var ws_shifting = workScheme_Shifting.Where(x => x.Item1.Date.Date.Equals(date.Date)).FirstOrDefault();
                    worksheet.Cells[row_Index - 1, col_Index] = ws_shifting == null ? "0" : ws_shifting.Item2;
                    worksheet.Cells[row_Index, col_Index] = ws_shifting == null ? 0 : ws_shifting.Item3;
                }
                else
                {
                    worksheet.Cells[row_Index, col_Index] = col.ColumnName.ToString();
                    if (col.ColumnName == "Line")
                    {
                        worksheet.Cells[row_Index - 7, col_Index - 1] = col.ColumnName;
                        worksheet.Cells[row_Index - 6, col_Index - 1] = col.ColumnName;

                        worksheet.Cells[row_Index - 7, col_Index] = Util.GlobalConstants.LINE_A;
                        worksheet.Cells[row_Index - 6, col_Index] = Util.GlobalConstants.LINE_B;
                        worksheet.Cells[row_Index, col_Index] = "SHIFT";
                        worksheet.Cells[row_Index - 1, col_Index] = "WS";
                        worksheet.Cells[row_Index - 2, col_Index] = "DAY";
                        worksheet.Cells[row_Index - 3, col_Index] = "DATE";
                        line_A_Index = col_Index;
                        line_B_Index = col_Index;
                    }
                }
                col_Index++;
            }
            #endregion

            #region Detail Value

            string[] column_Color_To_White = { Util.GlobalConstants.LINE_B, "PLAN OUTPUT", "PLAN SHIPMENT" };

            foreach (DataRow row in dt.Rows)
            {
                row_Index++;
                col_Index = col_Start;
                foreach (DataColumn col in dt.Columns)
                {
                    DateTime date;

                    //worksheet.Cells[row_Index, col_Index] = row[col.ColumnName].ToString();

                    //date of all item
                    if (DateTime.TryParse(col.ColumnName.ToString(), out date))
                    {
                        if (row["Line"].ToString() == "PLAN OUTPUT")
                        {

                            int planOutPut_Sum = simulator_PlanOutput.Where(x => x.Date.Date.Equals(date)
                                                                    && x.ItemNo.Equals(row["ItemNo"].ToString())
                                                                    && x.Suffix.Equals(row["Suffix"].ToString()))
                                                            .Sum(x => x.Quota);

                            //Nullable<int> productionLT = model.List
                            //                                  .Where(x => x.rinks_no.Equals(row["ItemNo"].ToString())
                            //                                           && x.tat.Equals(row["model"].ToString()))
                            //                                  .FirstOrDefault().Production_LT;

                            //string planOutPut_Sum = string.Format("=SUM({0}+{1})", this.CellAddress(worksheet, row_Index - 2, col_Index), this.CellAddress(worksheet, row_Index - 1, col_Index));
                            //worksheet.Cells[row_Index, col_Index + (productionLT.HasValue ? productionLT.Value : 0)] = planOutPut_Sum;// planOutPut_Sum;
                            //worksheet.Cells[row_Index, col_Index + (productionLT.HasValue ? productionLT.Value : 0)].NumberFormat = "0;-0;;@";


                            worksheet.Cells[row_Index, col_Index] = planOutPut_Sum.ToString("#,##0");// planOutPut_Sum;
                            worksheet.Cells[row_Index, col_Index].NumberFormat = "0;-0;;@";

                        }
                        else if (row["Line"].ToString() == "PLAN SHIPMENT")
                        {
                            var xFactory_Data = xFactoryList
                                                .Where(x => x.XX_Factory.Value.Date == DateTime.Parse(col.ColumnName).Date
                                                         && x.ItemNo.Equals(row["ItemNo"].ToString())
                                                         && x.XX_Factory_QTY.HasValue)
                                                .ToList();

                            if (xFactory_Data != null)
                            {
                                if (xFactory_Data.Sum(x => x.XX_Factory_QTY) > 0)
                                    worksheet.Cells[row_Index, col_Index] = xFactory_Data.Sum(x => x.XX_Factory_QTY);//xFactory_Data.Sum(x => x.XX_Factory_QTY).HasValue ? xFactory_Data.Sum(x => x.XX_Factory_QTY).Value.ToString("#,##0") : "";
                                //if (xFactory_Data.XX_Factory_QTY.Value > 0)
                                //    worksheet.Cells[row_Index, col_Index] = xFactory_Data.XX_Factory_QTY.Value;
                            }

                            var xFactory_Reply3_Data = xFactory_Reply3List
                                                       .Where(x => x.Reply3.Value.Date == DateTime.Parse(col.ColumnName).Date
                                                                && x.ItemNo.Equals(row["ItemNo"].ToString())
                                                                && x.Reply3_QTY.HasValue)
                                                       .ToList();

                            if (xFactory_Reply3_Data != null)
                            {
                                if (xFactory_Reply3_Data.Sum(x => x.Reply3_QTY) > 0)
                                    worksheet.Cells[row_Index, col_Index] = xFactory_Reply3_Data.Sum(x => x.Reply3_QTY);
                            }
                        }
                        else
                        {
                            worksheet.Cells[row_Index, col_Index] = row[col.ColumnName].ToString();
                        }
                    }
                    else // name of ITEM P
                    {
                        worksheet.Cells[row_Index, col_Index] = row[col.ColumnName].ToString();
                    }

                    if (column_Color_To_White.Contains(row[col.ColumnName].ToString()) && col.ColumnName == "Line")
                    {
                        if (row["Line"].ToString() == "PLAN OUTPUT")
                        {
                            string rangeFormat = string.Format("{0}:{1}", this.CellAddress(worksheet, row_Index, col_Index + 1), this.CellAddress(worksheet, row_Index, dt.Columns.Count + 1));
                            Microsoft.Office.Interop.Excel.FormatCondition format = (Microsoft.Office.Interop.Excel.FormatCondition)worksheet.get_Range(rangeFormat, Type.Missing).FormatConditions.Add(Microsoft.Office.Interop.Excel.XlFormatConditionType.xlCellValue, Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlGreaterEqual, "1", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                            format.Font.Color = Color.White;
                            format.Font.Bold = true;
                            format.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                        }
                        else if (row["Line"].ToString() == "PLAN SHIPMENT")
                        {
                            string rangeFormat = string.Format("{0}:{1}", this.CellAddress(worksheet, row_Index, col_Index + 1), this.CellAddress(worksheet, row_Index, dt.Columns.Count + 1));
                            Microsoft.Office.Interop.Excel.FormatCondition format = (Microsoft.Office.Interop.Excel.FormatCondition)worksheet.get_Range(rangeFormat, Type.Missing).FormatConditions.Add(Microsoft.Office.Interop.Excel.XlFormatConditionType.xlCellValue, Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlGreaterEqual, "1", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                            //format.Font.Color = Color.bal;
                            format.Font.Bold = true;
                            format.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                            worksheet.get_Range(rangeFormat, Type.Missing).Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlMedium;
                        }

                        worksheet.Cells[row_Index, col_Index - 1].Font.Color = System.Drawing.Color.FromArgb(255, 255, 255);
                        worksheet.Cells[row_Index, col_Index - 2].Font.Color = System.Drawing.Color.FromArgb(255, 255, 255);
                        worksheet.Cells[row_Index, col_Index - 3].Font.Color = System.Drawing.Color.FromArgb(255, 255, 255);
                    }
                    col_Index++;
                }
            }
            #endregion

            this.releaseObject(worksheet);
        }

        private void WorkSheet2(Excel.Workbook workbook, Excel.Application excelApp, object misValue, object argument)
        {
            Excel.Worksheet worksheet = workbook.Sheets.Add(misValue, misValue, 1, misValue) as Excel.Worksheet;
            excelApp.Windows.Application.ActiveWindow.DisplayGridlines = false;
            worksheet.Name = "DELIVERY REPLY";

            object[] data = argument as object[];
            Models.Transaction.Report_Simulation_for_POBalanceList poBalance = data[2] as Models.Transaction.Report_Simulation_for_POBalanceList;

            int rowIndex = 8;

            worksheet.Cells[1, 2] = "RT1 PO BALANCE UPDATED DELIVERY PLAN: ";
            worksheet.Cells[1, 2].Font.Size = 20;
            worksheet.Cells[2, 2] = "Date";
            worksheet.Cells[3, 2] = "LATEST PO ISSUED:";
            worksheet.Cells[3, 2].Font.Bold = true;
            worksheet.Cells[4, 2] = "JPN";
            worksheet.Cells[5, 2] = "HK";

            worksheet.Cells[7, 4] = "CUSTOMER INFORMATION";
            worksheet.Cells[7, 4].Font.Bold = true;

            Excel.Range range = excelApp.get_Range(this.CellAddress(worksheet, rowIndex, 1), this.CellAddress(worksheet, poBalance.List.Count() + 8, 8));
            range.Borders[Excel.XlBordersIndex.xlInsideHorizontal].Weight = Excel.XlBorderWeight.xlThin;
            range.Borders[Excel.XlBordersIndex.xlInsideVertical].Weight = Excel.XlBorderWeight.xlThin;
            range.Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlThin;
            range.Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlThin;
            range.Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = Excel.XlBorderWeight.xlThin;
            range.Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlThin;

            range = excelApp.get_Range(this.CellAddress(worksheet, rowIndex, 10), this.CellAddress(worksheet, poBalance.List.Count() + 8, 14));
            range.Borders[Excel.XlBordersIndex.xlInsideHorizontal].Weight = Excel.XlBorderWeight.xlThin;
            range.Borders[Excel.XlBordersIndex.xlInsideVertical].Weight = Excel.XlBorderWeight.xlThin;
            range.Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlThin;
            range.Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlThin;
            range.Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = Excel.XlBorderWeight.xlThin;
            range.Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlThin;

            range = excelApp.get_Range(this.CellAddress(worksheet, rowIndex, 16), this.CellAddress(worksheet, poBalance.List.Count() + 8, 19));
            range.Borders[Excel.XlBordersIndex.xlInsideHorizontal].Weight = Excel.XlBorderWeight.xlThin;
            range.Borders[Excel.XlBordersIndex.xlInsideVertical].Weight = Excel.XlBorderWeight.xlThin;
            range.Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlThin;
            range.Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlThin;
            range.Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = Excel.XlBorderWeight.xlThin;
            range.Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlThin;


            worksheet.Cells[rowIndex, 1] = "SEQ";
            worksheet.Cells[rowIndex, 2] = "PO";
            worksheet.Cells[rowIndex, 2].ColumnWidth = 20;
            worksheet.Cells[rowIndex, 3] = "Item No";
            worksheet.Cells[rowIndex, 3].ColumnWidth = 10;

            worksheet.Cells[rowIndex, 4] = "Suffix";
            worksheet.Cells[rowIndex, 4].ColumnWidth = 7;

            worksheet.Cells[rowIndex, 5] = "Model";
            worksheet.Cells[rowIndex, 5].ColumnWidth = 15;

            worksheet.Cells[rowIndex, 6] = "Destination";
            worksheet.Cells[rowIndex, 6].ColumnWidth = 11;

            worksheet.Cells[rowIndex, 7] = "PO_Qty";
            worksheet.Cells[rowIndex, 8] = "Due Date";
            worksheet.Cells[rowIndex, 8].ColumnWidth = 10;

            worksheet.Cells[rowIndex, 10] = "Ex-Factory";
            worksheet.Cells[rowIndex, 10].ColumnWidth = 10;

            worksheet.Cells[rowIndex, 11] = "Quantity";
            worksheet.Cells[rowIndex, 11].ColumnWidth = 8;
            worksheet.Cells[rowIndex, 12] = "Status";
            worksheet.Cells[rowIndex, 12].ColumnWidth = 8;

            worksheet.Cells[rowIndex, 13] = "DIFFERENCE";
            worksheet.Cells[rowIndex, 13].ColumnWidth = 11;

            worksheet.Cells[rowIndex, 14] = "CUSTOMER's REPLY";
            worksheet.Cells[rowIndex, 14].ColumnWidth = 17;

            worksheet.Cells[rowIndex, 16] = "Ex-Factory";
            worksheet.Cells[rowIndex, 16].ColumnWidth = 10;

            worksheet.Cells[rowIndex, 17] = "QUANTITY";
            worksheet.Cells[rowIndex, 17].ColumnWidth = 8;

            worksheet.Cells[rowIndex, 18] = "DIFFERENCE";
            worksheet.Cells[rowIndex, 18].ColumnWidth = 11;
            worksheet.Cells[rowIndex, 19] = "CUSTOMER's REPLY";
            worksheet.Cells[rowIndex, 19].ColumnWidth = 17;

            foreach (Models.Transaction.Report_Simulation_for_POBalance result in poBalance.List)
            {
                rowIndex++;

                //Sheet.Cells[string.Format("A{0}", rows)]

                worksheet.Cells[rowIndex, 1] = result.Seq;
                worksheet.Cells[rowIndex, 2] = result.PO;
                worksheet.Cells[rowIndex, 3] = result.ItemNo;
                worksheet.Cells[rowIndex, 4] = result.Suffix;
                worksheet.Cells[rowIndex, 5] = result.Model;
                worksheet.Cells[rowIndex, 6] = result.Destination;
                worksheet.Cells[rowIndex, 7] = result.PO_Qty.ToString("#,##0");
                worksheet.Cells[rowIndex, 8] = result.X_Factory;
                worksheet.Cells[rowIndex, 10] = result.XX_Factory;
                worksheet.Cells[rowIndex, 11] = result.XX_Factory_QTY.HasValue ? result.XX_Factory_QTY.Value.ToString("#,##0") : "";
                worksheet.Cells[rowIndex, 12] = "=" + string.Format("H{0}", rowIndex) + "-" + string.Format("J{0}", rowIndex);
                worksheet.Cells[rowIndex, 13] = "=" + string.Format("G{0}", rowIndex) + "-" + string.Format("K{0}", rowIndex); // result.Difference;
                worksheet.Cells[rowIndex, 14] = result.Customer_Reply;
                worksheet.Cells[rowIndex, 16] = result.Reply3;
                worksheet.Cells[rowIndex, 17] = result.Reply3_QTY.HasValue ? result.Reply3_QTY.Value.ToString("#,##0") : "";
                worksheet.Cells[rowIndex, 18] = "=" + string.Format("H{0}", rowIndex) + "-" + string.Format("P{0}", rowIndex);//result.Difference_1;
                worksheet.Cells[rowIndex, 19] = result.Customer_Reply_1;

            }

            this.releaseObject(worksheet);
        }

        private void bgw_Export_To_Excel_DoWork(object sender, DoWorkEventArgs e)
        {
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Workbooks workbooks = null;

            excelApp = new Excel.Application();
            //Excel._Worksheet worksheet = null;
            workbooks = excelApp.Workbooks;
            workbook = workbooks.Add(1);
            //worksheet = (Excel.Worksheet)workbook.Sheets[1];
            excelApp.Windows.Application.ActiveWindow.DisplayGridlines = false;
            excelApp.Visible = true;
            //worksheet.Name = "Simulation";
            object misValue = System.Reflection.Missing.Value;

            this.WorkSheet1(workbook, excelApp, misValue, e.Argument);

            this.WorkSheet2(workbook, excelApp, misValue, e.Argument);

            //excelApp.Quit();


            this.releaseObject(workbook);
            this.releaseObject(excelApp);
        }

        private void bgw_Export_To_Excel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

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
                System.Windows.Forms.MessageBox.Show("Exception Occured while releasing object " + ex.ToString().Trim());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void frmSimulatePO_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.backgroundWorker1.IsBusy)
            {
                Util.MessageUtil.ShowWarning("The simulation is running \n please wait until finished.", string.Format(Util.Messages.ERROR_FOUND, ""));
                e.Cancel = true;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (this.dataGridView1.RowCount > 0)
            {
                string searchValue = txtSearch.Text;

                this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                try
                {
                    foreach (DataGridViewRow row in this.dataGridView1.Rows)
                    {
                        if (row.Cells["colPONo"].Value.ToString().Contains(searchValue) || row.Cells["colItemNo"].Value.ToString().Contains(searchValue))
                        {
                            row.Selected = true;
                            this.dataGridView1.CurrentCell = this.dataGridView1[0, row.Index];
                            break;
                        }
                        else
                        {
                            row.Selected = false;
                        }
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }

            }
        }

        private void ChangeNo(int rowIndex, int no)
        {
            string poNo = this.dataGridView1.Rows[rowIndex].Cells[this.colPONo.Index].Value.ToString();
            string itemNo = this.dataGridView1.Rows[rowIndex].Cells[this.colItemNo.Index].Value.ToString();
            string suffix = this.dataGridView1.Rows[rowIndex].Cells[this.colSuffix.Index].Value.ToString();
            string model = this.dataGridView1.Rows[rowIndex].Cells[this.colModel.Index].Value.ToString();
            string poNumber = this.dataGridView1.Rows[rowIndex].Cells[this.colPONo.Index].Value.ToString();
            int deliveryDate = int.Parse(this.dataGridView1.Rows[rowIndex].Cells[this.colDeliveryDate.Index].Value.ToString());
            var poName = this._poList.List
                                     .Where(x => x.PONumber.Equals(poNo)
                                              && x.ItemNo.Equals(itemNo)
                                              && x.Suffix.Equals(suffix)
                                              && x.tat.Equals(model)
                                              && x.PONumber.Equals(poNumber)
                                              && x.DeliveryDate.Equals(deliveryDate))
                                     .OrderBy(x => x.no)
                                     .FirstOrDefault();
            poName.no = no;// int.Parse(this.dataGridView1.Rows[rowIndex].Cells[this.colNo.Index].Value.ToString());
            this.dataGridView1.Rows[rowIndex].Cells[this.colNo.Index].Value = no;
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                //if (dataGridView1.SelectedRows.Count > 0)
                //{
                int rowCount = dataGridView1.Rows.Count;
                int index = dataGridView1.SelectedCells[0].OwningRow.Index;
                
                
                if (index == 0)
                {
                    return;
                }
                DataGridViewRowCollection rows = dataGridView1.Rows;
                
                // remove the previous row and add it behind the selected row.
                DataGridViewRow prevRow = rows[index - 1];
                int currentRow_Index = int.Parse(this.dataGridView1.Rows[index].Cells[this.colNo.Index].Value.ToString());
                int previousRow_Index = int.Parse(prevRow.Cells[this.colNo.Index].Value.ToString());
               
                this.ChangeNo(index, previousRow_Index);               
                this.ChangeNo(prevRow.Index, currentRow_Index);




                rows.Remove(prevRow);
                prevRow.Frozen = false;
                rows.Insert(index, prevRow);
                dataGridView1.ClearSelection();
                dataGridView1.Rows[index - 1].Selected = true;
                //}
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {

            if (dataGridView1.RowCount > 0)
            {
                //if (dataGridView1.SelectedRows.Count > 0)
                //{
                int rowCount = dataGridView1.Rows.Count;
                int index = dataGridView1.SelectedCells[0].OwningRow.Index;

                if (index == (rowCount - 2)) // include the header row
                {
                    return;
                }
                DataGridViewRowCollection rows = dataGridView1.Rows;

                // remove the next row and add it in front of the selected row.
                DataGridViewRow nextRow = rows[index + 1];


                int currentRow_Index = int.Parse(this.dataGridView1.Rows[index].Cells[this.colNo.Index].Value.ToString());
                int nexRow_Index = int.Parse(nextRow.Cells[this.colNo.Index].Value.ToString());

                this.ChangeNo(index, nexRow_Index);
                this.ChangeNo(nextRow.Index, currentRow_Index);

                rows.Remove(nextRow);
                nextRow.Frozen = false;
                rows.Insert(index, nextRow);
                dataGridView1.ClearSelection();
                dataGridView1.Rows[index + 1].Selected = true;
                //}
            }
        }
    }
}