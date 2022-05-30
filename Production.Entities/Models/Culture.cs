﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Production.Entities.Models
{
    public partial class Culture
    {
        public Culture()
        {
            ProductModelProductDescriptionCultures = new HashSet<ProductModelProductDescriptionCulture>();
        }

        public string CultureID { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<ProductModelProductDescriptionCulture> ProductModelProductDescriptionCultures { get; set; }
    }
}
