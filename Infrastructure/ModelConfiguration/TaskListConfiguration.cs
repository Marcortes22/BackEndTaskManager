using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ModelConfiguration
{
    internal class TaskListConfiguration : IEntityTypeConfiguration<TaskList>
    {
        public void Configure(EntityTypeBuilder<TaskList> builder)
        {
            builder.ToTable("TaskLists");
            builder.HasKey(u => u.Id);
            builder.HasMany(tl => tl.TaskItems)
                .WithOne(ti => ti.TaskList).
                HasForeignKey(ti => ti.TaskListId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}