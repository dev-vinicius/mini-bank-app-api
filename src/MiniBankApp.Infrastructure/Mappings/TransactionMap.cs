using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniBankApp.Domain.Entities;

namespace MiniBankApp.Infrastructure.Mappings
{
    internal class TransactionMap : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("transactions");

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.OriginAccountId)
                .HasColumnName("origin_account_id")
                .IsRequired();

            builder.Property(p => p.Value)
                .HasColumnName("value")
                .IsRequired();

            builder.Property(p => p.OperationType)
                .HasColumnName("operation_type")
                .IsRequired();

            builder.Property(p => p.DestinationAccountId)
                .HasColumnName("destination_account_id");

            builder.Property(p => p.CreateDate)
                .HasColumnName("create_date")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.UpdateDate)
                .HasColumnName("update_date")
                .ValueGeneratedOnAdd();

            builder.HasOne(p => p.OriginAccount)
                .WithMany(p => p.Transactions)
                .HasForeignKey(p => p.OriginAccountId);

            builder.HasOne(e => e.DestinationAccount)
                .WithMany()
                .HasForeignKey(e => e.DestinationAccountId);
        }
    }
}
