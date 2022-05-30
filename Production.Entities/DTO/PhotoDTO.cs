using Production.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production.Entities.DTO
{
    public class PhotoDTO
    {
        public int ProductID { get; set; }
        public int ProductPhotoID { get; set; }
        public string LargePhotoFileName { get; set; }
        public byte[] LargePhoto { get; set; }
//        public virtual ICollection<Product> Pro { get; set; }
        //      public bool Primary { get; set; }
    }
}
