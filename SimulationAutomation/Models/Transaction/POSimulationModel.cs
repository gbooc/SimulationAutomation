using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.Models.Transaction
{
    public class POSimulationModel
    {
        public virtual Nullable<int> no { get; set; }
        public virtual string PONumber { get; set; }
        public virtual string ItemNo { get; set; }
        public virtual string Suffix { get; set; }
        public virtual string tat { get; set; }
        public virtual string destination { get; set; }
        public virtual Nullable<int> DeliveryDate { get; set; }
        public virtual int PoBalance { get; set; }
        public virtual int PO_Qty { get; set; }
        public virtual string Remarks { get; set; }
        public virtual Nullable<int> Line_A { get; set; }
        public virtual Nullable<int> Line_B { get; set; }
    }

    public class POSimulationList : BaseModel
    {
        public POSimulationList()
        {
            this.List = new List<POSimulationModel>();
        }

        public List<POSimulationModel> List;
    }

    public class Capacity
    {
        public virtual int INDEX { get; set; }
        public virtual string CODE{ get; set; }
        public virtual string WorkScheme{ get; set; }
        public virtual string Model{ get; set; }
        public virtual string Line { get; set; }
        public virtual string Tat{ get; set; }
        public virtual int capacity{ get; set; }
    }

    public class CapacityList : BaseModel
    {
        public CapacityList()
        {
            this.List = new List<Capacity>();
        }

        public List<Capacity> List;
    }

    public class Simulator : LogModel
    {
        public virtual int id { get; set; }
        public virtual int version { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual string ItemNo { get; set; }
        public virtual string Suffix { get; set; }
        public virtual string Model { get; set; }
        public virtual int Seq { get; set; }
        public virtual string PO { get; set; }
        public virtual int PO_Qty { get; set; }
        public virtual int PO_Balance { get; set; }
        public virtual int Quota { get; set; }
        public virtual string ShiftName { get; set; }
        public virtual string ShiftCode { get; set; }
        public virtual string ShiftWorkScheme { get; set; }
        public virtual decimal ShiftHours { get; set; }
        public virtual string Line { get; set; }
        public virtual int Capacity { get; set; }
        public virtual Nullable<int> DeliveryDate { get; set; }        
        public virtual string Status { get; set; }
    }

    public class RT1_Simulation_Calendar
    {
        public virtual string shiftname { get; set; }
        public virtual string Type { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual string DayName { get; set; }
        public virtual string ShiftCode { get; set; }
        public virtual string ShiftWorkScheme { get; set; }
        public virtual Nullable<decimal> ShiftHours { get; set; }
    }

    public class RT1_Simulation_CalendarList : BaseModel
    {
        public RT1_Simulation_CalendarList()
        {
            this.List = new List<RT1_Simulation_Calendar>();
        }

        public List<RT1_Simulation_Calendar> List;
    }

    public class POBalance : BaseModel
    {
        public virtual string PO { get; set; }
        public virtual string ItemNo { get; set; }
        public virtual string Suffix { get; set; }
        public virtual string Model { get; set; }
        public virtual string PO_Qty { get; set; }
        public virtual int Seq { get; set; }
        public virtual DateTime Expected_Date { get; set; }
        public virtual int Expected_QTY { get; set; }
        public virtual DateTime DeliveryDate { get; set; }
        public virtual int Delivery_QTY { get; set; }
    }

    public class Report_Simulation_for_POBalance
    {
        public virtual int Seq{ get; set; }
        public virtual string PO { get; set; }
        public virtual string ItemNo { get; set; }
        public virtual string Suffix { get; set; }
        public virtual string Model{ get; set; }
        public virtual string Destination { get; set; }
        public virtual int PO_Qty{ get; set; }
        public virtual Nullable<DateTime> X_Factory { get; set; }
        //public virtual Nullable<DateTime> Expected_Date { get; set; }
        //public virtual Nullable<int> Expected_QTY { get; set; }
        public virtual Nullable<DateTime> XX_Factory { get; set; }
        public virtual Nullable<int> XX_Factory_QTY { get; set; }
        public virtual string Difference { get; set; }
        public virtual string Customer_Reply { get; set; }
        public virtual Nullable<DateTime> Reply3 { get; set; }
        public virtual Nullable<int> Reply3_QTY { get; set; }

        public virtual string Difference_1 { get; set; }
        public virtual string Customer_Reply_1 { get; set; }
    }

    public class Report_Simulation_for_POBalanceList : BaseModel
    {
        public Report_Simulation_for_POBalanceList()
        {
            this.List = new List<Report_Simulation_for_POBalance>();
        }

        public List<Report_Simulation_for_POBalance> List;
    }

    public class Model : LogModel
    {
        public virtual int model_id { get; set; }
        public virtual string rinks_no { get; set; }
        public virtual string tat { get; set; }
        public virtual int Production_LT { get; set; }
        public virtual int Shipment_LT { get; set; }
    }

    public class ModelList : BaseModel
    {
        public ModelList()
        {
            this.List = new List<Model>();
        }

        public List<Model> List;
    }

}