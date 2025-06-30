using FutManagement.Core.Enums;
using MediatR;

namespace FutManagement.Application.Features.Players.Commands.UpdatePlayer;

public record UpdatePlayerCommand(
    Guid Id,
    string FullName,
    string? NickName,
    DateTime DateOfBirth,
    Position Position,
    decimal MarketValue,
    MedicalStatus MedicalStatus,
    PlayerStatus PlayerStatus,
    Guid NationalityId,
    Guid? ClubId
) : IRequest<bool>;