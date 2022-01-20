using System.Collections.Generic;

namespace RulesValidatorApi.Service.v1.Contracts.V1.Responses
{
    public class ErrorResponse
    {
        public List<ErrorCode>? Errors {get; set;} = new List<ErrorCode>();
    }
}