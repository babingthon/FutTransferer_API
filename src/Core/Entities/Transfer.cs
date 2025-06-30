using System.Security.AccessControl;
using FutManagement.Core.Enums;

namespace FutManagement.Core.Entities;

public class Transfer : BaseEntity
{
    public Guid PlayerId { get; set; }
    public Guid OriginClubId { get; set; }
    public Guid DestinationClubId { get; set; }

    public decimal TransferValue { get; set; }
    public DateTime TransferDate { get; set; }
    public TransferStatus Status { get; set; }
    public TransferType Type { get; set; }
    
    public PaymentType PaymentType { get; set; }
    public int NumberOfInstallments { get; set; }

    public Player Player { get; set; } = null!;
    public Club OriginClub { get; set; } = null!;
    public Club DestinationClub { get; set; } = null!;
    
    public ICollection<PaymentInstallment> Installments { get; set; } = new List<PaymentInstallment>();
}