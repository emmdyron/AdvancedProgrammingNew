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



namespace AdvancedProgrammingNew.ConsoleApp
{
    internal class Program
{
        static void Main(string[] args)
        {

            if (File.Exists("AdvancedProgrammingDB.sqlite"))
                File.Delete("AdvancedProgrammingDB.sqlite");


            // Creando un contexto para interacturar con la base de datos.
            ApplicationContext applicationContext = new ApplicationContext("Data Source = AdvancedProgrammingDB.sqlite");

            // Verificar si la BD no existe
            if (!applicationContext.Database.CanConnect())

            // Migrando base de datos. Este paso genera la BD con las tablas configuradas en su migracion.
            applicationContext.Database.Migrate();


            // Creando un primer actuador
            EquipmentRepository equipmentRepository = new EquipmentRepository(applicationContext);

            Actuator act1 = new Actuator("Alfa", "AlfaRomeo", new PhysicalMagnitude("Temperature", "Celsius"), 
                                         "2387", Guid.NewGuid());

            Sensor sens1 = new Sensor("Beta", "Mercedes", new PhysicalMagnitude("Pressure", "Bar"),
                                      "Pressure measuring", Protocol.BACNet, Guid.NewGuid());

            // Anadiendo al repositorio el actuador
            equipmentRepository.AddEquipment(act1);
            equipmentRepository.AddEquipment(sens1);

            // Salvando los cambios de la BD 
            applicationContext.SaveChanges();


            act1.ManufacturerName = "Siemens";

            applicationContext.Equipments.Update(act1);
            applicationContext.SaveChanges();

            applicationContext.Equipments.Remove(sens1);
            applicationContext.SaveChanges();

            // Prueba para ver si funciona la consola
            Console.WriteLine($"El equipamiento es de la marca {act1.ManufacturerName}");
        }




    }
}