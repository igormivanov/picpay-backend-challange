using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PicPayChallange.API.Models;

namespace PicPayChallange.API.Data.Configurations {
    public class WalletModelConfiguration : IEntityTypeConfiguration<WalletModel> {
        public void Configure(EntityTypeBuilder<WalletModel> builder) {

            builder.ToTable("wallets");
            builder.HasKey(w => w.Id);

            builder.Property(w => w.Balance)
                .HasColumnType("decimal(18,2)");
        }
    }
}
