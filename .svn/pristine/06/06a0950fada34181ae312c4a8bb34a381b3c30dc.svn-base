using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.EntitiesServices.EntitiesManager.Tables
{
    public class Simulator_PlanOutputManager
    {
        public Simulator_PlanOutputManager()
        {
            this._dbContext = new DB.dbRT1_SADataContext();
        }

        private readonly DB.dbRT1_SADataContext _dbContext;

        public List<DB.Simulator_PlanOutput> Simulator()
        {
            try
            {
                return this._dbContext.Simulator_PlanOutputs.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void SaveSimulator(DB.Simulator_PlanOutput simulator_PlanOutput)
        {
            try
            {
                this._dbContext.Simulator_PlanOutputs.InsertOnSubmit(simulator_PlanOutput);
                this._dbContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
