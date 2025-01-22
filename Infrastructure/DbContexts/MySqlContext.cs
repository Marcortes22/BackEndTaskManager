using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DbContexts
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<TaskList> TaskLists { get; set; }
        public DbSet<TaskItem> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //modelBuilder.Entity<User>()
            //    .HasMany(u => u.TaskLists)
            //    .WithOne(tl => tl.User)
            //    .HasForeignKey(tl => tl.UserId);


            //modelBuilder.Entity<TaskList>()
            //    .HasMany(tl => tl.TaskItems)
            //    .WithOne(ti => ti.TaskList).
            //    HasForeignKey(ti => ti.TaskListId);

            //modelBuilder.Entity<TaskItem>().HasOne(ti => ti.TaskList)
            //    .WithMany(tl => tl.TaskItems)
            //    .HasForeignKey(ti => ti.TaskListId);
        }
    }
}
