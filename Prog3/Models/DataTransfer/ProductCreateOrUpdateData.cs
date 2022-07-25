using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prog3.Models.DataTransfer
{
    public class ProductCreateOrUpdateData
    {

        public virtual int idProducto { get; set; }

        public virtual string Nombre { get; set; }

        public virtual string Codigo { get; set; }

        public virtual int TipoProducto { get; set; }

        public virtual int Stock { set; get; }

        public virtual float Precio { get; set; }

        public virtual string Imagen { get; set; }

    }
}
