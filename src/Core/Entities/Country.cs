namespace FutManagement.Core.Entities;

public class Country : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
    
    public ICollection<Player> Players { get; set; } = new List<Player>();
    public ICollection<Club> Clubs { get; set; } = new List<Club>();
}