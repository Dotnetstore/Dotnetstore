using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Http;
using SDK;
using SDK.Contracts.Organization.Users.Responses;

namespace Organization.Users.GetAll;

internal sealed class GetAllUserEndpoint(IUserService userService) : EndpointWithoutRequest<IEnumerable<UserResponse>>
{
    public override void Configure()
    {
        Get(ApiEndpoints.Organization.Users.GetAll);
        Description(b => b
            .WithDescription("Get all users")
            .AutoTagOverride("Organization/User"));
            // .WithTags("Organization/User"));
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var users = await userService.GetAllNotSystemAsync(ct);
        
        await SendAsync(users, statusCode: 200, ct);
    }
}