using Microsoft.EntityFrameworkCore;

namespace CRUD_operations.Models
{
    public class FileContext : DbContext
    {
        public DbSet<FileModel> Files { get; set; }

        public FileContext(DbContextOptions<FileContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }


}
