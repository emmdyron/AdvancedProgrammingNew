using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedProgrammingNew.Contracts;
using AdvancedProgrammingNew.Contracts.Equipments;
using AdvancedProgrammingNew.DataAccess.Contexts;
using AdvancedProgrammingNew.DataAccess.Repositories.Equipments;
using AdvancedProgrammingNew.Domain.Entities.Equipments;
using AdvancedProgrammingNew.Domain.Entities.Types;
using ProgrammingAdvancedNew.DataAccess.Tests.Utilities;

namespace AdvancedProgrammingNew.DataAccess.Tests
{
    [TestClass]
    public class EquipmentTests

    {

        private IEquipmentRepository _equipmentRepository;

        private IUnitOfWork _unitOfWork;

        public EquipmentTests()
        {
            ApplicationContext context =
                new ApplicationContext(ConnectionStringProvider.GetConnectionString());
            _equipmentRepository = new EquipmentRepository(context);
            _unitOfWork = new UnitOfWork(context);
        }

        #region Actuators

        [DataRow("Alfa", "AlfaRomeo", "Temperature", "Celsius", "1234")]
        [TestMethod]
        public void Can_Add_New_Private_Actuator(
            string code,
            string manufacturerName,
            string name,
            string measurementunit,
            string codeAuto)
        {
            //Arrange
            Guid id = Guid.NewGuid();
            Actuator actuator = new Actuator(
                code,
                manufacturerName,
                new PhysicalMagnitude(name, measurementunit),
                codeAuto,
                id);

            //Execute
            _equipmentRepository.AddEquipment(actuator);
            _unitOfWork.SaveChanges();

            //Assert
            Equipment? loadedActuator = _equipmentRepository.GetEquipmentById<Equipment>(id);
            Assert.IsNotNull(loadedActuator);
        }

        [DataRow(0)]
        [TestMethod]
        public void Can_Get_Actuator_By_Id(int position)
        {
            //Arrange
            var actuators = _equipmentRepository.GetAllEquipments<Actuator>().ToList();
            Assert.IsNotNull(actuators);
            Assert.IsTrue(position < actuators.Count);
            Actuator actuatorToGet = actuators[position];

            //Execute
            Actuator? loadedActuator = _equipmentRepository.GetEquipmentById<Actuator>(actuatorToGet.Id);

            //Assert
            Assert.IsNotNull(loadedActuator);
        }

        [TestMethod]
        public void Cannot_Get_Actuator_By_Invalid_Id()
        {
            //Arrange

            //Execute
            Actuator? loadedActuator = _equipmentRepository.GetEquipmentById<Actuator>(Guid.Empty);

            //Assert
            Assert.IsNull(loadedActuator);
        }

        [DataRow(0, false, "4321")]
        [TestMethod]
        public void Can_Update_Actuator(int position, bool isDigital, string codeAuto)
        {
            //Arrange
            var actuators = _equipmentRepository.GetAllEquipments<Actuator>().ToList();
            Assert.IsNotNull(actuators);
            Assert.IsTrue(position < actuators.Count);
            Actuator actuatorToUpdate = actuators[position];

            //Execute
            actuatorToUpdate.IsDigital = isDigital;
            actuatorToUpdate.CodeAuto = codeAuto;
            _equipmentRepository.UpdateEquipment(actuatorToUpdate);
            _unitOfWork.SaveChanges();

            //Assert
            Actuator? loadedActuator = _equipmentRepository.GetEquipmentById<Actuator>(actuatorToUpdate.Id);
            Assert.IsNotNull(loadedActuator);
            Assert.AreEqual(loadedActuator.IsDigital, isDigital);
            Assert.AreEqual(loadedActuator.CodeAuto, codeAuto);
        }

