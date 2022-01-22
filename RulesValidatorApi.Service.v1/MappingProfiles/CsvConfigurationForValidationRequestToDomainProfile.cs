using System.Linq;
using AutoMapper;
using RulesValidatorApi.Service.Domains.Request;
using RulesValidatorApi.Service.v1.Commands;
using RulesValidatorApi.Service.v1.Contracts.V1.Requests;

namespace RulesValidatorApi.Service.v1.MappingProfiles
{
    public class CsvConfigurationForValidationRequestToDomainProfile : Profile
    {
        public CsvConfigurationForValidationRequestToDomainProfile()
        {
            CreateMap<CsvValidationPostRequest,CsvValidationPostRequestCommand>();

            CreateMap<CsvValidationPostRequest,CsvConfigurationForValidation>()
            .ForMember(destination => destination.RuleSet, 
            options => options.MapFrom(src => (src.RuleSet ?? Enumerable.Empty<PostRuleSetRequest>()).Select(r => new RuleSet{ColumnId = r.ColumnId, RuleName = r.RuleName, Arguments = r.Arguments})));

            CreateMap<PostRuleSetRequest,RuleSet>();
        }
    }
}