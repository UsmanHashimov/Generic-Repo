using Generic_Repo.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Generic_Repo.Infrastructure.Persistence
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
            => Database.Migrate();

        public virtual DbSet<User> Users { get; set; }
    }
}
