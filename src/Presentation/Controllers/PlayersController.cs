using System.Net.Mime;
using FutManagement.Application.Common.Models;
using FutManagement.Application.Features.Players.Commands.CreatePlayer;
using FutManagement.Application.Features.Players.Commands.DeletePlayer;
using FutManagement.Application.Features.Players.Commands.UpdatePlayer;
using FutManagement.Application.Features.Players.Queries.GetAllPlayers;
using FutManagement.Application.Features.Players.Queries.GetPlayerById;
using FutManagement.Application.Features.Players.Queries.Shared;
using FutManagement.Core.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FutManagement.Presentation.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class PlayersController : ControllerBase
{
    private readonly ISender _sender;

    public PlayersController(ISender sender)
    {
        _sender = sender;
    }

    /// <summary>
    /// Creates a new player.
    /// </summary>
    /// <param name="command">The data for the new player.</param>
    /// <returns>The location of the newly created player.</returns>
    /// <response code="201">Successfully created the player.</response>
    /// <response code="400">If the request data is invalid.</response>
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost]
    [Authorize(Roles = nameof(Role.Admin))]
    public async Task<IActionResult> CreatePlayer([FromBody] CreatePlayerCommand command)
    {
        var playerId = await _sender.Send(command);
        return CreatedAtAction(nameof(GetPlayerById), new { id = playerId }, null);
    }

    /// <summary>
    /// Gets a player by their unique ID.
    /// </summary>
    /// <param name="id">The unique identifier of the player.</param>
    /// <returns>An object containing the player's details.</returns>
    /// <response code="200">Returns the requested player.</response>
    /// <response code="404">If the player with the specified ID is not found.</response>
    [ProducesResponseType(typeof(PlayerResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetPlayerById(Guid id)
    {
        var query = new GetPlayerByIdQuery(id);
        var player = await _sender.Send(query);
        return player is not null ? Ok(player) : NotFound();
    }

    /// <summary>
    /// Gets a paginated list of players, with optional filters.
    /// </summary>
    /// <param name="pageNumber">The page number to retrieve. Defaults to 1.</param>
    /// <param name="pageSize">The number of records per page. Defaults to 10.</param>
    /// <param name="countryCode">Optional: Filters players by country code (e.g., BRA, ESP).</param>
    /// <param name="clubId">Optional: Filters players by a specific club ID.</param>
    /// <returns>A paginated list of players.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(PagedResponse<PlayerResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllPlayers(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string? countryCode = null,
        [FromQuery] Guid? clubId = null)
    {
        var query = new GetAllPlayersQuery(pageNumber, pageSize, countryCode, clubId);
        var result = await _sender.Send(query);
        return Ok(result);
    }

    /// <summary>
    /// Updates an existing player.
    /// </summary>
    /// <param name="id">The ID of the player to update.</param>
    /// <param name="command">The updated data for the player.</param>
    /// <response code="204">If the player was updated successfully.</response>
    /// <response code="400">If the ID in the route and body do not match.</response>
    /// <response code="404">If the player to update is not found.</response>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpPut("{id:guid}")]
    [Authorize(Roles = nameof(Role.Admin))]
    public async Task<IActionResult> UpdatePlayer(Guid id, [FromBody] UpdatePlayerCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest("ID in the route and body do not match.");
        }
        
        var result = await _sender.Send(command);
        return result ? NoContent() : NotFound();
    }

    /// <summary>
    /// Deletes a player by their unique ID.
    /// </summary>
    /// <param name="id">The ID of the player to delete.</param>
    /// <response code="204">If the player was deleted successfully.</response>
    /// <response code="404">If the player to delete is not found.</response>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = nameof(Role.Admin))]
    public async Task<IActionResult> DeletePlayer(Guid id)
    {
        var command = new DeletePlayerCommand(id);
        var result = await _sender.Send(command);
        return result ? NoContent() : NotFound();
    } 
    
}