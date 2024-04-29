using Diary.Domain.Entity;
using Diary.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.IdentityModel.Tokens;

namespace Diary.DAL.Configurations;

public class UserConfiguration:IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Login).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Password).IsRequired();

        builder.HasMany<Report>(x => x.Reports)
            .WithOne(report=>report.User)
            .HasForeignKey(report=>report.UserId)
            .HasPrincipalKey(x=>x.Id);
        
    }
}