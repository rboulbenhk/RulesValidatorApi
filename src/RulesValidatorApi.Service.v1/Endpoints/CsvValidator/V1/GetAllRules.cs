namespace RulesValidatorApi.Service.Endpoints.CsvValidator.V1;

public class GetAllRules : EndpointBaseAsync
                .WithoutRequest
                .WithActionResult<IEnumerable<GetAllCsvRulesResponse>>
{
    private readonly ILogger<GetAllRules> _logger;
    private readonly IMediator _mediator;

    public GetAllRules(ILogger<GetAllRules> logger, IMediator mediator)
    {
        _logger = Guard.Against.Null(logger, nameof(logger));
        _mediator = Guard.Against.Null(mediator, nameof(mediator));
    }

    [HttpGet(ApiRoutes.PostCvsController.GetAllRulesAsync)]
    [SwaggerOperation(Summary = "Retrieve all available rules",
    Description = "Retrieve all available rules",
    OperationId = "GetAllRules",
    Tags = new[] { "CsvValidatorEndpoint" })]
    public override async Task<ActionResult<IEnumerable<GetAllCsvRulesResponse>>> HandleAsync(CancellationToken cancellationToken = default)
    {
        _logger.StartGetAllRulesAsync();
        var query = new GetAllCsvRulesQuery();
        var result = await _mediator.Send(query);
        _logger.EndGetAllRulesAsync();
        //TODO check if the return type is correct
        return Ok(result);
    }
}