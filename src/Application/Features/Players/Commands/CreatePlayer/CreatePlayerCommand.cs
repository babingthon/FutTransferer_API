using FutManagement.Core.Enums;
using MediatR;

namespace FutManagement.Application.Features.Players.Commands.CreatePlayer;

public record CreatePlayerCommand(
    string FullName,
    string? NickName,
    DateTime DateOfBirth,
    Position Position,
    decimal MarketValue,
    MedicalStatus MedicalStatus,
    PlayerStatus PlayerStatus,
    Guid NationalityId,
    Guid? ClubId
    ) : IRequest<Guid>;