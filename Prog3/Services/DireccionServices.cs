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
    public class DireccionServices : IDireccionServices
    {
        private readonly TPContext _context;

        public DireccionServices(TPContext context)
        {
            _context = context;
        }
        public IEnumerable<Direccion> GetAll()
        {
            return _context.Direccion.Include(c => c.IdPersonaNavigation).ToList();
        }

        public IEnumerable<Direccion> GetByName(string clientename)
        {
            return _context.Direccion.Where(x => EF.Functions.Like(x.IdPersonaNavigation.Nombre, $"%{clientename}%")).Include(c => c.IdPersonaNavigation).ToList(); 
        }

        public Direccion CrearDireccion(ClienteCreateOrUpdate data, int idpersona)
        {
            var direccion = new Direccion()
            {
                IdPersona = idpersona,
                Provincia = data.Provincia,
                Ciudad = data.Ciudad,
                Calle = data.Calle,
                NumeroCalle = data.NumeroCalle
            };
            _context.Direccion.Add(direccion);
            _context.SaveChanges();

            return direccion;
        }

        public void DelteDireccion(Direccion direccion)
        {
            _context.Direccion.Remove(direccion);
            _context.SaveChanges();
        }
    }
}
