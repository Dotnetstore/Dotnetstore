using SDK.Contracts.Organization.Users.Responses;

namespace Organization.Users;

internal interface IUserService
{
    ValueTask<IEnumerable<UserResponse>> GetAllNotSystemAsync(CancellationToken ct);
}