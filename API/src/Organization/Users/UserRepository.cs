using Microsoft.EntityFrameworkCore;
using Organization.Data;

namespace Organization.Users;

internal sealed class UserRepository(IOrganizationUnitOfWork unitOfWork) : IUserRepository
{
     private IQueryable<User> GetUserQuery()
     {
         return unitOfWork
             .Repository<User>()
             .Entities
             .OrderBy(x => x.LastName)
             .ThenBy(x => x.FirstName)
             .ThenBy(x => x.MiddleName)
             .ThenBy(x => x.EnglishName)
             .ThenBy(x => x.SocialSecurityNumber)
             .AsSplitQuery();
     }
     
     async ValueTask<List<User>> IUserRepository.GetAllNotSystemAsync(CancellationToken ct)
     {
         var query = GetUserQuery();
         
         return await query
             .AsNoTracking()
             .ToListAsync(ct);
     }

     async ValueTask<User?> IUserRepository.GetByUsernameAsync(string username, CancellationToken ct)
     {
         var query = GetUserQuery();
         
         return await query
             .Where(x => x.Username == username)
             .FirstOrDefaultAsync(ct);
     }

     async ValueTask<User?> IUserRepository.GetByUserIdAsync(UserId userId, CancellationToken ct)
     {
         var query = GetUserQuery();
         
         return await query
             .AsNoTracking()
             .FirstOrDefaultAsync(x => x.Id == userId, ct);
     }

     void IUserRepository.Create(User user)
     {
         unitOfWork.Repository<User>().Create(user);
     }

     async ValueTask IUserRepository.SaveChangesAsync(CancellationToken ct)
     {
         await unitOfWork.SaveChangesAsync(ct);
     }
}