using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PicPayChallange.API.Models;

namespace PicPayChallange.API.Data.Configurations {
    public class UserModelConfiguration : IEntityTypeConfiguration<UserModel> {
        public void Configure(EntityTypeBuilder<UserModel> builder) {
            
            builder.ToTable("users");

            builder.HasKey(u => u.Id);
            builder.HasIndex(u => new { u.Email, u.CPF }).IsUnique();
            builder.Property(u => u.UserType).HasConversion<string>();

            builder.Property(u => u.Balance)
                .HasColumnType("decimal(18,2)");
        }
    }
}
