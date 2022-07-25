using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Prog3.Models;
using Prog3.Models.DataTransfer;
using Prog3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prog3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly ILogger<ProductsController> _logger;

        private IMapper _mapper;

        private IProductServices _productservices;
      

        public ProductsController(ILogger<ProductsController> logger, IMapper mapper, IProductServices productservices)
        {
            _logger = logger;
            _mapper = mapper;
            _productservices = productservices;

        }

        [Route("all")]
        [HttpGet]
        public IEnumerable<ProductViewModel> GetAll()
        {
            var producto = _productservices.GetAll();
            var productoDTO = _mapper.Map<IEnumerable<ProductViewModel>>(producto);
            return productoDTO;
        }

        [HttpGet("{idProducto}")]
        public ProductViewModel GetOne(int idProducto)
        {
            var producto = _productservices.GetOne(idProducto);
            var productoDTO = _mapper.Map<ProductViewModel>(producto);
            return productoDTO;
        }

        [HttpDelete("{idProducto}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult DeleteProduct(int idProducto)
        {
            var producto = _productservices.GetOne(idProducto);
            if(producto == null)
            {
                return NotFound();
            }
            try
            {
                _productservices.DeleteProduct(producto);
                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al borrar");
            }
            
        }

        [HttpPut("{idProducto}")]

        public ActionResult<ProductCreateOrUpdateData> UpdateProducto(int idProducto, ProductCreateOrUpdateData data)
        {
            if(data == null)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "Product data can't be null");
            }

            try
            {
                var oldproducto = _productservices.GetOne(idProducto);
                var newproducto = _productservices.UpdateProduct(oldproducto, data);
                if(newproducto == null)
                {
                    return NotFound();
                }
                else
                {

                    return Ok(_mapper.Map<ProductViewModel>(newproducto));
                }               
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "error al borrar los datos");
            }
        }

        [Route("create")]
        [HttpPut]

        public ActionResult<ProductCreateOrUpdateData> CreateProducto(ProductCreateOrUpdateData data)
        {
            if(data == null)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "Product data can't be null");
            }

            try
            {
                var producto = _productservices.CreateProduct(data);
                if(producto == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "No se pudo crear el producto");
                }
                else
                {
                    return Ok(_mapper.Map<ProductViewModel>(producto));
                }              
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "error al borrar los datos");
            }
        }
     

        [Route("byName")]
        [HttpGet]
        public ActionResult<ProductViewModel> GetByName(string prodname)
        {
            var producto = _productservices.GetByName(prodname);
            if(producto == null)
            {
                return NotFound();
            }

            var productDTO = _mapper.Map<IEnumerable<ProductViewModel>>(producto);
            return Ok(productDTO);
        }
    }
}
