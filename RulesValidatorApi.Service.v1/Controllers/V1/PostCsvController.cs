using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RulesValidatorApi.Service.Contracts.V1;
using RulesValidatorApi.Service.Models.Request;

namespace RulesValidatorApi.Service.Controllers.V1
{
    [ApiController]
    [Route("api/csv")]
    public class PostCsvController : ControllerBase
    {
        private readonly ILogger<PostCsvController> _logger;

        public PostCsvController(ILogger<PostCsvController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost(ApiRoutes.PostCvsController.Post)]
        public IActionResult Validate([FromBody] CsvConfigurationForValidationDto csvConfiguration)
        {
            try
            {
                return Ok(null);
            }
            catch(Exception ex)
            {
                _logger.LogCritical($"Exception occured while validating the CSV file {csvConfiguration.FilePath} with the Configuration {(null)} : {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError, "A problem occured while handling your request.");
            }
        }
    }
}