

namespace RulesValidatorApi.Application.MappingProfiles;
public class DomainsToResponseProfile : Profile
{
    public DomainsToResponseProfile()
    {
        CreateMap<CsvValidationErrorResponse, CsvValidationPostErrorResponse>();
        CreateMap<CsvRulesResponse, GetAllCsvRulesResponse>();
    }
}