using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prog3.Models.DataTransfer
{
    public class ClienteViewModel
    {
        public virtual string Nombre { get; set; }

        public virtual string Apellido { get; set; }

        public virtual string Razon { get; set; }
    }
}
