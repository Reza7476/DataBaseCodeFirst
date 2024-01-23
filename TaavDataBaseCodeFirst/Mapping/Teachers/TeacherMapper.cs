using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaavDataBaseCodeFirst;

public class TeacherMapper : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {



        builder.HasKey(x => x.Id);  
        builder.Property(t=>t.Id).ValueGeneratedOnAdd();
        builder.Property(t => t.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(t=>t.LastName)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasOne(t=>t.Group)
            .WithMany(g=>g.Teachers)
            .HasForeignKey(t => t.GroupId)
            .OnDelete (DeleteBehavior.Restrict);
    }
}
