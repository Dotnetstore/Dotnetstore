namespace SharedKernel.Models;

public abstract class Person : BaseAuditableEntity
{
    public string LastName { get; init; } = null!;

    public string FirstName { get; init; } = null!;

    public string? MiddleName { get; init; }

    public string? EnglishName { get; init; }

    public string? SocialSecurityNumber { get; init; }

    public DateTime? DateOfBirth { get; init; }

    public bool IsMale { get; init; }

    public bool LastNameFirst { get; init; }

    public override string ToString()
    {
        if (LastNameFirst)
        {
            var name = $"{LastName}, {FirstName}";
            
            if (!string.IsNullOrEmpty(MiddleName))
            {
                name += $" {MiddleName}";
            }

            if (!string.IsNullOrEmpty(EnglishName))
            {
                name += $" ({EnglishName})";
            }
            
            return name;
        }
        else
        {
            var name = FirstName;
            
            if(!string.IsNullOrEmpty(MiddleName))
            {
                name += $" {MiddleName}";
            }
            
            name += $" {LastName}";
            
            if (!string.IsNullOrEmpty(EnglishName))
            {
                name += $" ({EnglishName})";
            }

            return name;
        }
    }
}