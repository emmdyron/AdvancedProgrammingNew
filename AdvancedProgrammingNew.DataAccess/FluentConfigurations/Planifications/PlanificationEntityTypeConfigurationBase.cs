using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedProgrammingNew.DataAccess.FluentConfigurations.Common;
using AdvancedProgrammingNew.Domain.Entities.Equipments;
using AdvancedProgrammingNew.Domain.Entities.Planification;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvancedProgrammingNew.DataAccess.FluentConfigurations.Planifications
{
    public class PlanificationEntityTypeConfigurationBase : EntityTypeConfigurationBase<Planification>
    {
        public override void Configure(EntityTypeBuilder<Planification> builder)
        {
            builder.ToTable("Planifications");
            base.Configure(builder);
        }
    }
}
