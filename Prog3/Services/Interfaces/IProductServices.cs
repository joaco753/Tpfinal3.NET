using Prog3.Models;
using Prog3.Models.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prog3.Services
{
    public interface IProductServices
    {
        IEnumerable<Producto> GetAll();

        Producto GetOne(int idProducto);

        void DeleteProduct(Producto producto);

        Producto UpdateProduct(Producto oldprod, ProductCreateOrUpdateData data);

        Producto CreateProduct(ProductCreateOrUpdateData data);

        public IEnumerable<Producto> GetByName(string prodName);
    }
}
