using FluentAssertions;
using FutManagement.Application.Common.Exceptions;
using FutManagement.Application.Features.Transfers.Commands.FinalizeTransfer;
using FutManagement.Application.Interfaces.Persistence;
using FutManagement.Core.Entities;
using FutManagement.Core.Enums;
using Hangfire;
using Hangfire.Common;
using MockQueryable.Moq;
using Moq;

namespace FutManagement.Application.UnitTests.Features.Transfers.Commands;

public class FinalizeTransferCommandHandlerTests
{
    private readonly Mock<IAppDbContext> _mockDbContext;
    private readonly Mock<IBackgroundJobClient> _mockBackgroundJobClient;
    private readonly FinalizeTransferCommandHandler _handler;

    private readonly Player _player;
    private readonly Club _originClub;
    private readonly Club _destinationClub;
    private readonly Transfer _pendingTransfer;
    private readonly List<Transfer> _transferList;

    public FinalizeTransferCommandHandlerTests()
    {
        _mockDbContext = new Mock<IAppDbContext>();
        _mockBackgroundJobClient = new Mock<IBackgroundJobClient>();
        _handler = new FinalizeTransferCommandHandler(_mockDbContext.Object, _mockBackgroundJobClient.Object);

        _player = new Player { Id = Guid.NewGuid(), FullName = "Kylian Mbappé", PlayerStatus = PlayerStatus.Active, MedicalStatus = MedicalStatus.Fit };
        _originClub = new Club { Id = Guid.NewGuid(), Name = "Paris Saint-Germain", TransferBudget = 100_000_000 };
        _destinationClub = new Club { Id = Guid.NewGuid(), Name = "Real Madrid", TransferBudget = 300_000_000 };
        _player.ClubId = _originClub.Id;

        _pendingTransfer = new Transfer
        {
            Id = Guid.NewGuid(),
            Player = _player,
            PlayerId = _player.Id,
            OriginClub = _originClub,
            OriginClubId = _originClub.Id,
            DestinationClub = _destinationClub,
            DestinationClubId = _destinationClub.Id,
            Status = TransferStatus.Pending,
            TransferValue = 180_000_000
        };
        
        _transferList = new List<Transfer> { _pendingTransfer };
        var mockTransferDbSet = _transferList.AsQueryable().BuildMockDbSet();
        _mockDbContext.Setup(x => x.Transfers).Returns(mockTransferDbSet.Object);
    }

    [Fact]
    public async Task Handle_Should_FinalizeTransferAndUpdateEntities_WhenTransferIsValid()
    {
        var command = new FinalizeTransferCommand(_pendingTransfer.Id);
        _mockDbContext.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

        var result = await _handler.Handle(command, CancellationToken.None);

        result.Should().BeTrue();
    
        _player.ClubId.Should().Be(_destinationClub.Id);
        _destinationClub.TransferBudget.Should().Be(120_000_000);
        _originClub.TransferBudget.Should().Be(280_000_000);
        _pendingTransfer.Status.Should().Be(TransferStatus.Completed);
    
        _mockDbContext.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);

        _mockBackgroundJobClient.Verify(x => x.Create(
                It.Is<Job>(job => job.Method.Name == nameof(Application.Interfaces.Services.IEmailService.SendTransferNotificationEmail)),
                It.IsAny<Hangfire.States.EnqueuedState>()),
            Times.Once);
    }

    [Fact]
    public async Task Handle_Should_ThrowBusinessRuleViolationException_WhenTransferIsAlreadyCompleted()
    {
        _pendingTransfer.Status = TransferStatus.Completed;
        var command = new FinalizeTransferCommand(_pendingTransfer.Id);

        Func<Task> action = async () => await _handler.Handle(command, CancellationToken.None);

        await action.Should().ThrowAsync<BusinessRuleViolationException>()
            .WithMessage($"Cannot finalize a transfer with status '{TransferStatus.Completed}'.");
    }

    [Fact]
    public async Task Handle_Should_ThrowNotFoundException_WhenTransferDoesNotExist()
    {
        var command = new FinalizeTransferCommand(Guid.NewGuid()); 

        Func<Task> action = async () => await _handler.Handle(command, CancellationToken.None);

        await action.Should().ThrowAsync<NotFoundException>();
    }
}