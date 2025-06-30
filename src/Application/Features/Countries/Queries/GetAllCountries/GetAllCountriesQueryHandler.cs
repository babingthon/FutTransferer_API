using FutManagement.Application.Features.Countries.Queries.Shared;
using FutManagement.Application.Interfaces.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace FutManagement.Application.Features.Countries.Queries.GetAllCountries;

public class GetAllCountriesQueryHandler: IRequestHandler<GetAllCountriesQuery, IEnumerable<CountryResponse>>
{
    private readonly IAppDbContext _context;
    private readonly IMemoryCache _cache;
    private readonly ILogger<GetAllCountriesQueryHandler> _logger;
    private const string CountriesCacheKey = "CountriesList";


    public GetAllCountriesQueryHandler(IAppDbContext context, IMemoryCache cache, ILogger<GetAllCountriesQueryHandler> logger)
    {
        _context = context;
        _cache = cache;
        _logger = logger;
    }
    
    public async Task<IEnumerable<CountryResponse>> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
    {
        if (_cache.TryGetValue(CountriesCacheKey, out IEnumerable<CountryResponse>? countries))
        {
            _logger.LogInformation("Fetching countries from cache.");
            return countries!;
        }

        _logger.LogInformation("Cache empty. Fetching countries from database.");

        var countriesFromDb = await _context.Countries
            .AsNoTracking()
            .OrderBy(c => c.Name) 
            .Select(c => new CountryResponse(c.Id, c.Name, c.Code)) 
            .ToListAsync(cancellationToken);

        var cacheOptions = new MemoryCacheEntryOptions()
            .SetAbsoluteExpiration(TimeSpan.FromMinutes(10));

        _cache.Set(CountriesCacheKey, countriesFromDb, cacheOptions);
        return countriesFromDb;
    }
}