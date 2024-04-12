using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Ecommerce.Services.Contract;
using Ecommerce.DTO;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        #region Properties and Fields

        private readonly IUsuarioService _usuarioService;

        #endregion

        #region Constructor

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        #endregion

        #region Methods

        [HttpGet("List/{rol}/{buscar?}")]
        public async Task<IActionResult> List(string rol, string buscar = "NA")
        {
            var response = new ResponseDTO<List<UsuarioDTO>>();

            try
            {
                if (buscar == "NA")
                {
                    buscar = "";
                }
                response.IsCorrect = true;
                response.Result = await _usuarioService.List(rol, buscar);
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
            var response = new ResponseDTO<UsuarioDTO>();

            try
            {

                response.IsCorrect = true;
                response.Result = await _usuarioService.Get(id);
            }
            catch (Exception ex)
            {
                response.IsCorrect = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] UsuarioDTO model)
        {
            var response = new ResponseDTO<UsuarioDTO>();

            try
            {
                response.IsCorrect = true;
                response.Result = await _usuarioService.Create(model);
            }
            catch (Exception ex)
            {
                response.IsCorrect = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost("Autorization")]
        public async Task<IActionResult> Autorization([FromBody] LoginDTO model)
        {
            var response = new ResponseDTO<SesionDTO>();

            try
            {
                response.IsCorrect = true;
                response.Result = await _usuarioService.Autorization(model);
            }
            catch (Exception ex)
            {
                response.IsCorrect = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit([FromBody] UsuarioDTO model)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.IsCorrect = true;
                response.Result = await _usuarioService.Edit(model);
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
                response.Result = await _usuarioService.Delete(id);
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
