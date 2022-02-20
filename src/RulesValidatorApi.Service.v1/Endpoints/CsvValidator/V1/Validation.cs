namespace RulesValidatorApi.Service.Endpoints.CsvValidator.V1;

public class Validation : EndpointBaseAsync
                .WithRequest<CsvValidationPostRequest>
                .WithActionResult<IEnumerable<CsvValidationPostErrorResponse>>
{
    private readonly ILogger<Validation> _logger;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public Validation(ILogger<Validation> logger,
    IMapper mapper,
    IMediator mediator)
    {
        _logger = Guard.Against.Null(logger, nameof(logger));
        _mapper = Guard.Against.Null(mapper, nameof(mapper));
        _mediator = Guard.Against.Null(mediator, nameof(mediator));
    }
    
    [HttpPost(ApiRoutes.PostCvsController.ValidateAsync)]
    [SwaggerOperation(Summary = "Validate CSV File with specific rules",
    Description = "Validate CSV File with specific rules",
    OperationId = "Validate",
    Tags = new[] { "CsvValidatorEndpoint" })]
    public override async Task<ActionResult<IEnumerable<CsvValidationPostErrorResponse>>> HandleAsync(CsvValidationPostRequest csvValidationPostRequest,  CancellationToken cancellationToken = default)
    {
        _logger.StartValidateAsync();
        try
        {
            var csvValidationPostRequestCommand = _mapper.Map<CsvValidationPostRequestCommand>(csvValidationPostRequest);
            var csvValidationPostErrorResponse = await _mediator.Send(csvValidationPostRequestCommand);
            if (csvValidationPostErrorResponse.IsValidResponse)
            {
                return Ok(csvValidationPostErrorResponse.Result);
            }
            return BadRequest(new { Error = csvValidationPostErrorResponse.Errors });
        }
        catch (Exception ex)
        {
            _logger.ExceptionValidateAsync(ex, csvValidationPostRequest.FilePath, csvValidationPostRequest.RuleSet.PostRuleSetRequestLogMessage());
            return StatusCode(StatusCodes.Status500InternalServerError, "A problem occured while handling your request.");
        }
        finally
        {
            _logger.EndValidateAsync();
        }
    }
}