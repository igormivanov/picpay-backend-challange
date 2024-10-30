using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PicPayChallange.API.Models;

namespace PicPayChallange.API.Data.Configurations {
    public class UserModelConfiguration : IEntityTypeConfiguration<UserModel> {
        public void Configure(EntityTypeBuilder<UserModel> builder) {
            
            builder.ToTable("users");

            builder.HasKey(x => x.Id);
            builder.HasIndex(w => new { w.Email, w.CPF }).IsUnique();
            builder.Property(u => u.UserType).HasConversion<string>();

            builder.HasOne(u => u.Wallet)
                .WithOne(w => w.User)
                .HasForeignKey<WalletModel>(w => w.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
