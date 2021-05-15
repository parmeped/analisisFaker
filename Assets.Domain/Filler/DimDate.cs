using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Holdings.Domain.Filler
{
    public class DimDate
    {
        [Key]
        public int DateKey { get; set; }
        public DateTime FullDateAlternateKey { get; set; }
        public byte CalendarQuarter { get; set; }
        public short CalendarYear { get; set; }
        public byte CalendarSemester { get; set; }
    }
}
