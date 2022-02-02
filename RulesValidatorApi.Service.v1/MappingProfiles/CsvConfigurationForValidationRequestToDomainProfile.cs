namespace RulesValidatorApi.Service.v1.MappingProfiles;
public class CsvConfigurationForValidationRequestToDomainProfile : Profile
{
    public CsvConfigurationForValidationRequestToDomainProfile()
    {
        CreateMap<CsvValidationPostRequest, CsvValidationPostRequestCommand>();

        CreateMap<CsvValidationPostRequest, CsvConfigurationForValidation>()
        .ForMember(destination => destination.RuleSet,
        options => options.MapFrom(src => (src.RuleSet ?? Enumerable.Empty<PostRuleSetRequest>()).Select(r => new RuleSet { ColumnId = r.ColumnId, RuleName = r.RuleName, Arguments = r.ArgumentValues })));

        CreateMap<PostRuleSetRequest, RuleSet>();
    }
}