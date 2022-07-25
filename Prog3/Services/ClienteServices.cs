using Microsoft.EntityFrameworkCore;
using Prog3.Models;
using Prog3.Models.DataTransfer;
using Prog3.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prog3.Services
{
    public class ClienteServices: IClienteServices
    {
        private readonly TPContext _context;


        public ClienteServices(TPContext context)
        {
            _context = context;

        }

        public IEnumerable<Cliente> GetAll()
        {
            return _context.Cliente.Include(c => c.IdPersonaNavigation).ToList();
        }

        public Cliente CreateCliente(int idPersona)
        {
            var cliente = new Cliente()
            {
                IdPersona = idPersona
            };

            _context.Cliente.Add(cliente);
            _context.SaveChanges();

            return cliente;
        }

        public void DelteCliente(Cliente cliente)
        {
            _context.Cliente.Remove(cliente);
            _context.SaveChanges();
        }

        public void CrearVenta(int idcliente, float total)
        {
            var venta = new Venta()
            {
                IdCliente = idcliente,
                TotalVenta = total
            };

            _context.Venta.Add(venta);
            _context.SaveChanges();
        }

    }
}
