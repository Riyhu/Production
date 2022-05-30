using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production.Entities.DTO
{
    public class DocumentDTO
    {
        public string Title { get; set; }
        public int MyProperty { get; set; }
        public short DocumentLevel { get; set; }
        public int Owner { get; set; }
        public string FileName { get; set; }
    }
}
