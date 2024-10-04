using Microsoft.EntityFrameworkCore;
using Organization.Data;

namespace Organization.Users;

internal sealed class UserRepository(IOrganizationUnitOfWork unitOfWork) : IUserRepository
{
     async ValueTask<List<User>> IUserRepository.GetAllNotSystemAsync(CancellationToken ct)
     {
         return await unitOfWork
             .Repository<User>()
             .Entities
             .ToListAsync(ct);
     }
}