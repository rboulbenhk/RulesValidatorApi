using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using RulesValidatorApi.Service.v1.Contracts.V1.Responses;
using RulesValidatorApi.Service.v1.Queries;
using RulesValidatorApi.Service.v1.Services;

namespace RulesValidatorApi.Service.v1.Handlers
{
    public class GetAllCsvRulesQueryHandler : IRequestHandler<GetAllCsvRulesQuery, IEnumerable<GetAllCsvRulesResponse>>
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public GetAllCsvRulesQueryHandler(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllCsvRulesResponse>> Handle(GetAllCsvRulesQuery request, CancellationToken cancellationToken)
        {
            var csvRulesResponse = await _postService.GetAllCsvRulesAsync();
            return _mapper.Map<IEnumerable<GetAllCsvRulesResponse>>(csvRulesResponse);
        }
    }
} 