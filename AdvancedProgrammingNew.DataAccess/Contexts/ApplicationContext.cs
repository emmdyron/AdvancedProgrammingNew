﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqliteDbContextOptionsBuilderExtensions.UseSqlite(new DbContextOptionsBuilder(), connectionString).Options;
        }
    }
}