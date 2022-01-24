using AutoMapper;
using RulesValidatorApi.Service.Domains.Response;
using RulesValidatorApi.Service.v1.Contracts.V1.Responses;

namespace RulesValidatorApi.Service.MappingProfiles
{
    public class DomainsToResponseProfile : Profile
    {
        public DomainsToResponseProfile()
        {
            CreateMap<CsvValidationErrorResponse, CsvValidationPostErrorResponse>();
            CreateMap<GetAllCsvRulesResponse, GetAllCsvRulesResponse>();
        }
    }
}