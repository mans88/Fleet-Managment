using Fleet_Managment_BLL.Domain;
using FleetManagment.Shared.TransfertObject;
using System.Collections.Generic;

namespace Fleet_Managment.Models
{
    public class BrandAndModelListViewModel
    {
        public int IdBrand { get; set; }
        public string BrandName { get; set; }
        public List<ModelTO> Models { get; set; }
    }
}