using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniBankApp.Domain.Entities;

namespace MiniBankApp.Infrastructure.Mappings
{
    internal class AccountMap : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("accounts");

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                .HasColumnName("name")
                .IsRequired();

            builder.Property(p => p.Balance)
                .HasColumnName("balance")
                .IsRequired();

            builder.Property(p => p.CreateDate)
                .HasColumnName("create_date")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.UpdateDate)
                .HasColumnName("update_date")
                .ValueGeneratedOnAdd();

            builder.HasMany(e => e.Transactions)
                .WithOne(e => e.OriginAccount)
                .HasForeignKey(e => e.OriginAccountId);
        }
    }
}
