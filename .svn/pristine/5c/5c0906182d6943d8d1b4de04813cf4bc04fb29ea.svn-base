using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.Controllers.Transaction
{
    public class POSimulationController
    {
        public POSimulationController()
        {

        }


        public List<EntitiesServices.DB.Simulator_PlanOutput> GetPlanOutput(int version)
        {
            try
            {
                return new EntitiesServices.EntitiesManager.Tables.Simulator_PlanOutputManager().Simulator().Where(x => x.version.Equals(version)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Models.Transaction.POSimulationList Get_New_PO()
        {
            Models.Transaction.POSimulationList result = new Models.Transaction.POSimulationList();

            try
            {
                result.List = new EntitiesServices.EntitiesManager
                                           .StoredProcedures
                                           .sp_Get_New_PO()
                                           .SP_Get_New_PO()
                                           .ToList()
                                           .Select(x => new Models.Transaction.POSimulationModel()
                                           {
                                               no = x.no,
                                               PONumber = x.PONumber.Trim(),
                                               ItemNo = x.ItemNo.Trim(),
                                               Suffix = x.Suffix.Trim(),
                                               tat = x.tat.Trim(),
                                               destination = x.destination.Trim(),
                                               PoBalance = x.POBalance.Value,
                                               PO_Qty = x.POBalance.Value,
                                               DeliveryDate = x.DeliveryDate,
                                               Remarks = x.Remarks == Util.GlobalConstants.NO_MODEL ? x.Remarks : x.IsCapacity == Util.GlobalConstants.NO_CAPCITY_SETUP ? x.IsCapacity : x.Remarks,
                                               Line_A = x.Line_A,
                                               Line_B = x.Line_B
                                           })
                                           .ToList();
            }
            catch (Exception ex)
            {
                result.Error = ex.Message;
            }

            return result;
        }

        //public Models.Transaction.CapacityPerDateList GetCapacityPerDate()
        //{
        //    Models.Transaction.CapacityPerDateList result = new Models.Transaction.CapacityPerDateList();
        //    try
        //    {
        //        result.List = new EntitiesServices.EntitiesManager
        //                                          .StoredProcedures
        //                                          .sp_GetCapacityPerDate()
        //                                          .SP_GetCapacityPerDate()
        //                                          .Select(x => new Models.Transaction.CapacityPerDate()
        //                                          {
        //                                              Date = x.Date,
        //                                              ShiftCode = x.ShiftCode,
        //                                              ShiftWorkScheme = x.ShiftWorkScheme,
        //                                              ShiftHours = x.ShiftHours.Value,
        //                                              ShiftName = x.ShiftName,
        //                                              Model = x.Model.Trim(),
        //                                              Line = x.Line,
        //                                              TAT = x.Tat,
        //                                              Capacity = x.Capacity,
        //                                          }).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Error = ex.Message;
        //    }

        //    return result;
        //}

        public List<Tuple<DateTime, string, int>> Get_WS_Shifting(string type)
        {
            try
            {
                List<Tuple<DateTime, string, int>> result = new List<Tuple<DateTime, string, int>>();

                result = new EntitiesServices.EntitiesManager
                                             .StoredProcedures
                                             .sp_WorkSchemeAndShifting()
                                             .SP_WorkSchemeAndShifting(type)
                                             .Select(x => new Tuple<DateTime, string, int>(x.date.Date, x.WS, x.SHIFT))
                                             .ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Models.Transaction.CapacityList GetCapacity()
        {
            Models.Transaction.CapacityList result = new Models.Transaction.CapacityList();
            try
            {
                result.List = new EntitiesServices.EntitiesManager
                                                  .Tables
                                                  .CapacityManager()
                                                  .Capacity()
                                                  .Select(x => new Models.Transaction.Capacity()
                                                  {
                                                      INDEX = x.INDEX,
                                                      CODE = x.CODE,
                                                      WorkScheme = x.WorkScheme,
                                                      Model = x.Model,
                                                      Line = x.Line,
                                                      Tat = x.Tat,
                                                      capacity = x.Capacity1.Value
                                                  })
                                                  .ToList();
            }
            catch (Exception ex)
            {
                result.Error = ex.Message;
            }
            return result;
        }

        public Models.Transaction.RT1_Simulation_CalendarList GetCalendar()
        {
            Models.Transaction.RT1_Simulation_CalendarList result = new Models.Transaction.RT1_Simulation_CalendarList();
            try
            {
                result.List = new EntitiesServices.EntitiesManager
                                                  .StoredProcedures
                                                  .sp_RT1Simulation_Calendar()
                                                  .SP_RT1Simulation_Calendar()
                                                  //.ToList()
                                                  .Select(x => new Models.Transaction.RT1_Simulation_Calendar()
                                                  {
                                                      shiftname = x.shiftname,
                                                      Type = x.Type,
                                                      Date = x.Date,
                                                      DayName = x.DayName,
                                                      ShiftCode = x.ShiftCode,
                                                      ShiftWorkScheme = x.ShiftWorkScheme,
                                                      ShiftHours = x.ShiftHours
                                                  }).ToList();

            }
            catch (Exception ex)
            {
                result.Error = ex.Message;
            }
            return result;
        }

        public void InsertSimulator(Models.Transaction.Simulator simulator)
        {
            try
            {
                EntitiesServices.DB.Simulator tblSimulator = new EntitiesServices.DB.Simulator();
                tblSimulator.id = simulator.id;
                tblSimulator.Seq = simulator.Seq;
                tblSimulator.version = simulator.version;
                tblSimulator.Date = simulator.Date;
                tblSimulator.ItemNo = simulator.ItemNo;
                tblSimulator.Suffix = simulator.Suffix;
                tblSimulator.Model = simulator.Model;
                tblSimulator.PO = simulator.PO;
                tblSimulator.PO_Qty = simulator.PO_Qty;
                tblSimulator.POBalance = simulator.PO_Balance;
                tblSimulator.Quota = simulator.Quota;
                tblSimulator.ShiftName = simulator.ShiftName;
                tblSimulator.ShiftCode = simulator.ShiftCode;
                tblSimulator.ShiftWorkScheme = simulator.ShiftWorkScheme;
                tblSimulator.ShiftHours = simulator.ShiftHours;
                tblSimulator.Line = simulator.Line;
                tblSimulator.Capacity = simulator.Capacity;
                tblSimulator.DeliveryDate = simulator.DeliveryDate.Value;
                tblSimulator.Status = simulator.Status;

                new EntitiesServices.EntitiesManager.Tables.SimulatorManager().SaveSimulator(tblSimulator);

                var model = this.GetModel().List.Where(x => x.rinks_no.Trim().Equals(simulator.ItemNo.Trim())).FirstOrDefault();

                //var date = this.GetCalendar().List.Where(x => x.Date.Date> simulator.Date.Date).OrderBy(x=>x.Date).Take((model.Production_LT -1)).LastOrDefault();
                var date = this.GetCalendar().List.Where(x => x.Date.Date > simulator.Date.Date).OrderBy(x => x.Date).Take((model.Production_LT)).LastOrDefault();

                if (date != null)
                {
                    EntitiesServices.DB.Simulator_PlanOutput tblSimulatorOutput = new EntitiesServices.DB.Simulator_PlanOutput();
                    tblSimulatorOutput.id = simulator.id;
                    tblSimulatorOutput.Seq = simulator.Seq;
                    tblSimulatorOutput.version = simulator.version;
                    tblSimulatorOutput.Date = date.Date;
                    tblSimulatorOutput.ItemNo = simulator.ItemNo;
                    tblSimulatorOutput.Suffix = simulator.Suffix;
                    tblSimulatorOutput.Model = simulator.Model;
                    tblSimulatorOutput.PO = simulator.PO;
                    tblSimulatorOutput.PO_Qty = simulator.PO_Qty;
                    tblSimulatorOutput.POBalance = simulator.PO_Balance;
                    tblSimulatorOutput.Quota = simulator.Quota;
                    tblSimulatorOutput.ShiftName = simulator.ShiftName;
                    tblSimulatorOutput.ShiftCode = simulator.ShiftCode;
                    tblSimulatorOutput.ShiftWorkScheme = simulator.ShiftWorkScheme;
                    tblSimulatorOutput.ShiftHours = simulator.ShiftHours;
                    tblSimulatorOutput.Line = simulator.Line;
                    tblSimulatorOutput.Capacity = simulator.Capacity;
                    tblSimulatorOutput.DeliveryDate = simulator.DeliveryDate.Value;
                    tblSimulatorOutput.Status = simulator.Status;

                    new EntitiesServices.EntitiesManager.Tables.Simulator_PlanOutputManager().SaveSimulator(tblSimulatorOutput);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int GetLatestSimulationVersion()
        {
            try
            {
                var data = new EntitiesServices.EntitiesManager.Tables.SimulatorManager().Simulator();// +1;
                if (data.Count() > 0)
                    return data.Max(x => x.version) + 1;
                else
                    return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable GetSimulationData(int version)
        {
            try
            {
                return new EntitiesServices.EntitiesManager.StoredProcedures.sp_GetSimulationData().GetSimulationData(version);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Models.Transaction.Report_Simulation_for_POBalanceList GetReport_Simulation_for_POBalance(int version)
        {
            Models.Transaction.Report_Simulation_for_POBalanceList result = new Models.Transaction.Report_Simulation_for_POBalanceList();
            try
            {
                result.List = new EntitiesServices.EntitiesManager
                                                  .StoredProcedures
                                                  .sp_Report_Simulation_for_POBalance()
                                                  .SP_Report_Simulation_for_POBalance(version)
                                                  .Select(x => new Models.Transaction.Report_Simulation_for_POBalance()
                                                  {
                                                      Seq = x.Seq,
                                                      PO = x.PO,
                                                      ItemNo = x.ItemNo,
                                                      Suffix = x.Suffix,
                                                      Model = x.Model,
                                                      Destination = x.destination,
                                                      PO_Qty = x.PO_Qty,
                                                      X_Factory = x.X_Factory,
                                                      XX_Factory = x.XX_Factory,
                                                      XX_Factory_QTY = x.XX_Factory_QTY,
                                                      Difference = x.DIFFERENCE,
                                                      Customer_Reply = x.CUSTOMERS_REPLY,
                                                      Reply3 = x.Reply3,
                                                      Reply3_QTY = x.Reply3_QTY,

                                                      Difference_1 = x.DIFFERENCE_1,
                                                      Customer_Reply_1 = x.CUSTOMERS_REPLY_1
                                                  })
                                                  .ToList();
            }
            catch(Exception ex)
            {
                result.Error = ex.Message;
            }

            return result;
        }

        public Models.Transaction.ModelList GetModel()
        {
            Models.Transaction.ModelList result = new Models.Transaction.ModelList();
            try
            {
                result.List = new EntitiesServices.EntitiesManager
                                                  .Tables
                                                  .ModelManager()
                                                  .tbl_Model()
                                                  .Select(x => new Models.Transaction.Model()
                                                  {
                                                      model_id = x.model_id,
                                                      rinks_no = x.rinks_no,
                                                      tat = x.tat,
                                                      Production_LT = x.Production_LT.HasValue ? x.Production_LT.Value : 0,
                                                      Shipment_LT = x.Shipment_LT.HasValue ? x.Shipment_LT.Value : 0
                                                  })
                                                  .ToList();
            }
            catch (Exception ex)
            {
                result.Error = ex.Message;
            }

            return result;
        }
    }
}