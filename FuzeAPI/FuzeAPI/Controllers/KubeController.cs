using Fuze.Domain;
using FuzeAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FuzeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KubeController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public readonly ILogger<KubeController> _logger;
        public IKubernetesService _kubernetesService;

        public KubeController(ILogger<KubeController> logger, IKubernetesService kubeService)
        {
            _logger = logger;
            _kubernetesService = kubeService;
        }

        [HttpGet]
        [Route("Pods")]
        public async Task<IActionResult> GetAllPods()
        {
            return Ok(await _kubernetesService.GetAllPodsAsync());
        }
    }
}