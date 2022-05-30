using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production.Entities.DTO
{
    public class ProductWorkOrderDTO
    {
        public int ProductID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ProductNumber { get; set; }
        public int DaytoManufacture { get; set; }
        public decimal ListPrice { get; set; }
    }
}
