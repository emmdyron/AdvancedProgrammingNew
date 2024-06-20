using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedProgrammingNew.DataAccess.Contexts;
using AdvancedProgrammingNew.DataAccess.FluentConfigurations.Common;
using AdvancedProgrammingNew.Domain.Entities.Equipments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvancedProgrammingNew.DataAccess.FluentConfigurations.Equipments
{
    public class EquipmentEntityTypeConfigurationBase : EntityTypeConfigurationBase<Equipment>
    {
        public override void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.ToTable("Equipments");
            base.Configure(builder);

            builder.OwnsOne(e => e.PhysicalMagnitude);
        }
    }
}
