using Flowers.DTO;
using Flowers.Services.Contract;
using Flowers.Services.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flowers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        #region Properties and Fields

        private readonly IVentaService _ventaService;

        #endregion

        #region Constructor

        public VentaController(IVentaService ventaService)
        {
            _ventaService = ventaService;
        }

        #endregion

        #region Methods

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] VentaDTO model)
        {
            var response = new ResponseDTO<VentaDTO>();

            try
            {
                response.IsCorrect = true;
                response.Result = await _ventaService.Register(model);
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
