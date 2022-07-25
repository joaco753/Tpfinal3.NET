using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Prog3.Models;
using Prog3.Models.DataTransfer;
using Prog3.Services;
using Prog3.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prog3.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    { 
        private readonly ILogger<ClienteController> _logger;

        private IMapper _mapper;

        private IDireccionServices _direccionservices;

        private IPersonasServices _personaServices;

        private IClienteServices _clienteServices;



        public ClienteController(ILogger<ClienteController> logger, IMapper mapper, IDireccionServices direccionservices, IPersonasServices personaservices, IClienteServices clienteservices)
        {
            _logger = logger;
            _mapper = mapper;
            _direccionservices = direccionservices;
            _personaServices = personaservices;
            _clienteServices = clienteservices;


        }


        [Route("all")]
        [HttpGet]
        public IEnumerable<DireccionViewModel> GetAll()
        {
            var personas = _direccionservices.GetAll();
            var personaDTO = _mapper.Map<IEnumerable<DireccionViewModel>>(personas);
            return personaDTO;
        }

        [Route("allcli")]
        [HttpGet]

        public IEnumerable<ClienteViewModel> GetAllCli()
        {
            var clientes = _clienteServices.GetAll();
            var clientesdto = _mapper.Map<IEnumerable<ClienteViewModel>>(clientes);
            return clientesdto;
        }

        [Route("create")]
        [HttpPut]

        public ActionResult<ClienteCreateOrUpdate> CreateCliente(ClienteCreateOrUpdate data, float total)
        {
            if (data == null)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "data can't be null");
            }

            try
            {
                var persona = _personaServices.CreatePersona(data);
                var direccion = _direccionservices.CrearDireccion(data, persona.IdPersona);
                var cliente = _clienteServices.CreateCliente(persona.IdPersona);
                _clienteServices.CrearVenta(cliente.IdCliente, total);
                
                if (direccion == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "No se pudo crear el producto");
                }
                else
                {
                    return Ok(_mapper.Map<DireccionViewModel>(direccion));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "error al borrar los datos");
            }
        }

        [Route("byName")]
        [HttpGet]
        public ActionResult<DireccionViewModel> GetByName(string nombre)
        {
            var direccion = _direccionservices.GetByName(nombre);
            if (nombre == null)
            {
                return NotFound();
            }

            var productDTO = _mapper.Map<IEnumerable<DireccionViewModel>>(direccion);
            return Ok(productDTO);
        }
    }
}
