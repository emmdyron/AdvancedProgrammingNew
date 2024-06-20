using AdvancedProgrammingNew.Domain.Common;
using AdvancedProgrammingNew.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedProgrammingNew.Domain.Entities.Equipments
{
    public abstract class Equipment : Entity
{
    #region Properties

    /// <summary>
    /// Codigo alfanumerico de la unidad a la que pertenecen
    /// </summary>

    public string Code { get; set;  }

    /// <summary>
    /// Nombre del fabricante
    /// </summary>

    public string ManufacturerName { get; set; }

    /// <summary>
    /// Magnitud fisica
    /// </summary>
    /// 
    public PhysicalMagnitude PhysicalMagnitude { get; set; }

    #endregion

        protected Equipment() { }

    public Equipment(string code, string manufacturerName, PhysicalMagnitude physicalMagnitude, Guid id) : base(id)
    {
        Code = code;
        ManufacturerName = manufacturerName;
        PhysicalMagnitude = physicalMagnitude;
    }
}
}
