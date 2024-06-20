using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedProgrammingNew.DataAccess.FluentConfigurations.Equipments;
using AdvancedProgrammingNew.DataAccess.FluentConfigurations.Planifications;
using AdvancedProgrammingNew.Domain.Entities.Equipments;
using AdvancedProgrammingNew.Domain.Entities.Planification;
using Microsoft.EntityFrameworkCore;

namespace AdvancedProgrammingNew.DataAccess.Contexts
{
    public class ApplicationContext : DbContext
    {
        #region Tables

        public DbSet<Equipment> Equipments { get; set; }

        public DbSet<Maintenance> Maintenances { get; set; }

        public DbSet<Calibration> Calibrations { get; set; }

        #endregion

        /// <summary>
        /// Requerido por EntityFrameworkCore
        /// </summary>
        public ApplicationContext() { }

        /// <summary>
        /// Inicializa un objeto ApplicationContext
        /// </summary>
        /// <param name="connectionString"></param>
        public ApplicationContext(string connectionString) : base(GetOptions(connectionString)) { }

        /// <summary>
        /// Inicializa un objeto ApplicationContext
        /// </summary>
        /// <param name="options"></param>
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new EquipmentEntityTypeConfigurationBase());
            modelBuilder.ApplyConfiguration(new ActuatorEntityTypeConfigurationBase());
            modelBuilder.ApplyConfiguration(new SensorEntityTypeConfigurationBase());
            modelBuilder.ApplyConfiguration(new PlanificationEntityTypeConfigurationBase());
            modelBuilder.ApplyConfiguration(new CalibrationEntityTypeConfigurationBase());
            modelBuilder.ApplyConfiguration(new MaintenanceEntityTypeConfigurationBase());
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqliteDbContextOptionsBuilderExtensions.UseSqlite(new DbContextOptionsBuilder(), connectionString).Options;
        }
    }
}
