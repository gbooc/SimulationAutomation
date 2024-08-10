using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.Controllers.Reports
{
    public class ItemStocksController
    {
        public ItemStocksController()
        {

        }
        private EntitiesServices.EntitiesManager.Views.view_MJINVP _stocksSetup = new EntitiesServices.EntitiesManager.Views.view_MJINVP();

        public Models.Maintenance.RinksstocksList GetWP8100stocks(string itemno)
        {
            Models.Maintenance.RinksstocksList result = new Models.Maintenance.RinksstocksList();

            try
            {
                result._List = new EntitiesServices.EntitiesManager
                                                                   .Views
                                                                   .view_MJINVP()
                                                                   .LISTMJINVP()
                                                                   .Where(x => new[] { "WP8100", "WP9084" }.Contains(x.JASEIV) && x.JAIT.Trim().Equals(itemno.Trim()))
                                                                   .Select(x => new Models.Maintenance.RinksStocks
                                                                   {
                                                                       stocks = Convert.ToDecimal(x.JAQINV)
                                                                   }).ToList();
            }
            catch (Exception ex)
            {
                result.Error = ex.Message;
            }

            return result;
        }

        public Models.Maintenance.RinksstocksList GetMP8068stocks(string itemno)
        {
            Models.Maintenance.RinksstocksList result = new Models.Maintenance.RinksstocksList();

            try
            {
                result._List = new EntitiesServices.EntitiesManager
                                                                   .Views
                                                                   .view_MJINVP()
                                                                   .LISTMJINVP()
                                                                   .Where(x => new[] { "MP8068", "MP9068" }.Contains(x.JASEIV) && x.JAIT.Trim().Equals(itemno.Trim()))
                                                                   .Select(x => new Models.Maintenance.RinksStocks
                                                                   {
                                                                       stocks = Convert.ToDecimal(x.JAQINV)
                                                                   }).ToList();
            }
            catch (Exception ex)
            {
                result.Error = ex.Message;
            }

            return result;
        }


        public Models.Maintenance.RinksstocksList GetAP8000stocks(string itemno)
        {
            Models.Maintenance.RinksstocksList result = new Models.Maintenance.RinksstocksList();

            try
            {
                result._List = new EntitiesServices.EntitiesManager
                                                                   .Views
                                                                   .view_MJINVP()
                                                                   .LISTMJINVP()
                                                                   .Where(x => new[] { "AP8000", "MP9078" }.Contains(x.JASEIV) && x.JAIT.Trim().Equals(itemno.Trim()))
                                                                   .Select(x => new Models.Maintenance.RinksStocks
                                                                   {
                                                                       stocks = Convert.ToDecimal(x.JAQINV)
                                                                   }).ToList();
            }
            catch (Exception ex)
            {
                result.Error = ex.Message;
            }

            return result;
        }

        public Models.Maintenance.RinksstocksList GetWPMPstocks(string itemno)
        {
            Models.Maintenance.RinksstocksList result = new Models.Maintenance.RinksstocksList();

            try
            {
                result._List = new EntitiesServices.EntitiesManager
                                                                   .Views
                                                                   .view_MJINVP()
                                                                   .LISTMJINVP()
                                                                   .Where(x => new[] { "WP8100", "WP9084", "MP8068", "MP9068" }.Contains(x.JASEIV) && x.JAIT.Trim().Equals(itemno.Trim()))
                                                                   .Select(x => new Models.Maintenance.RinksStocks
                                                                   {
                                                                       stocks = Convert.ToDecimal(x.JAQINV)
                                                                   }).ToList();
            }
            catch (Exception ex)
            {
                result.Error = ex.Message;
            }

            return result;
        }

        public Models.Maintenance.RinksstocksList GetWPAPstocks(string itemno)
        {
            Models.Maintenance.RinksstocksList result = new Models.Maintenance.RinksstocksList();

            try
            {
                result._List = new EntitiesServices.EntitiesManager
                                                                   .Views
                                                                   .view_MJINVP()
                                                                   .LISTMJINVP()
                                                                   .Where(x => new[] { "WP8100", "WP9084", "AP8000", "MP9078" }.Contains(x.JASEIV) && x.JAIT.Trim().Equals(itemno.Trim()))
                                                                   .Select(x => new Models.Maintenance.RinksStocks
                                                                   {
                                                                       stocks = Convert.ToDecimal(x.JAQINV)
                                                                   }).ToList();
            }
            catch (Exception ex)
            {
                result.Error = ex.Message;
            }

            return result;
        }

        public Models.Maintenance.RinksstocksList GetALLstocks(string itemno)
        {
            Models.Maintenance.RinksstocksList result = new Models.Maintenance.RinksstocksList();

            try
            {
                result._List = new EntitiesServices.EntitiesManager
                                                                   .Views
                                                                   .view_MJINVP()
                                                                   .LISTMJINVP()
                                                                   .Where(x => new[] { "WP8100", "WP9084", "MP8068", "MP9068", "AP8000", "MP9078" }.Contains(x.JASEIV) && x.JAIT.Trim().Equals(itemno.Trim()))
                                                                   .Select(x => new Models.Maintenance.RinksStocks
                                                                   {
                                                                       stocks = Convert.ToDecimal(x.JAQINV)
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
