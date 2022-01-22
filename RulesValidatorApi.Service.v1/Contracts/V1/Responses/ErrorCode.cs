namespace RulesValidatorApi.Service.v1.Contracts.V1.Responses
{
    public class ErrorCode
    {
        public  string FieldName { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}