namespace RulesValidatorApi.Service.Contracts.V1
{
    public static class ApiRoutes
    {
        public const string Version = "v1";
        public const string Title = "RulesValidatorApi";
        public const string Root = "api";
        public const string Base = $"{Root}/{Version}";

        public static class PostCvsController
        {
            public const string Post = $"{Base}/csv";
        }
    }
}