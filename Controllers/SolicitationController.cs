using Microsoft.AspNetCore.Mvc;
using NewsPub.Domain;
using NewsPub.Services;

namespace NewsPub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitationController : ControllerBase
    {
        private readonly ILogger<SolicitationController> _logger;
        private readonly IMensageria _mensageria;

        public SolicitationController(ILogger<SolicitationController> logger, IMensageria mensageria)
        {
            _logger = logger;
            _mensageria = mensageria;

        }
        
        [HttpPost]
        public IActionResult InsertSolicitation(Solicitation solicitation)
        {   
            try
            {
                _mensageria.Configuration(solicitation);
                return Accepted(solicitation);
            }
            catch (Exception ex)
            {
                
                _logger.LogError("Error! Cannot create a request", ex);
                return new StatusCodeResult(500);
            }
        }
    }
}