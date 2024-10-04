using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SharedKernel.Models;

namespace Organization.Users;

internal sealed class UserConfiguration : PersonConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);
        
        var converter = new ValueConverter<UserId, Guid>(
            id => id.Value, 
            guid => new UserId(guid));

        builder
            .HasIndex(x => x.Id)
            .IsUnique()
            .HasDatabaseName("Index_Id");
        
        builder
            .HasKey(x => x.Id);
        
        builder
            .Property(x => x.Id)
            .HasConversion(converter)
            .ValueGeneratedNever()
            .IsRequired();

        // builder
        //     .HasData(
        //         UserBuilder.Create()
        //             .WithUserId(new UserId(Constants.SystemUserId))
        //             .WithUsername("hasse29@hotmail.com")
        //             .WithPassword("7101263924".Hash("Salt1", "Salt2", "Salt3", "Salt4"))
        //             .WithSalt1("Salt1")
        //             .WithSalt2("Salt2")
        //             .WithSalt3("Salt3")
        //             .WithSalt4("Salt4")
        //             .WithIsBlocked(false)
        //             .WithLastName("Sjödin")
        //             .WithFirstName("Hans")
        //             .WithMiddleName("Mikael")
        //             .WithEnglishName("hasse")
        //             .WithDateOfBirth(new DateTime(1971, 5, 20))
        //             .WithIsMale(true)
        //             .WithLastNameFirst(true)
        //             .WithCreatedDate(DateTimeOffset.Now)
        //             .WithIsSystem(true)
        //             .WithIsGdpr(false)
        //             .Build());
    }
}