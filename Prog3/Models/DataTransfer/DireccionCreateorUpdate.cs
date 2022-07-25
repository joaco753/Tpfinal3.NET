using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prog3.Models.DataTransfer
{
    public class DireccionCreateorUpdate
    {
        public virtual int idDireccion { get; set; }

        public virtual int idPersona { get; set; }

        public virtual string Provincia { get; set; }

        public virtual string Ciudad { get; set; }

        public virtual string Calle { get; set; }

        public virtual string NumeroCalle { get; set; }
    }
}
