using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedProgrammingNew.Domain.Entities.Planification;

namespace AdvancedProgrammingNew.Contracts.Planifications
{
    public interface IPlanificationRepository
    {
        public void AddPlanification(Planification planification);


        public void DeletePlanification(Planification planification);


        public T? GetPlanificationById<T>(Guid id) where T : Planification;

        public IEnumerable<T> GetAllPlanifications<T>() where T : Planification; 

        public void UpdatePlanification(Planification planification);
    }
}
