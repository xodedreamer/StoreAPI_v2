using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Models;
using Store.Repository.Config;
using Store.Repository.Mapping.Common;

namespace Store.Repository.Mapping
{
    internal class ProductMap : DbEntityConfiguration<Product>, IEntityMap
    {
        public override void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.Property(c => c.Id).HasColumnName("Id");
            entity.Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}
