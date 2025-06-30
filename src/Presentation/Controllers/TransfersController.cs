using System.Net.Mime;
using FutManagement.Application.Features.Transfers.Commands.FinalizeTransfer;
using FutManagement.Application.Features.Transfers.Commands.InitiateTransfer;
using FutManagement.Application.Features.Transfers.Queries.GetTransfersByDateRange;
using FutManagement.Application.Features.Transfers.Queries.Shared;
using FutManagement.Core.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FutManagement.Presentation.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class TransfersController : ControllerBase
{
    private readonly ISender _sender;

    public TransfersController(ISender sender)
    {
        _sender = sender;
    }
    
    /// <summary>
    /// Gets a list of transfers, optionally filtered by a date range.
    /// </summary>
    /// <param name="startDate">The start date of the range to search for.</param>
    /// <param name="endDate">The end date of the range to search for.</param>
    /// <returns>A list of transfers matching the criteria.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<TransferResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTransfers([FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
    {
        var query = new GetTransfersByDateRangeQuery(startDate, endDate);
        var transfers = await _sender.Send(query);
        return Ok(transfers);
    }

    /// <summary>
    /// Initiates a new player transfer proposal.
    /// </summary>
    /// <param name="command">The details of the transfer proposal.</param>
    /// <returns>The ID of the newly created transfer record.</returns>
    /// <response code="201">If the transfer proposal was successfully created.</response>
    /// <response code="400">If there is a validation or business rule violation.</response>
    /// <response code="404">If the player or one of the clubs is not found.</response>
    [HttpPost("initiate")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [Authorize(Roles = $"{nameof(Role.Admin)},{nameof(Role.Agent)}")]
    public async Task<IActionResult> InitiateTransfer([FromBody] InitiateTransferCommand command)
    {
        var transferId = await _sender.Send(command);
        return CreatedAtAction(null, new { id = transferId }, new { transferId });
    }
    
    /// <summary>
    /// Finalizes a pending transfer, moving the player and adjusting budgets.
    /// </summary>
    /// <param name="id">The ID of the transfer to finalize.</param>
    /// <response code="204">If the transfer was finalized successfully.</response>
    /// <response code="400">If a business rule is violated (e.g., insufficient budget).</response>
    /// <response code="404">If the transfer is not found.</response>
    [HttpPost("{id:guid}/finalize")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [Authorize(Roles = $"{nameof(Role.Admin)},{nameof(Role.ClubDirector)}")]
    public async Task<IActionResult> FinalizeTransfer(Guid id)
    {
        var command = new FinalizeTransferCommand(id);
        await _sender.Send(command);
        return NoContent();
    }
}