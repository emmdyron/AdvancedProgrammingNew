using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedProgrammingNew.Domain.Common
{
    public abstract class Entity
    {
        #region Properties

        /// <summary>
        /// Identificador unico para almacenamiento
        /// </summary>
        public Guid Id { get; set; }

        #endregion

        /// <summary>
        /// Requerido por Entity Framework
        /// </summary>
        protected Entity() { }

        protected Entity(Guid id)
        {
            Id = id;
        }
    }
}
