using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedProgrammingNew.Domain.Entities.Equipments;

namespace AdvancedProgrammingNew.Contracts.Equipments
{
    public interface IEquipmentRepository
    {
        public void AddEquipment(Equipment equipment);


        public void DeleteEquipment(Equipment equipment);


        public T? GetEquipmentById<T>(Guid id) where T : Equipment;


        public void UpdateEquipment(Equipment equipment);
    }
}
