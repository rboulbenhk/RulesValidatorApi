using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using RulesValidatorApi.Service.Domains.Request;
using RulesValidatorApi.Service.v1.Contracts.V1.Responses;
using RulesValidatorApi.Service.v1.Services;

namespace RulesValidatorApi.Service.v1.Handlers
{
    public class CsvValidationPostRequestHandler : IRequestHandler<CsvValidationPostRequest, IEnumerable<CsvValidationPostErrorResponse>>
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public CsvValidationPostRequestHandler(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CsvValidationPostErrorResponse>> Handle(CsvValidationPostRequest request, CancellationToken cancellationToken)
        {
            var csvConfigurationForValidation = _mapper.Map<CsvConfigurationForValidation>(request);
            var response = await _postService.PostValidateAsync(csvConfigurationForValidation);
            return _mapper.Map<IEnumerable<CsvValidationPostErrorResponse>>(response);
        }
    }
}