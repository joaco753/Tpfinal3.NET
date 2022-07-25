using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prog3.Models.DataTransfer
{
    public class DireccionViewModel
    {       
        public virtual string Nombre { get; set; }

        public virtual string Apellido { get; set; }

        public virtual string Razon { get; set; }

        public virtual string Provincia { get; set; }

        public virtual string Ciudad { get; set; }

        public virtual string Calle { get; set; }

        public virtual string NumeroCalle { get; set; }
        
    }
}
