using Microsoft.EntityFrameworkCore;
using APIModels;

namespace YempoRespiriExam.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Person> Person { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Person>().HasKey(x => x.Id);
        }
    }
}
