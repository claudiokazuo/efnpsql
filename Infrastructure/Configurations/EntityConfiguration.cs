﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Entities;

namespace Infrastructure.Configurations
{
    public abstract class EntityConfiguration<T> : IEntityTypeConfiguration<T> where T : Entity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder
                .HasKey(builder => builder.Id);

            builder
                .Property(builder => builder.Id)
                .HasColumnName("id");

            builder
                .Property(builder => builder.CreatedOn)
                .HasColumnName("dt_createdon");

            builder
                .Property(builder => builder.UpdatedOn)
                .HasColumnName("dt_updatedon");

            builder
                .Property(builder => builder.IsActive)
                .HasColumnName("bl_active");
        }
    }
}
