using System.Net.Mime;
using FutManagement.Application.Features.Countries.Queries.GetAllCountries;
using FutManagement.Application.Features.Countries.Queries.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FutManagement.Presentation.Controllers;

[Authorize] 
[ApiController]
[Route("api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class CountriesController : ControllerBase
{
    private readonly ISender _sender;

    public CountriesController(ISender sender)
    {
        _sender = sender;
    }

    /// <summary>
    /// Gets a list of all available countries.
    /// </summary>
    /// <returns>A list of countries.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CountryResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllCountries()
    {
        var query = new GetAllCountriesQuery();
        var countries = await _sender.Send(query);
        return Ok(countries);
    }
}