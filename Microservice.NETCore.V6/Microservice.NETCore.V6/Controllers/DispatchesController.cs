namespace Microservice.NETCore.V6.Controllers;

[ApiController]
[Route("dispatches")]
public class DispatchesController : BaseController
{
    private readonly ILogger<DispatchesController> _logger;

    public DispatchesController(ILogger<DispatchesController> logger, IMediator mediator) : base(mediator)
        => _logger = logger;

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetDispatches()
    {
        _logger.LogInformation((int)Information.GetDispatchesControllerInformation, "source: {@source}", this);

        return Ok(await _mediator.Send(new GetDispatchesQuery()));
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetDispatchesById([Required] Guid id)
    {
        _logger.LogInformation((int)Information.GetDispatchesByIdControllerInformation, "source: {@source}", this);

        return Ok(await _mediator.Send(new GetDispatchesByIdQuery(id)));
    }
}