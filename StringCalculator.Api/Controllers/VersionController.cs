using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StringCalculator.Core.Services;

namespace StringCalculator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VersionController : ControllerBase
    {
        private readonly IVersionService versionService;

        public VersionController(IVersionService versionService)
        {
            this.versionService = versionService;
        }

        // GET: api/Version
        [HttpGet]
        public Task<string> Get()
        {
            return versionService.GetVersionAsync<Startup>();
        }
    }
}