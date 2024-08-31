using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedProgrammingNew.Contracts;
using AdvancedProgrammingNew.Contracts.Equipments;
using AdvancedProgrammingNew.Contracts.Planifications;
using AdvancedProgrammingNew.DataAccess.Contexts;
using AdvancedProgrammingNew.DataAccess.Repositories.Equipments;
using AdvancedProgrammingNew.DataAccess.Repositories.Planifications;
using AdvancedProgrammingNew.Domain.Entities.Equipments;
using AdvancedProgrammingNew.Domain.Entities.Planification;
using ProgrammingAdvancedNew.DataAccess.Tests.Utilities;

namespace AdvancedProgrammingNew.DataAccess.Tests
{
    [TestClass]
    public class PlanificationTests

    {

        private IPlanificationRepository _planificationRepository;

        private IUnitOfWork _unitOfWork;

        public PlanificationTests()
        {
            ApplicationContext context =
                new ApplicationContext(ConnectionStringProvider.GetConnectionString());
            _planificationRepository = new PlanificationRepository(context);
            _unitOfWork = new UnitOfWork(context);
        }

        [DataRow("Siemens","Rolando")]
        [TestMethod]
        public void Can_Add_New_Private_Calibration(
            string certifier,
            string operatorName)
        {
            //Arrange
            Guid id = Guid.NewGuid();
            Calibration calibration = new Calibration(
            certifier,
            operatorName,
            id);

            //Execute
            _planificationRepository.AddPlanification(calibration);
            _unitOfWork.SaveChanges();

            //Assert
            Planification? loadedcalibration = _planificationRepository.GetPlanificationById<Planification>(id);
            Assert.IsNotNull(loadedcalibration);

        }

        [DataRow(0)]
        [TestMethod]
        public void Can_Get_Calibration_By_Id(int position)
        {
            //Arrange
            var calibrations = _planificationRepository.GetAllPlanifications<Calibration>().ToList();
            Assert.IsNotNull(calibrations);
            Assert.IsTrue(position < calibrations.Count);
            Calibration calibrationToGet = calibrations[position];

            //Execute
            Calibration? loadedCalibration = _planificationRepository.GetPlanificationById<Calibration>(calibrationToGet.Id);

            //Assert
            Assert.IsNotNull(loadedCalibration);
        }

        [TestMethod]
        public void Cannot_Get_Calibration_By_Invalid_Id()
        {
            //Arrange

            //Execute
            Calibration? loadedCalibration = _planificationRepository.GetPlanificationById<Calibration>(Guid.Empty);

            //Assert
            Assert.IsNull(loadedCalibration);
        }

        [DataRow(0,"Holanda")]
        [TestMethod]
        public void Can_Update_Calibration(int position, string certifier)
        {
            //Arrange
            var calibrations = _planificationRepository.GetAllPlanifications<Calibration>().ToList();
            Assert.IsNotNull(calibrations);
            Assert.IsTrue(position < calibrations.Count);
            Calibration calibrationToUpdate = calibrations[position];

            //Execute
            calibrationToUpdate.Certifier = certifier;
            _planificationRepository.UpdatePlanification(calibrationToUpdate);
            _unitOfWork.SaveChanges();

            //Assert
            Calibration? loadedCalibration = _planificationRepository.GetPlanificationById<Calibration>(calibrationToUpdate.Id);
            Assert.IsNotNull(loadedCalibration);
            Assert.AreEqual(loadedCalibration.Certifier, certifier);
        }

    }
}
