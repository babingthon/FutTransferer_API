using FutManagement.Application.Features.Countries.Queries.Shared;
using MediatR;

namespace FutManagement.Application.Features.Countries.Queries.GetAllCountries;

public record GetAllCountriesQuery() : IRequest<IEnumerable<CountryResponse>>;