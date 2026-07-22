using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldERP.Application.Features.GoldRate.DTOs
{
    public class GoldRateResponseDto
    {
        public decimal Gold24K { get; set; }

        public decimal Gold22K { get; set; }

        public decimal Silver { get; set; }

        public string Currency { get; set; } = "INR";

        public DateTime LastUpdated { get; set; }
    }
}
