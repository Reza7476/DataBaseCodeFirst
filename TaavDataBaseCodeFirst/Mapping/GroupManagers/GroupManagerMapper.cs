using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaavDataBaseCodeFirst.Mapping.GroupManagers;
public class GroupManagerMapper : IEntityTypeConfiguration<GroupManager>
{
    public void Configure(EntityTypeBuilder<GroupManager> builder)
    {

        builder.HasOne(g => g.Group)
            .WithOne(g => g.GroupManager)
            .HasForeignKey<GroupManager>(g => g.GroupId);



    }
}
