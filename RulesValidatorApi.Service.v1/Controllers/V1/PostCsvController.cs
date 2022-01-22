using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RulesValidatorApi.Service.Contracts.V1;
using RulesValidatorApi.Service.Domains.Request;
using RulesValidatorApi.Service.v1.Commands;
using RulesValidatorApi.Service.v1.Contracts.V1.Requests;
using RulesValidatorApi.Service.v1.Contracts.V1.Responses;
using RulesValidatorApi.Service.v1.Services;

namespace RulesValidatorApi.Service.Controllers.V1
{
    [ApiController]
    [Route("api/csv")]
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
        /// Validate a CSV file with specific rules
        /// </summary>
        /// <response code="200">CVS File has been validated</response>
        /// <response code="400">Error during CSV validation</response>
        [HttpPost(ApiRoutes.PostCvsController.Post)]
        [ProducesResponseType(typeof(CsvValidationPostErrorResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ValidateAsync([FromBody] CsvValidationPostRequest csvValidationPostRequest)
        {
            try
            {
                var csvValidationPostRequestCommand = _mapper.Map<CsvValidationPostRequestCommand>(csvValidationPostRequest);
                var csvValidationPostErrorResponse = await _mediator.Send(csvValidationPostRequestCommand);
                return Ok(csvValidationPostErrorResponse);
                // var csvConfigurationForValidation = _mapper.Map<CsvConfigurationForValidation>(csvValidationPostRequest);
                // var response = await _postService.PostValidateAsync(csvConfigurationForValidation);

                // var csvValidationPostErrorResponse = new CsvValidationPostErrorResponse();
                // return Ok(new Response<List<CsvValidationPostErrorResponse>>(_mapper.Map<List<CsvValidationPostErrorResponse>>(response)));
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception occured while validating the CSV file {csvValidationPostRequest.FilePath} with the Configuration {(null)} : {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError, "A problem occured while handling your request.");
            }
        }
    }
}