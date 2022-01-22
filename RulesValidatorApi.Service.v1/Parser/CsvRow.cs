namespace RulesValidatorApi.Service.Parser
{
    public record CsvRow(string[] header, string value, int index);
}