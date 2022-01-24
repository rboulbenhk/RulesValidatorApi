using System.Collections.Generic;
using System.Linq;

namespace RulesValidatorApi.Service.v1.Domains.Response
{
    public class CsvRulesResponse
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public IEnumerable<string> PossibleArguments { get; set; } = Enumerable.Empty<string>();
    }
}