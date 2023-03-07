using Cooperchip.Observer.Domain.Entities;
using Cooperchip.Observer.Domain.Repositories.UoW;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Cooperchip.Observer.Infra.Data
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(90)");
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientNoAction;

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Mensagens> Mensagens { get; set; }

        public async Task<bool> Commit()
        {
            var sucesso = await base.SaveChangesAsync() > 0;
            // Podemos criar um evento.
            return sucesso;
        }

    }
}

//protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
//{
//    configurationBuilder.Properties<string>().AreUnicode(false)
//        .HaveMaxLength(90);

//    base.ConfigureConventions(configurationBuilder);
//}
