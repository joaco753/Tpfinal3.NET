using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prog3.Models;
using Prog3.Models.DataTransfer;

namespace Prog3.Services
{
    public interface IPersonasServices
    {
        Persona CreatePersona(ClienteCreateOrUpdate data);
        void DeletePersona(Persona persona);

    }
}
