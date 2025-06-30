namespace FutManagement.Core.Entities;

public class PaymentInstallment : BaseEntity
{
    public Guid TransferId { get; set; }
    public decimal Amount { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsPaid { get; set; } = false;

    public Transfer Transfer { get; set; } = null!;
}