using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prog3.Models.DataTransfer
{
    public class ProductViewModel
    {
        public virtual int Id { get; set; }

        public virtual string Nombre { get; set; }

        public virtual string Codigo { get; set; }

        public virtual string Tipo { get; set; }

        public virtual int Stock { get; set; }

        public virtual float Precio { get; set; }

        public virtual string Imagen { get; set; }


    }
}
