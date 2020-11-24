using Domain.Entities;
using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Maps
{
    public class DocumenTypeMap : EntityConfiguration<DocumentType>
    {

        public override void Configure(EntityTypeBuilder<DocumentType> builder)
        {
            builder.
                ToTable("tb_documenttype");

            builder
                .Property(builder => builder.Name)
                .HasColumnName("tx_name");

            base.Configure(builder);
        }
    }
}
