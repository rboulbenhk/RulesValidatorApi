using RulesValidatorApi.Service.Domains.Response;
namespace RulesValidatorApi.Service.MappingProfiles
{
    public class DomainsToResponseProfile : Profile
    {
        public DomainsToResponseProfile()
        {
            CreateMap<CsvValidationErrorResponse, CsvValidationPostErrorResponse>();
            CreateMap<CsvRulesResponse, GetAllCsvRulesResponse>();
        }
    }
}