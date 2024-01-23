using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaavDataBaseCodeFirst;

public class GroupMapper : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
       

        builder.Property(g=>g.Name)
            .HasMaxLength(50);

    }
}
