namespace RulesValidatorApi.Service.v1.Contracts.V1.Responses
{
    public class Response<T>
    {
        public Response(){}

        public Response(T response)
        {
            Data = response;
        }

        public T? Data { get; private set; }
    }
}