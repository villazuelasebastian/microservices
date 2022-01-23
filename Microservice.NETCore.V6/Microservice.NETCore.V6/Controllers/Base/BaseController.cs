namespace Microservice.NETCore.V6.Controllers.Base;

public class BaseController : ControllerBase
{
    public readonly IMediator _mediator;

    public BaseController(IMediator mediator)
        => _mediator = mediator;
}