using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Maps
{
    public class DocumentMap : EntityConfiguration<Domain.Entities.Document>
    {
        public override void Configure(EntityTypeBuilder<Domain.Entities.Document> builder)
        {
            builder
                .ToTable("tb_document");

            builder
                .Property(builder => builder.DocumentTypeId)
                .HasColumnName("id_documenttype");

            builder
                .Property(builder => builder.PersonId)
                .HasColumnName("id_person");

            builder
                .Property(builder => builder.Number)
                .HasColumnName("tx_number");

            base.Configure(builder);
        }
    }
}
