using Cooperchip.Observer.Mvc.Infra.Repository;
using Cooperchip.Observer.Mvc.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Cooperchip.Observer.Mvc.Infra.Data
{
    public class ApplicationDbContext : DbContext
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
    }
}

//protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
//{
//    configurationBuilder.Properties<string>().AreUnicode(false)
//        .HaveMaxLength(90);

//    base.ConfigureConventions(configurationBuilder);
//}
