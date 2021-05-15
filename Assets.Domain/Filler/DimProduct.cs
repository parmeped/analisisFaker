using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Holdings.Domain.Filler
{
    public class DimProduct
    {
		[Key]
		public int ProductKey { get; set; }
		public string ProductAlternateKey { get; set; }
		public int ProductSubcategoryKey { get; set; }
		public string EnglishProductName { get; set; }
		public decimal StandardCost { get; set; }
		public string Color { get; set; }
		public short SafetyStockLevel { get; set; }
		public short ReorderPoint { get; set; }
		public decimal ListPrice { get; set; }
		public string Size { get; set; }
		public int DaysToManufacture { get; set; }
		public string ProductLine { get; set; }
		public decimal DealerPrice { get; set; }
		public string ModelName { get; set; }
		public string EnglishDescription { get; set; }
	}
}
