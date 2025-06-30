namespace FutManagement.Core.Entities;

public class Club : BaseEntity
{
    public string Name { get; set; } = null!;
    public int FoundingYear { get; set; }
    public decimal TransferBudget { get; set; }
    
    public Guid CountryId { get; set; }
    public Country Country { get; set; } = null!;

    public ICollection<Player> Players { get; set; } = new List<Player>();
}