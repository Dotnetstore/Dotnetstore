using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Organization.Data;
using Organization.Users;
using SharedKernel.Extensions;

namespace Organization.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOrganization(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
        ArgumentException.ThrowIfNullOrWhiteSpace(connectionString, nameof(connectionString));
        
        services
            .AddScoped<IOrganizationUnitOfWork, OrganizationUnitOfWork>()
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IUserService, UserService>()
            .AddDbContext<OrganizationDataContext>(connectionString)
            .EnsureDbCreated<OrganizationDataContext>();
        
        return services;
    }
}