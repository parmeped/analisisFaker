using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Holdings.Domain.Filler
{
    public class DimCustomer
    {
		[Key]
		public int CustomerKey { get; set; }
		public int GeographyKey { get; set; }
		public string CustomerAlternateKey { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public DateTime BirthDate { get; set; }
		public string EmailAddress { get; set; }
		public decimal YearlyIncome { get; set; }
		public string AddressLine1 { get; set; }
		public string Phone { get; set; }
		public DateTime DateFirstPurchase { get; set; }
		public string CommuteDistance { get; set; }
	}
}
