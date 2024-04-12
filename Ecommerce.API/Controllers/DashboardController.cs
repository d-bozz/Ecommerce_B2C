using Ecommerce.DTO;
using Ecommerce.Services.Contract;
using Ecommerce.Services.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        #region Properties and Fields

        private readonly IDashboardService _dashboardService;

        #endregion

        #region Constructor

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        #endregion

        #region Methods

        [HttpGet("Summary")]
        public IActionResult Summary()
        {
            var response = new ResponseDTO<DashboardDTO>();

            try
            {
                response.IsCorrect = true;
                response.Result = _dashboardService.Summary();
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
