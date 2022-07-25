using Prog3.Models;
using Prog3.Models.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prog3.Services.Interfaces
{
    public interface IClienteServices
    {
        public Cliente CreateCliente(int IDPersona);
        public void DelteCliente(Cliente cliente);

        public void CrearVenta(int idcliente, float total);

    }
}
