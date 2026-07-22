using GoldERP.Application.Features.GoldRate.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GoldERP.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GoldRateController : ControllerBase
{
    private readonly IMediator _mediator;

    public GoldRateController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetLiveRates()
    {
        var result = await _mediator.Send(new GetLiveGoldRateQuery());

        return Ok(result);
    }
}