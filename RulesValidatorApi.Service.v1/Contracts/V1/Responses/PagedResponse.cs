using System.Collections.Generic;

namespace RulesValidatorApi.Service.v1.Contracts.V1.Responses
{
    public class PagedResponse<T>
    {
        public PagedResponse(){}
        public PagedResponse(IEnumerable<T> data)
        {
            Data = data;
        }

        public IEnumerable<T> Data { get; set; }
        public int? PageNumber { get; set; }
        public int PageSize { get; set; }
        public string PreviousPage { get; set; }
        public string NextPage { get; set; }
    }
}