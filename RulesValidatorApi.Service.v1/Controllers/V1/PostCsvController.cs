using System;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RulesValidatorApi.Service.Contracts.V1;
using RulesValidatorApi.Service.v1.Commands;
using RulesValidatorApi.Service.v1.Contracts.V1.Requests;
using RulesValidatorApi.Service.v1.Contracts.V1.Responses;
using RulesValidatorApi.Service.v1.Queries;

namespace RulesValidatorApi.Service.Controllers.V1
{
    [ApiController]    
    [Produces("application/json")]
    public class PostCsvController : ControllerBase
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
        [HttpPost(ApiRoutes.PostCvsController.GetAllRulesAsync)]        
        public async Task<IActionResult> GetAllRulesAsync()
        {
            var query = new GetAllCsvRulesQuery();
            var result = await _mediator.Send(query);
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
        public async Task<IActionResult> ValidateAsync([FromBody] CsvValidationPostRequest csvValidationPostRequest)
        {
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
                _logger.LogCritical($"Exception occured while validating the CSV file {csvValidationPostRequest.FilePath} with the Configuration {(null)} : {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError, "A problem occured while handling your request.");
            }
        }
    }
}