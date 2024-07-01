using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.History;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using AdvancedProgrammingNew.DataAccess;
using AdvancedProgrammingNew.DataAccess.Contexts;
using AdvancedProgrammingNew.DataAccess.FluentConfigurations.Equipments;
using AdvancedProgrammingNew.DataAccess.Repositories.Equipments;
using AdvancedProgrammingNew.Domain.Entities.Equipments;
using AdvancedProgrammingNew.Domain.Entities.Types;
using Microsoft.EntityFrameworkCore;
using AdvancedProgrammingNew.Contracts.Equipments;
using AdvancedProgrammingNew.Contracts;
using AdvancedProgrammingNew.Contracts.Planifications;
using AdvancedProgrammingNew.DataAccess.Repositories.Planifications;
using AdvancedProgrammingNew.Domain.Entities.Planification;



namespace AdvancedProgrammingNew.ConsoleApp
{
    internal class Program
{
        static void Main(string[] args)
        {

            if (File.Exists("AdvancedProgrammingDB.sqlite"))
                File.Delete("AdvancedProgrammingDB.sqlite");

            string connectionString = "Data Source = AdvancedProgrammingDB.sqlite";


            // Creando un contexto para interacturar con la base de datos.
            ApplicationContext context = new ApplicationContext(connectionString);

            // Verificar si la BD no existe
            if (!context.Database.CanConnect())

            // Migrando base de datos. Este paso genera la BD con las tablas configuradas en su migracion.
            context.Database.Migrate();


            // Creando instancias
            IUnitOfWork unitOfWork = new UnitOfWork(context);
            IEquipmentRepository equipmentRepository = new EquipmentRepository(context);
            IPlanificationRepository planificationRepository = new PlanificationRepository(context);


            Actuator act1 = new Actuator("Alfa", "AlfaRomeo", new PhysicalMagnitude("Temperature", "Celsius"), 
                                         "2387", Guid.NewGuid());

            Sensor sens1 = new Sensor("Beta", "Mercedes", new PhysicalMagnitude("Pressure", "Bar"),
                                      "Pressure measuring", Protocol.BACNet, Guid.NewGuid());

            Maintenance mant = new Maintenance("Carlos Perez", Guid.NewGuid());

            // Anadiendo al repositorio el actuador
            equipmentRepository.AddEquipment(act1);
            equipmentRepository.AddEquipment(sens1);
            planificationRepository.AddPlanification(mant);

            // Salvando los cambios de la BD 
            unitOfWork.SaveChanges();


            act1.ManufacturerName = "Siemens";

            context.Equipments.Update(act1);
            context.SaveChanges();

            context.Equipments.Remove(sens1);
            context.SaveChanges();

            // Prueba para ver si funciona la consola
            Console.WriteLine($"El equipamiento es de la marca {act1.ManufacturerName}");
        }




    }
}