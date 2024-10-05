namespace Organization.Users;

internal interface IUserRepository
{
    ValueTask<List<User>> GetAllNotSystemAsync(CancellationToken ct);
    
    ValueTask<User?> GetByUsernameAsync(string username, CancellationToken ct);
    
    ValueTask<User?> GetByUserIdAsync(UserId userId, CancellationToken ct);
    
    void Create(User user);
    
    ValueTask SaveChangesAsync(CancellationToken ct);
}