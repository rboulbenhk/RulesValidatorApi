global using System.Threading.Tasks;
global using AutoMapper;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.Extensions.Logging;
global using RulesValidatorApi.Service.Contracts.V1;
global using RulesValidatorApi.Service.v1.Commands;
global using RulesValidatorApi.Service.v1.Queries;
using RulesValidatorApi.Service.v1.Helper;
using RulesValidatorApi.Service.v1.Logger;

namespace RulesValidatorApi.Service.Controllers.V1
{
    [Produces("application/json")]
    public class PostCsvController : ApplicationController
    {
        private readonly ILogger<PostCsvController> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

            
        public PostCsvController(ILogger<PostCsvController> logger,
        IMapper mapper,
        IMediator mediator)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper;
            _mediator = mediator;
        }

        /// <summary>
        /// Retrieve all the available rules to apply on the CSV to validate
        /// </summary>
        [HttpGet(ApiRoutes.PostCvsController.GetAllRulesAsync)]
        public async Task<IActionResult> GetAllRulesAsync()
        {
            _logger.StartGetAllRulesAsync();
            var query = new GetAllCsvRulesQuery();
            var result = await _mediator.Send(query);
            _logger.EndGetAllRulesAsync();
            return Ok(result);
        }

        /// <summary>
        /// Validate a CSV file with specific rules
        /// </summary>
        /// <response code="200">CVS File has been validated</response>
        /// <response code="400">Error during CSV validation</response>
        [HttpPost(ApiRoutes.PostCvsController.ValidateAsync)]
        [ProducesResponseType(typeof(CsvValidationPostErrorResponse), StatusCodes.Status200OK)]        
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ValidateAsync(CsvValidationPostRequest csvValidationPostRequest)
        {
            _logger.StartValidateAsync();
            try
            {
                var csvValidationPostRequestCommand = _mapper.Map<CsvValidationPostRequestCommand>(csvValidationPostRequest);
                var csvValidationPostErrorResponse = await _mediator.Send(csvValidationPostRequestCommand);
                if(csvValidationPostErrorResponse.IsValidResponse)
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
}