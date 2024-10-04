using SDK.Contracts.Organization.Users.Responses;

namespace Organization.Users;

internal static class UserMappers
{
    internal static UserResponse ToUserResponse(this User user)
    {
        return new UserResponse(
            user.Id.Value,
            user.LastName,
            user.FirstName,
            user.MiddleName,
            user.EnglishName,
            user.SocialSecurityNumber,
            user.DateOfBirth,
            user.IsMale,
            user.LastNameFirst
        );
    }
}