using GoldERP.Application.Features.GoldRate.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldERP.Application.Interfaces
{
    public interface IGoldRateService
    {
        Task<GoldRateResponseDto> GetLiveRatesAsync();
    }
}
