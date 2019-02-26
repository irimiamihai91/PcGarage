using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcGarage.Interfaces;
using PcGarage.Models;
using PcGarage.DataAcess;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace PcGarage.BusinessLogic
{
    public class SqlManufacturerManager : IManufacturerManager
    {
        private DataAcess.PcGarageEntities pge;
        private PcGarageAdoNet pga;

        public SqlManufacturerManager()
        {
            pge = new DataAcess.PcGarageEntities();
            pga = new PcGarageAdoNet();
        }

        public IEnumerable<SelectListItem> GetManufacturerListForDropdownList()
        {

            var manufacturers = pge.Manufacturers.ToList();

            var list = new List<SelectListItem>();

            foreach (var man in manufacturers)
            {
                list.Add(new SelectListItem
                {
                    Value = man.ManufacturerId.ToString(),
                    Text = man.ManufacturerName
                });
            }

            return list;
        }
    }
}

