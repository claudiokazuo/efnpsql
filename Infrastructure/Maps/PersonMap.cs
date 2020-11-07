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
                ToTable("person");

            builder
                .Property(builder => builder.Name)
                .HasColumnName("name");

            builder
                .Property(builder => builder.Email)
                .HasColumnName("email");

            base.Configure(builder);

        }
    }
}
