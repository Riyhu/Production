using Production.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production.Entities.DTO
{
    public class AddEditCategoryProductDTO
    {
        public int ProductCategoryID { get; set; }
        public string Name { get; set; } // category
        public ICollection<ProductSubcategory> ProductSubCategories { get; set; }
        public List<string> SubCategoryName { get; set; }
    }
}
