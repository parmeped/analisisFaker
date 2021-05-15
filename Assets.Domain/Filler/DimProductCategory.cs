using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Holdings.Domain.Filler
{
    public class DimProductCategory
    {
        [Key]
        public int ProductCategoryKey { get; set; }
        public string EnglishProductCategoryName { get; set; }
    }
}
