using Microsoft.EntityFrameworkCore;

namespace SharedKernel.Abstracts;

public abstract class ApiContext<T>(DbContextOptions<T> options) : DbContext(options) where T : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ISharedKernelAssemblyMarker).Assembly);
    }
}