using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Holdings.Domain.Filler
{
    public class DimOrganization
    {
        [Key]
        public int OrganizationKey { get; set; }
        public string OrganizationName { get; set; }
    }
}
