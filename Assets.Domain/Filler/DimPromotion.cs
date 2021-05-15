using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Holdings.Domain.Filler
{
    public class DimPromotion
    {
		[Key]
		public int PromotionKey { get; set; }
		public string EnglishPromotionName { get; set; }
		public double DiscountPct { get; set; }
		public string EnglishPromotionType { get; set; }
		public string EnglishPromotionCategory { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
	}
}
