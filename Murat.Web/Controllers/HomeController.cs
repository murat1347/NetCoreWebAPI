using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Murat.API.ResponseModels;
using Newtonsoft.Json;

namespace Murat.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var reponsemessage = await client.GetAsync("http://localhost:54754/api/Products");
            if (reponsemessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonData = await reponsemessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ProductResponseModel>>(jsonData);
                return View(result);
            }
            else
            {
                return View(null);
            }


        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductResponseModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:54754/api/Products", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData["errorMessage"] = $"Error{(int)responseMessage.StatusCode}";
                return View();
            }
        }

        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:54754/api/products/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<ProductResponseModel>(jsonData);
                return View(data);
            }

            else
            {
                return View(null);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductResponseModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:54754/api/products", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Remove(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync($"http://localhost:54754/api/products/{id}");

            return RedirectToAction("Index");

        }
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var client = _httpClientFactory.CreateClient();

            //System.IO.File.ReadAllBytes(file.File)

            var stream = new MemoryStream();
            await file.CopyToAsync(stream);

            var bytes = stream.ToArray();

            ByteArrayContent content = new ByteArrayContent(bytes);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);
            MultipartFormDataContent formData = new MultipartFormDataContent();
            formData.Add(content, "formFile", file.FileName);

            await client.PostAsync("http://localhost:54754/api/products/upload", formData);
            return RedirectToAction("Index");
        }
    }
}

