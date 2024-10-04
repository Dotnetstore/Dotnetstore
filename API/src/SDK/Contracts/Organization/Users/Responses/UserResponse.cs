namespace SDK.Contracts.Organization.Users.Responses;

public record UserResponse(
    Guid Id,
    string Lastname,
    string Firstname,
    string? MiddleName,
    string? EnglishName,
    string? SocialSecurityNumber,
    DateTime? DateOfBirth,
    bool IsMale,
    bool LastNameFirst);