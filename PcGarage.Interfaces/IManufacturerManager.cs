using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PcGarage.Interfaces
{
    public interface IManufacturerManager
    {
        IEnumerable<SelectListItem> GetManufacturerListForDropdownList();
    }
}
