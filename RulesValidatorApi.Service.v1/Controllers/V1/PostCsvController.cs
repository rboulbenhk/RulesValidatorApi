using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RulesValidatorApi.Service.Contracts.V1;
using RulesValidatorApi.Service.Models.Request;
using RulesValidatorApi.Service.v1.Contracts.V1.Requests;
using RulesValidatorApi.Service.v1.Contracts.V1.Responses;
using RulesValidatorApi.Service.v1.Services;

namespace RulesValidatorApi.Service.Controllers.V1
{
    [ApiController]
    [Route("api/csv")]
    public class PostCsvController : ControllerBase
    {
        private readonly ILogger<PostCsvController> _logger;
        private readonly IPostService _postService;

        public PostCsvController(ILogger<PostCsvController> logger, IPostService postService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _postService = postService;
        }

        [HttpPost(ApiRoutes.PostCvsController.Post)]
        public IActionResult Validate([FromBody] CsvValidationPostRequest csvValidationRequest)
        {
            try
            {
                var response = _postService.PostValidate();
                return Ok(response);
            }
            catch(Exception ex)
            {
                _logger.LogCritical($"Exception occured while validating the CSV file {csvValidationRequest.FilePath} with the Configuration {(null)} : {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError, "A problem occured while handling your request.");
            }
        }
    }
}