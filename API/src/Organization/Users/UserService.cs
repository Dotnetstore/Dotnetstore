using Organization.Users.Create;
using SDK.Contracts.Organization.Users.Requests;
using SDK.Contracts.Organization.Users.Responses;

namespace Organization.Users;

internal sealed class UserService(
    IUserRepository userRepository) : IUserService
{
    async ValueTask<IEnumerable<UserResponse>> IUserService.GetAllNotSystemAsync(CancellationToken ct)
    {
        var result = await userRepository
            .GetAllNotSystemAsync(ct);
        
        return result.Select(x => x.ToUserResponse()).ToList();
    }

    public async ValueTask<UserResponse?> CreateAsync(CreateUserRequest request, CancellationToken cancellationToken)
    {
        if (await UserExistsAsync(request.Username, cancellationToken))
            return null;
        
        var user = CreateUser(request);
         
        // await AddUserRolesAsync(user, cancellationToken);
        userRepository.Create(user);
        await userRepository.SaveChangesAsync(cancellationToken);

        return await GetUserById(user.Id, cancellationToken);
    }

    private async ValueTask<bool> UserExistsAsync(string username, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByUsernameAsync(username, cancellationToken);
        return user is not null;
    }

    private static User CreateUser(CreateUserRequest request)
    {
        return CreateUserBuilder
            .CreateNewUser()
            .CreateUserId()
            .SetPersonalData(request)
            .SetCredentials(request)
            .SetMetaData()
            .Build();
    }
     
    private async ValueTask<UserResponse?> GetUserById(
        UserId userId, 
        CancellationToken cancellationToken)
    {
        var createdUser = await userRepository.GetByUserIdAsync(userId, cancellationToken);

        return createdUser?.ToUserResponse();
    }
}