using Cooperchip.Observer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cooperchip.Observer.Infra.MapEntityTypes
{
    public class MensagensMap : IEntityTypeConfiguration<Mensagens>
    {
        public void Configure(EntityTypeBuilder<Mensagens> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Data).IsRequired().HasColumnType("datetime2");
            builder.Property(x => x.Mensagem).IsRequired().HasColumnType("varchar(255)");
        }
    }
}
