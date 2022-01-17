using System.ComponentModel.DataAnnotations;

namespace RulesValidatorApi.Models
{
    public class CsvConfigurationForValidationDto
    {
        [Required(ErrorMessage = "You should provide a FilePath")]
        public string FilePath { get; set; }

        //TODO Manage the configuration
    }
}