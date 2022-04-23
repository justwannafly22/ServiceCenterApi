using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Net;
using System.Threading.Tasks;

namespace ClientApi.Controllers
{
    public class HealthCheckController : Controller
    {
        private readonly HealthCheckService _healthCheckService;

        public HealthCheckController(HealthCheckService healthCheckService)
        {
            _healthCheckService = healthCheckService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var report = await _healthCheckService.CheckHealthAsync();

            return report.Status == HealthStatus.Healthy ? Ok(report) :
                StatusCode((int)HttpStatusCode.ServiceUnavailable, report);
        }
    }
}
