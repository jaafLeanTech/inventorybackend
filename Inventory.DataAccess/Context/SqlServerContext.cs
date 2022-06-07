using Inventory.Entities.Entities;
using Microsoft.EntityFrameworkCore;


namespace Inventory.DataAccess.Context
{
    public class SqlServerContext : DbContext
    {
        private readonly string _connectionString = string.Empty;

        public SqlServerContext(DbContextOptions<SqlServerContext> options):base(options)
        {
            //_connectionString = @"Data Source = DESKTOP-V89KSU6\SQLEXPRESS; Initial Catalog = Inventory; Integrated Security = true";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articulo>().HasKey(c => new { c.IdArticulo });
            modelBuilder.Entity<Articulo>().Property(c => c.IdArticulo).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Articulo> Articulos { get; set; }
    }
}
