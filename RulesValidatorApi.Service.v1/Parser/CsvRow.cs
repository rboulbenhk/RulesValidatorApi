namespace RulesValidatorApi.Parser
{
    public record CsvRow(string[] header, string value, int index);
}