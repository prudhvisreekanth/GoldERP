using GoldERP.Application.Features.GoldRate.DTOs;
using MediatR;

namespace GoldERP.Application.Features.GoldRate.Queries;

public record GetLiveGoldRateQuery()
    : IRequest<GoldRateResponseDto>;