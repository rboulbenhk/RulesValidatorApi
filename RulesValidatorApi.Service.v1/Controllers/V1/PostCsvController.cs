using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RulesValidatorApi.Service.Contracts.V1;
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
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public PostCsvController(ILogger<PostCsvController> logger,
        IPostService postService, 
        IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _postService = postService;
            _mapper = mapper;
        }

        /// <summary>
        /// Validate a CSV file with specific rules
        /// </summary>
        /// <response code="201">CVS File has been validated</response>
        /// <response code="400">Error during CSV validation</response>
        [HttpPost(ApiRoutes.PostCvsController.Post)]
        [ProducesResponseType(typeof(CsvValidationPostErrorResponse), 201)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public IActionResult Validate([FromBody] CsvValidationPostRequest csvValidationRequest)
        {
            try
            {
                var response = _postService.PostValidate();

                var csvValidationPostErrorResponse = new CsvValidationPostErrorResponse();
                //csvValidationPostErrorResponse.Errors = response.Select(r => r.Errors);
                return Ok(new Response<List<CsvValidationPostErrorResponse>>(_mapper.Map<List<CsvValidationPostErrorResponse>>(response)));
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception occured while validating the CSV file {csvValidationRequest.FilePath} with the Configuration {(null)} : {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError, "A problem occured while handling your request.");
            }
        }
    }
}