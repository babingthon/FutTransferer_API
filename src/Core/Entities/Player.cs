using FutManagement.Core.Enums;

namespace FutManagement.Core.Entities;

public class Player : BaseEntity
{
    public string FullName { get; set; } = null!;
    public string? Nickname { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Position Position { get; set; }
    public decimal MarketValue { get; set; }
    public MedicalStatus MedicalStatus { get; set; }
    public PlayerStatus PlayerStatus { get; set; }

    public int Age
    {
        get
        {
            var today = DateTime.Today;
            var age = today.Year - this.DateOfBirth.Year;
            if (DateOfBirth.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
    public Guid NationalityId { get; set; }
    public Country Nationality { get; set; } = null!;
    
    public Guid? ClubId { get; set; }
    public Club? Club { get; set; }
}