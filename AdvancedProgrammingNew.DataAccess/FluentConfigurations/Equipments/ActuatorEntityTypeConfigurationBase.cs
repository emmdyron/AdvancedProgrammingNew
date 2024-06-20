using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedProgrammingNew.Domain.Entities.Equipments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvancedProgrammingNew.DataAccess.FluentConfigurations.Equipments
{
    // Configurando la tabla de Actuadores
    public class ActuatorEntityTypeConfigurationBase : IEntityTypeConfiguration<Actuator>
    {
        public void Configure(EntityTypeBuilder<Actuator> builder)
        {
            builder.ToTable("Actuators");
            builder.HasBaseType(typeof(Equipment));
        }
    }
}
