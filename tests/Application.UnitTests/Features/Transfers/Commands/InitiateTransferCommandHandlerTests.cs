using FluentAssertions;
using FutManagement.Application.Common.Exceptions;
using FutManagement.Application.Features.Transfers.Commands.InitiateTransfer;
using FutManagement.Application.Interfaces.Persistence;
using FutManagement.Core.Entities;
using FutManagement.Core.Enums;
using MockQueryable.Moq;
using Moq;

namespace FutManagement.Application.UnitTests.Features.Transfers.Commands;

public class InitiateTransferCommandHandlerTests
{
    private readonly Mock<IAppDbContext> _mockDbContext;
    private readonly InitiateTransferCommandHandler _handler;

    private readonly Player _validPlayer;
    private readonly Club _originClub;
    private readonly Club _destinationClub;
    private readonly List<Player> _playerList;
    private readonly List<Club> _clubList;

    public InitiateTransferCommandHandlerTests()
    {
        _mockDbContext = new Mock<IAppDbContext>();
        _handler = new InitiateTransferCommandHandler(_mockDbContext.Object);

        _originClub = new Club { Id = Guid.NewGuid(), Name = "Origin Club FC", TransferBudget = 100000000 };
        _destinationClub = new Club { Id = Guid.NewGuid(), Name = "Destination Club FC", TransferBudget = 100000000 };
        _validPlayer = new Player
        {
            Id = Guid.NewGuid(),
            PlayerStatus = PlayerStatus.Active,
            MedicalStatus = MedicalStatus.Fit,
            ClubId = _originClub.Id
        };

        _playerList = new List<Player> { _validPlayer };
        _clubList = new List<Club> { _originClub, _destinationClub };
        
        var mockPlayerDbSet = _playerList.AsQueryable().BuildMockDbSet();
        var mockClubDbSet = _clubList.AsQueryable().BuildMockDbSet();

        _mockDbContext.Setup(x => x.Players).Returns(mockPlayerDbSet.Object);
        _mockDbContext.Setup(x => x.Clubs).Returns(mockClubDbSet.Object);
    }

    [Fact]
    public async Task Handle_Should_CreatePendingTransfer_WhenAllRulesPass()
    {
        var transfersList = new List<Transfer>();
        _mockDbContext.Setup(x => x.Transfers.AddAsync(It.IsAny<Transfer>(), It.IsAny<CancellationToken>()))
            .Callback<Transfer, CancellationToken>((transfer, token) => transfersList.Add(transfer));
        _mockDbContext.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

        var command = new InitiateTransferCommand(_validPlayer.Id, _originClub.Id, _destinationClub.Id, 50000000, TransferType.Permanent, PaymentType.LumpSum, 1);

        var result = await _handler.Handle(command, CancellationToken.None);

        result.Should().NotBeEmpty();
        transfersList.Should().HaveCount(1);
        transfersList[0].Status.Should().Be(TransferStatus.Pending);
    }

    [Fact]
    public async Task Handle_Should_ThrowBusinessRuleViolationException_WhenDestinationClubHasInsufficientBudget()
    {
        _destinationClub.TransferBudget = 100000; 
        var command = new InitiateTransferCommand(_validPlayer.Id, _originClub.Id, _destinationClub.Id, 200000, TransferType.Permanent, PaymentType.LumpSum, 1);

        Func<Task> action = async () => await _handler.Handle(command, CancellationToken.None);

        await action.Should().ThrowAsync<BusinessRuleViolationException>()
            .WithMessage($"Destination club '{_destinationClub.Name}' has insufficient budget. Required: 200000, Available: 100000.");
    }
    
    [Fact]
    public async Task Handle_Should_ThrowBusinessRuleViolationException_WhenPlayerIsInjured()
    {
        _validPlayer.MedicalStatus = MedicalStatus.Injured;
        var command = new InitiateTransferCommand(_validPlayer.Id, _originClub.Id, _destinationClub.Id, 1000, TransferType.Permanent, PaymentType.LumpSum, 1);
 
        Func<Task> action = async () => await _handler.Handle(command, CancellationToken.None);

        await action.Should().ThrowAsync<BusinessRuleViolationException>()
            .WithMessage("Cannot transfer an injured player.");
    }

    [Fact]
    public async Task Handle_Should_ThrowNotFoundException_WhenPlayerDoesNotExist()
    {
        var nonExistentPlayerId = Guid.NewGuid();
        var command = new InitiateTransferCommand(nonExistentPlayerId, _originClub.Id, _destinationClub.Id, 1000, TransferType.Permanent, PaymentType.LumpSum, 1);
      
        Func<Task> action = async () => await _handler.Handle(command, CancellationToken.None);

        await action.Should().ThrowAsync<NotFoundException>();
    }
}