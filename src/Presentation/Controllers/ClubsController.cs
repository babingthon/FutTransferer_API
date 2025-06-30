using System.Net.Mime;
using FutManagement.Application.Features.Clubs.Commands.CreateClub;
using FutManagement.Application.Features.Clubs.Commands.DeleteClub;
using FutManagement.Application.Features.Clubs.Commands.UpdateClub;
using FutManagement.Application.Features.Clubs.Queries.Queries.GetAllClubs;
using FutManagement.Application.Features.Clubs.Queries.Queries.GetClubById;
using FutManagement.Application.Features.Clubs.Queries.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FutManagement.Presentation.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class ClubsController :ControllerBase
{
    private readonly ISender _sender;

    public ClubsController(ISender sender)
    {
        _sender = sender;
    }

    /// <summary>
    /// Gets a list of all clubs, optionally filtered by country.
    /// </summary>
    /// <param name="countryCode">The optional 3-letter country code (e.g., BRA, ESP) to filter by.</param>
    /// <returns>A list of clubs.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ClubResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllClubs([FromQuery] string? countryCode)
    {
        var query = new GetAllClubsQuery(countryCode);
        var clubs = await _sender.Send(query);
        return Ok(clubs);
    }
    
    /// <summary>
    /// Gets a club by its unique ID.
    /// </summary>
    /// <param name="id">The unique identifier of the club.</param>
    /// <returns>An object containing the club's details.</returns>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ClubResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetClubById(Guid id)
    {
        var query = new GetClubByIdQuery(id);
        var club = await _sender.Send(query);
        return club is not null ? Ok(club) : NotFound();
    }

    /// <summary>
    /// Creates a new club.
    /// </summary>
    /// <param name="command">The data for the new club.</param>
    /// <returns>The location of the newly created club.</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateClub([FromBody] CreateClubCommand command)
    {
        if (command is null)
        {
            return BadRequest("The request body is invalid or missing.");
        }
        
        var clubId = await _sender.Send(command);
        return CreatedAtAction(nameof(GetClubById), new { id = clubId }, null);
    }
   
    /// <summary>
    /// Updates an existing club.
    /// </summary>
    /// <param name="id">The ID of the club to update.</param>
    /// <param name="command">The updated data for the club.</param>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateClub(Guid id, [FromBody] UpdateClubCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest("ID in the route and body do not match.");
        }
        
        var result = await _sender.Send(command);
        return result ? NoContent() : NotFound();
    }

    /// <summary>
    /// Deletes a club by its unique ID.
    /// </summary>
    /// <param name="id">The ID of the club to delete.</param>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteClub(Guid id)
    {
        var command = new DeleteClubCommand(id);
        var result = await _sender.Send(command);
        return result ? NoContent() : NotFound();
    }
    
}