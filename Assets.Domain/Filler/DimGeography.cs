using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Faker.Domain
{
    public class DimGeography
    {
		[Key]
		public int GeographyKey { get; set; }
		public string City { get; set; }
		public string StateProvinceCode { get; set; }
		public string StateProvinceName { get; set; }
		public string CountryRegionCode { get; set; }
		public string EnglishCountryRegionName { get; set; }
		public string PostalCode { get; set; }
		public string IpAddressLocator { get; set; }
	}
}
