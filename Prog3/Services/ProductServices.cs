using Microsoft.EntityFrameworkCore;
using Prog3.Models;
using Prog3.Models.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prog3.Services
{
    public class ProductServices: IProductServices
    {
        private readonly TPContext _context;

        public ProductServices(TPContext context)
        {
            _context = context;
        }

        public IEnumerable<Producto> GetAll()
        {
            return _context.Producto.Include(c => c.IdTipoProductoNavigation).ToList();
        }

        public Producto GetOne(int productoID)
        {
            return _context.Producto.Include(c => c.IdTipoProductoNavigation).SingleOrDefault(x => x.IdProducto == productoID);
        }

        public void DeleteProduct(Producto producto)
        {
            _context.Producto.Remove(producto);
            _context.SaveChanges();
        }

        public Producto UpdateProduct(Producto oldprod, ProductCreateOrUpdateData newdata)
        {
            if(oldprod != null)
            {
                oldprod.IdProducto = oldprod.IdProducto;
                oldprod.CodigoProducto = newdata.Codigo;
                oldprod.IdTipoProducto = newdata.TipoProducto;
                oldprod.NombreProducto = newdata.Nombre;
                oldprod.Stock = newdata.Stock;
                oldprod.Precio = newdata.Precio;
                oldprod.Imagen = newdata.Imagen;            
            }

            _context.SaveChanges();

            return oldprod;

        }

        public Producto CreateProduct(ProductCreateOrUpdateData data)
        {
            var producto = new Producto()
            {

                CodigoProducto = data.Codigo,
                IdTipoProducto = data.TipoProducto,
                NombreProducto = data.Nombre,
                Stock = data.Stock,
                Precio = data.Precio,
                Imagen = data.Imagen
            };

            _context.Producto.Add(producto);
            _context.SaveChanges();

            return producto;
        }

        public IEnumerable<Producto> GetByName(string prodName)
        {
            return _context.Producto.Where(x => EF.Functions.Like(x.NombreProducto, $"%{prodName}%")).Include(c => c.IdTipoProductoNavigation).ToList(); ;
        }
    }
}
