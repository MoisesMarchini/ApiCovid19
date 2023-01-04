using Microsoft.AspNetCore.Mvc;
using ApiServices.Interfaces;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Top10Controller : ControllerBase
    {
        private readonly IServices _services;

        public Top10Controller(IServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _services.GetTop10();
            if (result.Count < 10)
                return BadRequest();

            return Ok(result);
        }
    }
}