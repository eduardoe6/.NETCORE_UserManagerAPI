using Microsoft.EntityFrameworkCore;
using Manager.Domain.Entities;

namespace Manager.Infra.Context
{
    public class ManagerContext : DbContext
    {
        public ManagerContext()
        { }

        public ManagerContext(DbContextOptions<ManagerContext> options) : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
    }
}