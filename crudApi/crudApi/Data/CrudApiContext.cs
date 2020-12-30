using crudApi.Common;
using crudApi.Interfaces;
using crudApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;

namespace crudApi.Data
{
    public class CrudApiContext : DbContext
    {
        public CrudApiContext(DbContextOptions<CrudApiContext> options) : base(options)
        {
        }

        public DbSet<ToDo> ToDo { get; set; }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            var dataChanges = ChangeTracker.Entries().Where(a => a.State == EntityState.Modified || a.State == EntityState.Added || a.State == EntityState.Deleted);

            if (dataChanges.Any())
            {
                dataChanges.ToList().ForEach(data => {
                    if (data.State != EntityState.Added)
                    {
                        data.Property("CreatedAt").IsModified = false;
                        data.Property("CreatedBy").IsModified = false;
                    }

                    var baseObject = data.Entity as IEntity;
                });
            }
            return base.SaveChanges();
        }
    }
}
