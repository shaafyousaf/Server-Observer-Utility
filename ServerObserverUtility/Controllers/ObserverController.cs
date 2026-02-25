using MetricsHelperClasses;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServerObserverUtility.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ObserverController : ControllerBase
    {
        private readonly ILogger<ObserverController> _logger;
        private readonly IHttpClientFactory _httpCF;

        public ObserverController(ILogger<ObserverController> logger, IHttpClientFactory httpCF)
        {
            _logger = logger;
            _httpCF = httpCF;
        }

        [HttpGet(Name = "ObserverController")]
        public string Get()
        {
            return "All Systems Nominal";
        }

        [HttpGet("cpuMetrics")] 
        public async Task<int> GetCPUMetrics()
        {

            var client = _httpCF.CreateClient();


            //http://host.docker.internal:61208/api/4/
            var response = await client.GetAsync("http://192.168.1.100:61208/api/4/cpu");
            string jsonResponse = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(jsonResponse))
            {
                return -1;
            }

            CpuMetrics tempStats = JsonSerializer.Deserialize<CpuMetrics>(jsonResponse);



            return 0;
        }
    }
}
