using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Holdings.Domain.Filler
{
    public class DimProductSubcategory
    {
        [Key]
        public int ProductSubcategoryKey { get; set; }
        public string EnglishProductSubcategoryName { get; set; }
        public int ProductCategoryKey { get; set; }

    }
}
