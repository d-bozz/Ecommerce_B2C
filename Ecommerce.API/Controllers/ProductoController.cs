using Ecommerce.DTO;
using Ecommerce.Services.Contract;
using Ecommerce.Services.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        #region Properties and Fields

        private readonly IProductoService _productoService;

        #endregion

        #region Constructor

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        #endregion

        #region Methods

        [HttpGet("List/{buscar?}")]
        public async Task<IActionResult> List(string buscar = "NA")
        {
            var response = new ResponseDTO<List<ProductoDTO>>();

            try
            {
                if (buscar == "NA")
                {
                    buscar = "";
                }
                response.IsCorrect = true;
                response.Result = await _productoService.List(buscar);
            }
            catch (Exception ex)
            {
                response.IsCorrect = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet("catalogue/{categoria:alpha}/{buscar?}")]
        public async Task<IActionResult> Catalogue(string categoria, string buscar = "NA")
        {
            var response = new ResponseDTO<List<ProductoDTO>>();

            try
            {
                if (categoria.ToLower() == "todos")
                {
                    categoria = "";
                }
                if (buscar == "NA")
                {
                    buscar = "";
                }

                response.IsCorrect = true;
                response.Result = await _productoService.Catalogue(categoria, buscar);
            }
            catch (Exception ex)
            {
                response.IsCorrect = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet("Get/{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = new ResponseDTO<ProductoDTO>();

            try
            {

                response.IsCorrect = true;
                response.Result = await _productoService.Get(id);
            }
            catch (Exception ex)
            {
                response.IsCorrect = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] ProductoDTO model)
        {
            var response = new ResponseDTO<ProductoDTO>();

            try
            {
                response.IsCorrect = true;
                response.Result = await _productoService.Create(model);
            }
            catch (Exception ex)
            {
                response.IsCorrect = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }
                
        [HttpPut("Edit")]
        public async Task<IActionResult> Edit([FromBody] ProductoDTO model)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.IsCorrect = true;
                response.Result = await _productoService.Edit(model);
            }
            catch (Exception ex)
            {
                response.IsCorrect = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.IsCorrect = true;
                response.Result = await _productoService.Delete(id);
            }
            catch (Exception ex)
            {
                response.IsCorrect = false;
                response.Message = ex.Message;
            }
            return Ok(response);

        }

        #endregion
    }
}
