using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RulesValidatorApi.Service.v1.Contracts.V1.Responses;

namespace RulesValidatorApi.Service.v1.Services
{
    public interface IPostService
    {
        IList<CsvValidationPostResponse> PostValidate();
    }
}