using Domain.Entities;
using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Maps
{
    public class PersonMap : EntityConfiguration<Person>
    {
        public override void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.
                ToTable("tb_person");

            builder
                .Property(builder => builder.Name)
                .HasColumnName("tx_name");

            builder
                .Property(builder => builder.Email)
                .HasColumnName("tx_email");

            builder
                .HasMany(x => x.Documents)
                .WithOne(x => x.Person)
                .HasForeignKey(x => x.PersonId);

            base.Configure(builder);

        }
    }
}
