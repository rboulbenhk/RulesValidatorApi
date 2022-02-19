using RulesValidatorApi.Contract.Queries;
using RulesValidatorApi.Domain.Interfaces;

namespace RulesValidatorApi.Application.Handlers;

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