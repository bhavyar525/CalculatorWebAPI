using Microsoft.EntityFrameworkCore;

namespace CalculatorWebAPI
{
    public class CalculatorContext:DbContext
    {
        public CalculatorContext(DbContextOptions<CalculatorContext> options) : base(options) { }

        string connection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BhavyaDB;Trust Server Certificate=True;Integrated Security=True";
        public DbSet<Calculator> Calculators { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connection);
        }
    }
}
