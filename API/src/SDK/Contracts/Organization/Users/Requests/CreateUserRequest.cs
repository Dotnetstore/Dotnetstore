namespace SDK.Contracts.Organization.Users.Requests;

public record struct CreateUserRequest(
    string LastName,
    string FirstName,
    string? MiddleName,
    string? EnglishName,
    string? SocialSecurityNumber,
    DateTime? DateOfBirth,
    bool IsMale,
    bool LastNameFirst,
    string Username,
    string Password,
    string ConfirmPassword);