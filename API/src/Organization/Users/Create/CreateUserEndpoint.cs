using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Http;
using SDK;
using SDK.Contracts.Organization.Users.Requests;
using SDK.Contracts.Organization.Users.Responses;

namespace Organization.Users.Create;

internal sealed class CreateUserEndpoint(IUserService userService) : Endpoint<CreateUserRequest, UserResponse>
{
    public override void Configure()
    {
        Post(ApiEndpoints.Organization.Users.Create);
        Description(b => b
            .WithDescription("Create a new user")
            .AutoTagOverride("Organization/User"));
        Summary(s =>
        {
            s.ExampleRequest = new CreateUserRequest
            {
                Username = "test@test.com",
                FirstName = "Test",
                LastName = "Testsson",
                MiddleName = "Testare",
                EnglishName = "Testing",
                SocialSecurityNumber = "123456789",
                DateOfBirth = new DateTime(1971, 5, 20),
                IsMale = true,
                LastNameFirst = true,
                Password = "Test123!",
                ConfirmPassword = "Test123!"
            };
        });
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var result = await userService.CreateAsync(request, cancellationToken);

        if (result is null)
        {
            await SendNotFoundAsync(cancellationToken);
            return;
        }
        
        await SendAsync(result, statusCode: 201, cancellationToken);    

        // await SendCreatedAtAsync<GetByUserIdEndpoint>(new {result.Value.Id}, result.Value, cancellation: cancellationToken);
    }
}