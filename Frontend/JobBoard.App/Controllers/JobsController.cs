namespace JobBoard.App.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;

    using RestSharp;

    using System.Threading.Tasks;

    public class JobsController : Controller
    {
        private readonly string _baseUrl;

        //private readonly IConfiguration _configuration;

        public JobsController(IConfiguration configuration)
        {
            _baseUrl = configuration.GetValue<string>("BaseUrl");
        }
        
        // GET
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = new RestClient($"{_baseUrl}job")
            {
                Timeout = -1
            };

            var request = new RestRequest(Method.GET);

            var result = await client.ExecuteAsync(request);

            return View(result);
        }
    }
}