using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedProgrammingNew.DataAccess.Contexts;
using AdvancedProgrammingNew.DataAccess.Repositories.Common;
using AdvancedProgrammingNew.Domain.Entities.Equipments;
using AdvancedProgrammingNew.Contracts.Equipments;

namespace AdvancedProgrammingNew.DataAccess.Repositories.Equipments
{
    public class EquipmentRepository : RepositoryBase, IEquipmentRepository
    {

        public EquipmentRepository(ApplicationContext context) : base(context)
        {

        }

        public void AddEquipment(Equipment equipment)
        {
            _context.Equipments.Add(equipment);
        }

        public void DeleteEquipment(Equipment equipment)
        { 
            _context.Equipments.Remove(equipment);
        }

        public T? GetEquipmentById<T>(Guid id) where T : Equipment
        {
            return _context.Set<T>().FirstOrDefault(e => e.Id == id);
        }

        public void UpdateEquipment(Equipment equipment)
        { 
            _context.Equipments.Update(equipment);
        }

    }
}
