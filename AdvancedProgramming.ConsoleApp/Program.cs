using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.History;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Grpc.Net.Client;
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
using AdvancedProgrammingNew.Protos;



namespace AdvancedProgrammingNew.ConsoleApp
{
    internal class Program
{
        static void Main(string[] args)
        {

            Console.WriteLine("Press a key to connect");
            Console.ReadKey();

            Console.WriteLine("Creating channel");
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            var channel = GrpcChannel.ForAddress("https://localhost:7047", new GrpcChannelOptions { HttpHandler = httpHandler });
            if (channel is null)
            {
                Console.WriteLine("Cannot connect");
                channel.Dispose();
                return;
            }

            var client = new AdvancedProgrammingNew.Protos.Actuator.ActuatorClient(channel);

            Console.WriteLine("Press a key to create an Actuator");
            Console.ReadKey();

            var createResponse = client.CreateActuator(new CreateActuatorRequest()
            {
                Code = "1234",
                ManufacturerName = "Yamaha",
                PhysicalMagnitude = new Protos.PhysicalMagnitude()
                {
                    Name = "Temperature",
                    MeasurementUnit = "Celsius"
                },
                CodeAuto = "4321"
            });

            if (createResponse is null)
            {
                Console.WriteLine("Cannot create Actuator");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Succesful creation.");
            }

            Console.WriteLine($"Press a Key to get the Actuator with Id {createResponse.Id}");
            Console.ReadKey();
            var getByIdResponse = client.GetActuator(new GetRequest() { Id = createResponse.Id.ToString() });
            if (getByIdResponse is null)
            {
                Console.WriteLine("Cannot get actuator");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Succesfully obtained actuator {getByIdResponse.Actuator.Code}");
            }


            Console.WriteLine("Press a key for all Actuators");
            Console.ReadKey();
            var getResponse = client.GetAllActuator(new Google.Protobuf.WellKnownTypes.Empty());
            if (getResponse.Items is null)
            {
                Console.WriteLine("Cannot get");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Succesfully obtained {getResponse.Items.Count} Actuators");
            }


            Console.WriteLine("Press a key to delete an Actuator");
            Console.ReadKey();

            client.DeleteActuator(new DeleteRequest() { Id = createResponse.Id });
            var deletedGetResponse = client.GetActuator(new GetRequest() { Id = createResponse.Id });
            if (deletedGetResponse is null || deletedGetResponse.KindCase != NullableActuatorDTO.KindOneofCase.Actuator)
            {
                Console.WriteLine("Succesfully eliminated");
            }

            channel.Dispose();

        }




    }
}