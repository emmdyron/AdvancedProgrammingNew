using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedProgrammingNew.DataAccess.Contexts;
using AdvancedProgrammingNew.DataAccess.Repositories.Common;
using AdvancedProgrammingNew.Domain.Entities.Planification;
using AdvancedProgrammingNew.Contracts.Planifications;

namespace AdvancedProgrammingNew.DataAccess.Repositories.Planifications
{
    public class PlanificationRepository : RepositoryBase, IPlanificationRepository
    {

        public PlanificationRepository(ApplicationContext context) : base(context)
        {

        }

        public void AddPlanification(Planification planification)
        {
            _context.Planifications.Add(planification);
        }

        public void DeletePlanification(Planification planification)
        {
            _context.Planifications.Remove(planification);
        }

        public T? GetPlanificationById<T>(Guid id) where T : Planification
        {
            return _context.Set<T>().FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<T> GetAllPlanifications<T>() where T : Planification
        {
            return _context.Set<T>().ToList();
        }

        public void UpdatePlanification(Planification planification)
        {
            _context.Planifications.Update(planification);
        }

    }
}
