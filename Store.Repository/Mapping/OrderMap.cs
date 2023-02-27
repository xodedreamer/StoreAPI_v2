using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Models;
using Store.Repository.Config;
using Store.Repository.Mapping.Common;

namespace Store.Repository.Mapping
{
    internal class OrderMap : DbEntityConfiguration<Order>, IEntityMap
    {
        public override void Configure(EntityTypeBuilder<Order> entity)
        {
            entity.Property(c => c.Id).HasColumnName("Id");
            entity.Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}