        [DataRow(0)]
        [TestMethod]
        public void Can_Delete_Actuator(int position)
        {
            //Arrange
            var actuators = _equipmentRepository.GetAllEquipments<Actuator>().ToList();
            Assert.IsNotNull(actuators);
            Assert.IsTrue(position < actuators.Count);
            Actuator actuatorToDelete = actuators[position];

            //Execute
            _equipmentRepository.DeleteEquipment(actuatorToDelete);
            _unitOfWork.SaveChanges();

            //Assert
            Actuator? loadedActuator = _equipmentRepository.GetEquipmentById<Actuator>(actuatorToDelete.Id);
            Assert.IsNull(loadedActuator);
        }

        #endregion

        #region Sensors

        [DataRow("Alfa", "AlfaRomeo", "Temperature", "Celsius", "Barometro",Protocol.Modbus)]
        [TestMethod]
        public void Can_Add_New_Private_Sensor(
            string code,
            string manufacturerName,
            string name,
            string measurementunit,
            string function,
            Protocol protocol)
        {
            //Arrange
            Guid id = Guid.NewGuid();
            Sensor sensor = new Sensor(
                code,
                manufacturerName,
                new PhysicalMagnitude(name, measurementunit),
                function,
                protocol,
                id);

            //Execute
            _equipmentRepository.AddEquipment(sensor);
            _unitOfWork.SaveChanges();

            //Assert
            Equipment? loadedSensor = _equipmentRepository.GetEquipmentById<Equipment>(id);
            Assert.IsNotNull(loadedSensor);
        }

        [DataRow(0)]
        [TestMethod]
        public void Can_Get_Sensor_By_Id(int position)
        {
            //Arrange
            var sensors = _equipmentRepository.GetAllEquipments<Sensor>().ToList();
            Assert.IsNotNull(sensors);
            Assert.IsTrue(position < sensors.Count);
            Sensor sensorToGet = sensors[position];

            //Execute
            Sensor? loadedSensor = _equipmentRepository.GetEquipmentById<Sensor>(sensorToGet.Id);

            //Assert
            Assert.IsNotNull(loadedSensor);
        }

        [TestMethod]
        public void Cannot_Get_Sensor_By_Invalid_Id()
        {
            //Arrange

            //Execute
            Sensor? loadedSensor = _equipmentRepository.GetEquipmentById<Sensor>(Guid.Empty);

            //Assert
            Assert.IsNull(loadedSensor);
        }

        [DataRow(0, "Flujometro", Protocol.BACNet)]
        [TestMethod]
        public void Can_Update_Sensor(int position, string function, Protocol protocol)
        {
            //Arrange
            var sensors = _equipmentRepository.GetAllEquipments<Sensor>().ToList();
            Assert.IsNotNull(sensors);
            Assert.IsTrue(position < sensors.Count);
            Sensor sensorToUpdate = sensors[position];

            //Execute
            sensorToUpdate.Function = function;
            sensorToUpdate.Protocol = protocol;
            _equipmentRepository.UpdateEquipment(sensorToUpdate);
            _unitOfWork.SaveChanges();

            //Assert
            Sensor? loadedSensor = _equipmentRepository.GetEquipmentById<Sensor>(sensorToUpdate.Id);
            Assert.IsNotNull(loadedSensor);
            Assert.AreEqual(loadedSensor.Function, function);
            Assert.AreEqual(loadedSensor.Protocol, protocol);
        }

        [DataRow(0)]
        [TestMethod]
        public void Can_Delete_Sensor(int position)
        {
            //Arrange
            var sensors = _equipmentRepository.GetAllEquipments<Sensor>().ToList();
            Assert.IsNotNull(sensors);
            Assert.IsTrue(position < sensors.Count);
            Sensor sensorToDelete = sensors[position];

            //Execute
            _equipmentRepository.DeleteEquipment(sensorToDelete);
            _unitOfWork.SaveChanges();

            //Assert
            Sensor? loadedSensor = _equipmentRepository.GetEquipmentById<Sensor>(sensorToDelete.Id);
            Assert.IsNull(loadedSensor);
        }

        #endregion

    }
}