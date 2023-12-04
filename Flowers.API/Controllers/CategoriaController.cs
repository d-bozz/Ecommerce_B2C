using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Flowers.Services.Contract;
using Flowers.DTO;
using Flowers.Services.Implementation;

namespace Flowers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        #region Properties and Fields

        private readonly ICategoriaService _categoriaService;

        #endregion

        #region Constructor

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        #endregion

        #region Methods

        [HttpGet("List/{buscar?}")]
        public async Task<IActionResult> List(string buscar = "NA")
        {
            var response = new ResponseDTO<List<CategoriaDTO>>();

            try
            {
                if (buscar == "NA")
                {
                    buscar = "";
                }
                response.IsCorrect = true;
                response.Result = await _categoriaService.List(buscar);
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
            var response = new ResponseDTO<CategoriaDTO>();

            try
            {
                response.IsCorrect = true;
                response.Result = await _categoriaService.Get(id);
            }
            catch (Exception ex)
            {
                response.IsCorrect = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CategoriaDTO model)
        {
            var response = new ResponseDTO<CategoriaDTO>();

            try
            {
                response.IsCorrect = true;
                response.Result = await _categoriaService.Create(model);
            }
            catch (Exception ex)
            {
                response.IsCorrect = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }
       
        [HttpPut("Edit")]
        public async Task<IActionResult> Edit([FromBody] CategoriaDTO model)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.IsCorrect = true;
                response.Result = await _categoriaService.Edit(model);
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
                response.Result = await _categoriaService.Delete(id);
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
