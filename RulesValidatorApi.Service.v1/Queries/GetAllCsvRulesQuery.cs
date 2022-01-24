using System.Collections.Generic;
using MediatR;
using RulesValidatorApi.Service.v1.Contracts.V1.Responses;


namespace RulesValidatorApi.Service.v1.Queries
{
    public class GetAllCsvRulesQuery : IRequest<IEnumerable<GetAllCsvRulesResponse>>{}
}