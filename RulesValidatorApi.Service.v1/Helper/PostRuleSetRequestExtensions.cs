namespace RulesValidatorApi.Service.v1.Helper;

public static class PostRuleSetRequestExtensions
{
    public static string PostRuleSetRequestLogMessage(this IEnumerable<PostRuleSetRequest> postRuleSetRequests) => Utf8Json.JsonSerializer.ToJsonString(postRuleSetRequests);
}