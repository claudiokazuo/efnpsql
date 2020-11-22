using Domain.Entities;
using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

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

            builder
                .HasOne(x => x.Document)
                .WithMany()
                .HasForeignKey(x => x.Id);    

            base.Configure(builder);
        }
    }
}
