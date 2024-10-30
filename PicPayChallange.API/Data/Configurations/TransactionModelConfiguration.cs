using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PicPayChallange.API.Models;

namespace PicPayChallange.API.Data.Configurations {
    public class TransactionModelConfiguration : IEntityTypeConfiguration<TransactionModel> {
        public void Configure(EntityTypeBuilder<TransactionModel> builder) {

            builder.ToTable("transactions");

            builder.HasKey(x => x.Id);
            builder.Property(t => t.Amount)
                .HasColumnType("decimal(18,2)");

            builder
            .HasOne(t => t.Payer)                // Relacionamento com o remetente
            .WithMany()                           // Supondo que não há lista de transações no User
            .HasForeignKey(t => t.PayerId)       // Chave estrangeira no Transaction
            .OnDelete(DeleteBehavior.Restrict);   // Impede remoção em cascata para evitar erros de integridade

            // Configuração do relacionamento entre Transaction e User para o destinatário (Receiver)
            builder
            .HasOne(t => t.Payee)              // Relacionamento com o destinatário
            .WithMany()                           // Supondo que não há lista de transações no User
            .HasForeignKey(t => t.PayeeId)     // Chave estrangeira no Transaction
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
