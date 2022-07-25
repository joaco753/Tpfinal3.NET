using Prog3.Models;
using Prog3.Models.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prog3.Services.Interfaces
{
    public interface IDireccionServices 
    {

        IEnumerable<Direccion> GetAll();
        Direccion CrearDireccion(ClienteCreateOrUpdate data, int idpersona);

        void DelteDireccion(Direccion direccion);

        public IEnumerable<Direccion> GetByName(string clientename);
    }
}
