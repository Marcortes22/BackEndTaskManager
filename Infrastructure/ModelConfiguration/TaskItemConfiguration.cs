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
    internal class TaskItemConfiguration : IEntityTypeConfiguration<TaskItem>
    {
        public void Configure(EntityTypeBuilder<TaskItem> builder)
        {
            builder.ToTable("TaskItems");
            builder.HasKey(u => u.Id);
            builder.HasOne(ti => ti.TaskList)
                .WithMany(tl => tl.TaskItems)
                .HasForeignKey(ti => ti.TaskListId);
        

            builder.Property(ti => ti.DueDate)
               .IsRequired(false);

            builder.Property(ti => ti.Completed)
               .IsRequired(false);

            builder.Property(ti => ti.Note)
              .IsRequired(false);

            builder.Property(ti => ti.AddedToMyDay)
              .IsRequired(false);

        }
    }
}