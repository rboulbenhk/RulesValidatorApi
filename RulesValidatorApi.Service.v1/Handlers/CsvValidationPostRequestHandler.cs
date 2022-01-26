global using System.Threading;
global using RulesValidatorApi.Service.Domains.Request;
global using RulesValidatorApi.Service.v1.Services;

namespace RulesValidatorApi.Service.v1.Handlers
{
    public class CsvValidationPostRequestHandler : IRequestHandler<CsvValidationPostRequestCommand, ValidateableResponse<IEnumerable<CsvValidationPostErrorResponse>>>
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public CsvValidationPostRequestHandler(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }       

        public async Task<ValidateableResponse<IEnumerable<CsvValidationPostErrorResponse>>> Handle(CsvValidationPostRequestCommand request, CancellationToken cancellationToken)
        {
            var csvConfigurationForValidation = _mapper.Map<CsvConfigurationForValidation>(request);
            var response = await _postService.PostValidateAsync(csvConfigurationForValidation);
            return new ValidateableResponse<IEnumerable<CsvValidationPostErrorResponse>>(_mapper.Map<IEnumerable<CsvValidationPostErrorResponse>>(response));
        }
    }
}