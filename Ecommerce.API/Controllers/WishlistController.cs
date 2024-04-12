using Ecommerce.DTO;
using Ecommerce.Services.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistController : ControllerBase
    {
        #region Properties and Fields

        private readonly IWishlistService _wishlistService;

        #endregion

        #region Constructor

        public WishlistController(IWishlistService wishlistService)
        {
            _wishlistService = wishlistService;
        }

        #endregion

        #region Methods

        [HttpGet("List/{id:int}")]
        public async Task<IActionResult> List(int id)
        {
            var response = new ResponseDTO<List<WishlistDTO>>();

            try
            {
                response.IsCorrect = true;
                response.Result = await _wishlistService.List(id);
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
            var response = new ResponseDTO<WishlistDTO>();

            try
            {
                response.IsCorrect = true;
                response.Result = await _wishlistService.Get(id);
            }
            catch (Exception ex)
            {
                response.IsCorrect = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet("GetByIdUsuarioAndIdProducto/{idUsuario:int}/{idProducto:int}")]
        public async Task<IActionResult> GetByIdUsuarioAndIdProducto(int idUsuario, int idProducto)
        {
            var response = new ResponseDTO<WishlistDTO>();

            try
            {
                response.IsCorrect = true;
                response.Result = await _wishlistService.GetByIdUsuarioAndIdProducto(idUsuario, idProducto);
            }
            catch (Exception ex)
            {
                response.IsCorrect = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Create([FromBody] WishlistDTO model)
        {
            var response = new ResponseDTO<WishlistDTO>();

            try
            {
                response.IsCorrect = true;
                response.Result = await _wishlistService.Add(model);
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
                response.Result = await _wishlistService.Delete(id);
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
