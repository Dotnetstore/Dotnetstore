using SDK.Contracts.Organization.Users.Requests;
using SDK.Contracts.Organization.Users.Responses;

namespace Organization.Users;

internal interface IUserService
{
    ValueTask<IEnumerable<UserResponse>> GetAllNotSystemAsync(CancellationToken ct);
    
    ValueTask<UserResponse?> CreateAsync(CreateUserRequest request, CancellationToken cancellationToken);
}