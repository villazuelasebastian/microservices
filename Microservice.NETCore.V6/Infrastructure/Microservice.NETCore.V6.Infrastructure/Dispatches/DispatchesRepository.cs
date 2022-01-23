namespace Microservice.NETCore.V6.Infrastructure.Dispatches;

public class DispatchesRepository : IDispatchesRepository
{
    private readonly IMapper _mapper;
    private readonly ILogger<DispatchesRepository> _logger;
    private readonly DispatchOptions _options;
    private readonly IHttpClientFactory _httpClientFactory;

    public DispatchesRepository(IMapper mapper, ILogger<DispatchesRepository> logger, IOptions<DispatchOptions> options, IHttpClientFactory httpClientFactory)
        => (_mapper, _logger, _options, _httpClientFactory) = (mapper, logger, options.Value, httpClientFactory);

    public async Task<IEnumerable<Dispatch>> GetDispatches(GetDispatchesQuery getDispatchesQuery)
    {
        _logger.LogInformation((int)Information.GetDispatchesInformation, "source: {@source}", this);

        var client = _httpClientFactory.CreateClient(_options.Name);

        var response = await client.GetAsync(_options.UrlGetAll);

        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            _logger.LogWarning((int)Warning.GetDispatchesWarning, "source: {@source} - error: {@error}", this, content);

            throw new BusinessException($"Warning: problem to get all dispatches", ((int)Warning.GetDispatchesWarning).ToString());
        }

        var data = JsonConvert.DeserializeObject<List<DispatchModelResponse>>(content);

        return _mapper.Map<List<Dispatch>>(data);
    }

    public async Task<Dispatch> GetDispatchesById(GetDispatchesByIdQuery getDispatchesByIdQuery)
    {
        _logger.LogInformation((int)Information.GetDispatchesByIdInformation, "source: {@source}", this);

        var client = _httpClientFactory.CreateClient(_options.Name);

        var response = await client.GetAsync($"{_options.UrlGetById}/{getDispatchesByIdQuery.Id.ToString().ToUpper()}");

        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            _logger.LogWarning((int)Warning.GetDispatchesByIdWarning, "source: {@source} - error: {@error}", this, content);

            throw new BusinessException($"Warning: problem to get by id dispatches", ((int)Warning.GetDispatchesByIdWarning).ToString());
        }

        var data = JsonConvert.DeserializeObject<DispatchModelResponse>(content);

        return _mapper.Map<Dispatch>(data);
    }
}