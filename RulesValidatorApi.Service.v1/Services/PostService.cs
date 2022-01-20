using System;
using System.Collections.Generic;
using System.Linq;
using RulesValidatorApi.Service.Domains.Response;

namespace RulesValidatorApi.Service.v1.Services
{
    public class PostService : IPostService
    {
        public PostService()
        {
            
        }
        public IEnumerable<CsvValidationErrorResponse> PostValidate()
        {
            return Enumerable.Empty<CsvValidationErrorResponse>();
        }
    }
}