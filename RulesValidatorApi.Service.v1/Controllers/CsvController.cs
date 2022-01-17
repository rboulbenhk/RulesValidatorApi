using Microsoft.AspNetCore.Mvc;
using RulesValidatorApi.Models;

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
                return StatusCode(500, "A problem occured while handling your request.");
            }
        }
    }
}