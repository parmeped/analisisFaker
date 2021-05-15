using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Holdings.Domain.Filler
{
    public class FactSales
    {
		[Key]
		public int Id { get; set; }
		public int ProductKey { get; set; }
		public int ProductCategoryKey { get; set; }
		public int ProductSubcategoryKey { get; set; }
		public int PromotionKey { get; set; }
		public int CustomerKey { get; set; }
		public int OrganizationKey { get; set; }
		public int GeographicKey { get; set; }
		public int DateKey { get; set; }
		public int Amount_ordered { get; set; }
		public decimal Total_amount { get; set; }
		public decimal Utility { get; set; }
	}
}
