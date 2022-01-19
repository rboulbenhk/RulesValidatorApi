using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RulesValidatorApi.Models.Request;

namespace RulesValidatorApi.Controllers
{
    [ApiController]
    [Route("api/csv")]
    public class CsvController : ControllerBase
    {
        private readonly ILogger<CsvController> _logger;

        public CsvController(ILogger<CsvController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost]
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