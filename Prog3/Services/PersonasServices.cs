using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prog3.Services;
using Prog3.Models;
using Prog3.Models.DataTransfer;
using Microsoft.EntityFrameworkCore;



namespace Prog3.Services
{
    public class PersonasServices: IPersonasServices
    {
        private readonly TPContext _context;

        public PersonasServices(TPContext context)
        {
            _context = context;
        }

        public Persona CreatePersona(ClienteCreateOrUpdate data)
        {
            var persona = new Persona()
            {
                Nombre = data.Nombre,
                Apellido = data.Apellido,
                RazonSocial = data.Razon
            };

            _context.Persona.Add(persona);
            _context.SaveChanges();

            return persona;
        }


        public void DeletePersona(Persona persona)
        {
            _context.Persona.Remove(persona);
            _context.SaveChanges();
        }
    }
}
