using Swashbuckle.AspNetCore.Filters;

namespace RulesValidatorApi.Service.v1.SwaggerExamples.Responses
{
    public class GetAllCsvRulesResponseExample : IExamplesProvider<List<GetAllCsvRulesResponse>>
    {
        public List<GetAllCsvRulesResponse> GetExamples()
        {
            return new List<GetAllCsvRulesResponse>{ 
                new GetAllCsvRulesResponse{
                    Name = "The name of the rule", 
                    Description = "The Description of the rule",
                    PossibleArgumentValues = new string[]{"The possible arguments values to use that will apply to the rule"}} };
        }
    }
}