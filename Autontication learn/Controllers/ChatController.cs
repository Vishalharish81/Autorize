using Autontication_learn.InputModel;
using Autontication_learn.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace Autontication_learn.Controllers
{
    [ApiController]
    [Authorize]
    public class ChatController : Controller
    {
        private readonly Login login;

        public ChatController(Login _login)
        {
            login = _login;
        }

        [HttpGet("Checking")]
        public IActionResult Https()
        {
            var result = login.Https();

            return Ok(result);
        }
        [HttpGet]
        [Route("ChatAi")]

        public async Task<IActionResult> ChatAi(LoginInputModel LoginInputModel)
        {
            var ollamaEndpoint = "http://127.0.0.1:11434";

            using var httpClient = new HttpClient
            {
                BaseAddress = new Uri(ollamaEndpoint)
            };

            var requestBody = new
            {
                model = "llama3",
                messages = new[]
                {
                new { role = "user", content = LoginInputModel.Email }
            }
            };

            var jsonContent = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(requestBody),
                System.Text.Encoding.UTF8,
                "application/json"
            );

            var response = await httpClient.PostAsync("/api/chat", jsonContent);

            if (!response.IsSuccessStatusCode)
            {
                // ✅ Now StatusCode works because of ControllerBase
                return StatusCode((int)response.StatusCode, "Error communicating with Ollama API");
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            return Ok(responseContent);

        }

        [HttpGet]
        [Route("Chatbot")]

        public async Task<IActionResult> LoginMethod(LoginInputModel LoginInputModel)
        {
            var ollamaendpoint = "http://127.0.0.1:11434";

            var baseollamachient = new HttpClient
            {
                BaseAddress = new Uri(ollamaendpoint)
            };
            var responsemessage = await baseollamachient.GetAsync("/api/tags");
            var content = await responsemessage.Content.ReadAsStringAsync();

            var result = login.Login(LoginInputModel);
            return Ok(content);
        }
    }

  
}


