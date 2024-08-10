using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.Controllers.Reports
{
    public class ItemNoController
    {
        public ItemNoController()
        {

        }

        private EntitiesServices.EntitiesManager.Views.view_MCPSTP_ItemNo _itemNoSetup = new EntitiesServices.EntitiesManager.Views.view_MCPSTP_ItemNo();
        private EntitiesServices.EntitiesManager.Tables.SimulatorManager _simulatorSetup = new EntitiesServices.EntitiesManager.Tables.SimulatorManager();

        public Models.Maintenance.RinksItemNoList GetAllModels()
        {
            Models.Maintenance.RinksItemNoList result = new Models.Maintenance.RinksItemNoList();

            try
            {
                result._List = new EntitiesServices.EntitiesManager
                                                                   .Views
                                                                   .view_MCPSTP_ItemNo()
                                                                   .MCPCDP()
                                                                   .Select(x => new Models.Maintenance.RinksItemNo
                                                                   {
                                                                       CGITCH = x.CGITCH
                                                                   }).ToList();
            }
            catch (Exception ex)
            {
                result.Error = ex.Message;
            }

            return result;
        }

        public Models.Maintenance.rt1SimulationList getSimulation(string itemno)
        {
            Models.Maintenance.rt1SimulationList result = new Models.Maintenance.rt1SimulationList();
            try
            {
                var qry = new EntitiesServices.EntitiesManager
                                                                   .Tables
                                                                   .SimulatorManager()
                                                                   .Simulator().Max(x => x.version);
                var sv = new EntitiesServices.EntitiesManager
                                                     .Views
                                                     .view_MCPSTP()
                                                     .listParentItem().GroupBy(n => new { n.CGITPR, n.CGQAIT, n.CGITCH })
                                                     .Where(x => x.Key.CGITCH.Trim().Equals(itemno.Trim()))
                                                     .Select(x => new Models.Maintenance.ParentItem
                                                     {
                                                         item = x.Key.CGITPR

                                                     }).ToList();


                result._List = new EntitiesServices.EntitiesManager
                                                          .Views
                                                          .view_Simulate_InputeQuantity()
                                                          .SimulatorInputeQty()
                                                          .Where(x => x.version.Equals(qry) && sv.Any(y => y.item.Trim().Equals(x.ItemNo.Trim())))
                                                          .GroupBy(y => new { y.ItemNo, y.date, y.total })
                                                          .Select(x => new Models.Maintenance.RT1Simulation
                                                          {
                                                              date = x.Key.date.ToString(),
                                                              itemno = x.Key.ItemNo,
                                                              inputquantity = Convert.ToInt32(x.Sum(a => a.total)).ToString()
                                                          }).ToList();

            }
            catch (Exception ex)
            {
                result.Error = ex.Message;
            }
            return result;

        }
        public Models.Maintenance.rt1SimulationList getSimulationElectrical(string itemno)
        {
            Models.Maintenance.rt1SimulationList result = new Models.Maintenance.rt1SimulationList();
            try
            {
                var qry = new EntitiesServices.EntitiesManager
                                                                   .Tables
                                                                   .SimulatorManager()
                                                                   .Simulator().Max(x => x.version);
                var sv = new EntitiesServices.EntitiesManager
                                                    .Views
                                                    .view_MCPSTP()
                                                    .listParentItem().GroupBy(n => new { n.CGITPR, n.CGQAIT, n.CGITCH })
                                                    .Where(x => x.Key.CGITCH.Trim().Equals(itemno.Trim()))
                                                    .Select(x => new Models.Maintenance.ParentItem
                                                    {
                                                        item = x.Key.CGITPR

                                                    }).ToList();

                var csv = new EntitiesServices.EntitiesManager
                                                    .Views
                                                    .view_MCPSTP()
                                                    .listParentItem().GroupBy(n => new { n.CGITPR, n.CGQAIT, n.CGITCH })
                                                    .Where(x => sv.Any(y => y.item.Trim().Equals(x.Key.CGITCH.Trim())))
                                                    .Select(x => new Models.Maintenance.ParentItem
                                                    {
                                                        item = x.Key.CGITPR

                                                    }).ToList();


                result._List = new EntitiesServices.EntitiesManager
                                                        .Views
                                                        .view_Simulate_InputeQuantity()
                                                        .SimulatorInputeQty()
                                                        .Where(x => x.version.Equals(qry) && csv.Any(y => y.item.Trim().Equals(x.ItemNo.Trim())))
                                                        .GroupBy(y => new { y.ItemNo, y.date })
                                                        .Select(x => new Models.Maintenance.RT1Simulation
                                                        {
                                                            date = x.Key.date.ToString(),
                                                            itemno = x.Key.ItemNo,
                                                            inputquantity = Convert.ToInt32(x.Sum(a => a.total)).ToString()
                                                        }).ToList();


            }
            catch (Exception ex)
            {
                result.Error = ex.Message;
            }
            return result;

        }

        public Models.Maintenance.ParentItemList getParentList(string itemno)
        {
            Models.Maintenance.ParentItemList result = new Models.Maintenance.ParentItemList();
            try
            {
                result._List = new EntitiesServices.EntitiesManager
                                                              .Views
                                                              .view_MCPSTP()
                                                            .listParentItem()
                                                            .GroupBy(n => new { n.CGITPR, n.CGQAIT, n.CGITCH})
                                                             .Where(x => x.Key.CGITCH.Trim().Equals(itemno.Trim()))
                                                             .Select(x => new Models.Maintenance.ParentItem
                                                             {
                                                                 item = x.Key.CGITPR,
                                                                 quantity = Convert.ToInt32(x.Key.CGQAIT).ToString(),
                                                                 suffix = x.Max(a => a.CGSDPR).ToString() 

                                                             }).ToList();

            }
            catch (Exception ex)
            {
                result.Error = ex.Message;
            }
            return result;
        }

        public Models.Maintenance.ParentItemList getParentLists(string itemno)
        {
            Models.Maintenance.ParentItemList result = new Models.Maintenance.ParentItemList();
            try
            {

              var  sv = new EntitiesServices.EntitiesManager
                                                              .Views
                                                              .view_MCPSTP()
                                                            .listParentItem().GroupBy(n => new { n.CGITPR, n.CGQAIT, n.CGITCH})
                                                             .Where(x => x.Key.CGITCH.Trim().Equals(itemno.Trim()))
                                                             .Select(x => new Models.Maintenance.ParentItem
                                                             {
                                                                 item = x.Key.CGITPR,
                                                                 quantity = Convert.ToInt32(x.Key.CGQAIT).ToString(),
                                                                 suffix = x.Max(a => a.CGSDPR).ToString()

                                                             }).ToList();

              result._List = new EntitiesServices.EntitiesManager
                                                 .Views
                                                 .view_MCPSTP()
                                                 .listParentItem().GroupBy(n => new { n.CGITPR, n.CGQAIT, n.CGITCH})
                                                 .Where(x => sv.Any(y => y.item.Trim().Equals(x.Key.CGITCH.Trim())))
                                                 .Select(x => new Models.Maintenance.ParentItem
                                                 {
                                                     item = x.Key.CGITPR,
                                                     quantity = Convert.ToInt32(x.Key.CGQAIT).ToString(),
                                                     subparent = x.Key.CGITCH,
                                                     suffix = x.Max(a => a.CGSDPR).ToString(),
                                                     

                                                 }).ToList();


            }
            catch (Exception ex)
            {
                result.Error = ex.Message;
            }
            return result;
        }


    }
}
