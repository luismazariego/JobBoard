namespace JobBoard.WebApp.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using JobBoard.WebApp.Models;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;

    using RestSharp;

    public class JobController : Controller
    {
        private readonly string _baseUrl;
        private readonly RestClient _client;

        //private readonly IConfiguration _configuration;

        public JobController(IConfiguration configuration)
        {
            _baseUrl = configuration.GetValue<string>("BaseUrl");

            _client = new RestClient($"{_baseUrl}")
            {
                Timeout = -1
            };
        }

        // GET: JobController
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var request = new RestRequest("job", Method.GET);

            var result = await _client.ExecuteAsync<IEnumerable<JobViewModel>>(request);

            return View(result.Data);
        }
        
        

        // GET: JobController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var request = new RestRequest($"job/{id}", Method.GET);

            var result = await _client.ExecuteAsync<JobViewModel>(request);

            return View(result.Data);
        }

        // GET: JobController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(JobViewModel model)
        {
            try
            {
                if (!ModelState.IsValid) return View();

                var request = new RestRequest($"job", Method.POST);
                request.AddJsonBody(model);

                await _client.ExecuteAsync(request);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: JobController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var request = new RestRequest($"job/{id}", Method.GET);

            var result = await _client.ExecuteAsync<JobViewModel>(request);

            return View(result.Data);
        }

        // POST: JobController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, JobViewModel model)
        {
            try
            {
                if (!ModelState.IsValid || id < 1) return View();

                var request = new RestRequest($"job", Method.PUT);
                model.Job = id;
                request.AddJsonBody(model);

                await _client.ExecuteAsync(request);

                return RedirectToAction(nameof(Index));                
            }
            catch
            {
                return View();
            }
        }

        // GET: JobController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var request = new RestRequest($"job/{id}", Method.GET);

            var result = await _client.ExecuteAsync<JobViewModel>(request);

            return View(result.Data);
        }

        // POST: JobController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {                
                var request = new RestRequest($"job/{id}", Method.DELETE);               

                await _client.ExecuteAsync(request);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
