
namespace TranslationManagement.Api
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Call> Calls { get; set; }
        public DbSet<ImportFile> ImportFiles { get; set; }
    }
}