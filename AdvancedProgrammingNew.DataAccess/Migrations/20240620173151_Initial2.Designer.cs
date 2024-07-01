﻿// <auto-generated />
using System;
using AdvancedProgrammingNew.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AdvancedProgrammingNew.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240620173151_Initial2")]
    partial class Initial2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.27");

            modelBuilder.Entity("AdvancedProgrammingNew.Domain.Entities.Equipments.Equipment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ManufacturerName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Equipments", (string)null);
                });

            modelBuilder.Entity("AdvancedProgrammingNew.Domain.Entities.Planification.Planification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("MaintenanceDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("OperatorName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Planifications", (string)null);
                });

            modelBuilder.Entity("AdvancedProgrammingNew.Domain.Entities.Equipments.Actuator", b =>
                {
                    b.HasBaseType("AdvancedProgrammingNew.Domain.Entities.Equipments.Equipment");

                    b.Property<string>("CodeAuto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDigital")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("MaintenanceId")
                        .HasColumnType("TEXT");

                    b.HasIndex("MaintenanceId");

                    b.ToTable("Actuators", (string)null);
                });

            modelBuilder.Entity("AdvancedProgrammingNew.Domain.Entities.Equipments.Sensor", b =>
                {
                    b.HasBaseType("AdvancedProgrammingNew.Domain.Entities.Equipments.Equipment");

                    b.Property<Guid?>("CalibrationId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Function")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Protocol")
                        .HasColumnType("INTEGER");

                    b.HasIndex("CalibrationId");

                    b.ToTable("Sensors", (string)null);
                });

            modelBuilder.Entity("AdvancedProgrammingNew.Domain.Entities.Planification.Calibration", b =>
                {
                    b.HasBaseType("AdvancedProgrammingNew.Domain.Entities.Planification.Planification");

                    b.ToTable("Calibrations", (string)null);
                });

            modelBuilder.Entity("AdvancedProgrammingNew.Domain.Entities.Planification.Maintenance", b =>
                {
                    b.HasBaseType("AdvancedProgrammingNew.Domain.Entities.Planification.Planification");

                    b.Property<int>("MaintenanceType")
                        .HasColumnType("INTEGER");

                    b.ToTable("Maintenances", (string)null);
                });

            modelBuilder.Entity("AdvancedProgrammingNew.Domain.Entities.Equipments.Equipment", b =>
                {
                    b.OwnsOne("AdvancedProgrammingNew.Domain.Entities.Types.PhysicalMagnitude", "PhysicalMagnitude", b1 =>
                        {
                            b1.Property<Guid>("EquipmentId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("MeasurementUnit")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("EquipmentId");

                            b1.ToTable("Equipments");

                            b1.WithOwner()
                                .HasForeignKey("EquipmentId");
                        });

                    b.Navigation("PhysicalMagnitude")
                        .IsRequired();
                });

            modelBuilder.Entity("AdvancedProgrammingNew.Domain.Entities.Equipments.Actuator", b =>
                {
                    b.HasOne("AdvancedProgrammingNew.Domain.Entities.Equipments.Equipment", null)
                        .WithOne()
                        .HasForeignKey("AdvancedProgrammingNew.Domain.Entities.Equipments.Actuator", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AdvancedProgrammingNew.Domain.Entities.Planification.Maintenance", null)
                        .WithMany("Actuators")
                        .HasForeignKey("MaintenanceId");
                });

            modelBuilder.Entity("AdvancedProgrammingNew.Domain.Entities.Equipments.Sensor", b =>
                {
                    b.HasOne("AdvancedProgrammingNew.Domain.Entities.Planification.Calibration", null)
                        .WithMany("Sensors")
                        .HasForeignKey("CalibrationId");

                    b.HasOne("AdvancedProgrammingNew.Domain.Entities.Equipments.Equipment", null)
                        .WithOne()
                        .HasForeignKey("AdvancedProgrammingNew.Domain.Entities.Equipments.Sensor", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AdvancedProgrammingNew.Domain.Entities.Planification.Calibration", b =>
                {
                    b.HasOne("AdvancedProgrammingNew.Domain.Entities.Planification.Planification", null)
                        .WithOne()
                        .HasForeignKey("AdvancedProgrammingNew.Domain.Entities.Planification.Calibration", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AdvancedProgrammingNew.Domain.Entities.Planification.Maintenance", b =>
                {
                    b.HasOne("AdvancedProgrammingNew.Domain.Entities.Planification.Planification", null)
                        .WithOne()
                        .HasForeignKey("AdvancedProgrammingNew.Domain.Entities.Planification.Maintenance", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AdvancedProgrammingNew.Domain.Entities.Planification.Calibration", b =>
                {
                    b.Navigation("Sensors");
                });

            modelBuilder.Entity("AdvancedProgrammingNew.Domain.Entities.Planification.Maintenance", b =>
                {
                    b.Navigation("Actuators");
                });
#pragma warning restore 612, 618
        }
    }
}