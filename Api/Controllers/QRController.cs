using Business;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QRController : ControllerBase
    {
        [HttpPost]
        public IActionResult GenerateQRCode([FromBody] string value)
        {
            return base.File(value.ConvertToQR(), "image/png");
        }
    }
}
