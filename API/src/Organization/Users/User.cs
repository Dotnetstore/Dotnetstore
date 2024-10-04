using SharedKernel.Models;

namespace Organization.Users;

internal sealed class User : Identity
{
    public UserId Id { get; set; }
}

internal record struct UserId(Guid Value);