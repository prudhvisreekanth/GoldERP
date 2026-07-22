using GoldERP.Application.Features.GoldRate.DTOs;
using GoldERP.Application.Interfaces;
using MediatR;

namespace GoldERP.Application.Features.GoldRate.Queries;

public class GetLiveGoldRateQueryHandler
    : IRequestHandler<GetLiveGoldRateQuery, GoldRateResponseDto>
{
    private readonly IGoldRateService _goldRateService;

    public GetLiveGoldRateQueryHandler(IGoldRateService goldRateService)
    {
        _goldRateService = goldRateService;
    }

    public async Task<GoldRateResponseDto> Handle(
        GetLiveGoldRateQuery request,
        CancellationToken cancellationToken)
    {
        return await _goldRateService.GetLiveRatesAsync();
    }
}