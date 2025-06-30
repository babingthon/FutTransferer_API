using System.Net.Mime;
using FutManagement.Application.Features.Auth.Commands.Register;
using FutManagement.Application.Features.Auth.Queries.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FutManagement.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class AuthController : ControllerBase
{
    private readonly ISender _sender;

    public AuthController(ISender sender)
    {
        _sender = sender;
    }

    /// <summary>
    /// Registers a new user in the system.
    /// </summary>
    /// <param name="command">The user's registration details, including first name, last name, email, password, and role.</param>
    /// <returns>The unique identifier of the newly created user.</returns>
    /// <response code="201">Returns the newly created user's ID.</response>
    /// <response code="400">If the request data is invalid (e.g., email already exists, password is too short).</response>
    [HttpPost("register")]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(RegisterCommand command)
    {
        var userId = await _sender.Send(command);
        return Ok(new { UserId = userId });
    }
    
    /// <summary>
    /// Authenticates a user and returns a JWT token.
    /// </summary>
    /// <param name="query">The user's login credentials.</param>
    /// <returns>The authenticated user's details and a JWT token.</returns>
    /// <response code="200">If the credentials are valid and a token is returned.</response>
    /// <response code="400">If the credentials are invalid.</response>
    [HttpPost("login")]
    [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login(LoginQuery query)
    {
        var result = await _sender.Send(query);
        return Ok(result);
    }
}