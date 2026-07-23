using FluentValidation;
using GoldERP.Application.Features.GoldRate.Queries;

namespace GoldERP.Application.Features.GoldRate.Validators;

public class GetLiveGoldRateQueryValidator : AbstractValidator<GetLiveGoldRateQuery>
{
    public GetLiveGoldRateQueryValidator()
    {
        // No validation rules yet because the query has no properties.
        // We'll add rules when parameters are introduced.
    }
}