using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedProgrammingNew.Domain.Entities.Planification;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvancedProgrammingNew.DataAccess.FluentConfigurations.Planifications
{
    public class CalibrationEntityTypeConfigurationBase : IEntityTypeConfiguration<Calibration>
    {
        public void Configure(EntityTypeBuilder<Calibration> builder)
        {
            builder.ToTable("Calibrations");

            builder.HasBaseType(typeof(Planification));
        }
    }
}
