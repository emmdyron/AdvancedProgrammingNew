using AdvancedProgrammingNew.Servicess.Services;
using AdvancedProgrammingNew.Application;
using AdvancedProgrammingNew.Contracts;
using AdvancedProgrammingNew.Contracts.Equipments;
using AdvancedProgrammingNew.Contracts.Planifications;
using AdvancedProgrammingNew.DataAccess;
using AdvancedProgrammingNew.DataAccess.Contexts;
using AdvancedProgrammingNew.DataAccess.Repositories;
using AdvancedProgrammingNew.DataAccess.Repositories.Equipments;
using AdvancedProgrammingNew.DataAccess.Repositories.Planifications;

namespace AdvancedProgrammingNew.Servicess

{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Additional configuration is required to successfully run gRPC on macOS.
            // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

            // Add services to the container.
            builder.Services.AddGrpc();
            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            builder.Services.AddMediatR(new MediatRServiceConfiguration()
            {
                AutoRegisterRequestProcessors = true,
            }
            .RegisterServicesFromAssemblies(typeof(AssemblyReference).Assembly));

            builder.Services.AddSingleton("Data Source=Data.sqlite");
            builder.Services.AddScoped<ApplicationContext>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IEquipmentRepository, EquipmentRepository>();
            builder.Services.AddScoped<IPlanificationRepository, PlanificationRepository>();
          

            //builder.Services.AddScoped<IPriceRepository, ApplicationRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.MapGrpcService<SensorServices>();
            app.MapGrpcService<ActuatorServices>();
            app.MapGrpcService<CalibrationServices>();

            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            app.Run();
        }
    }
}

