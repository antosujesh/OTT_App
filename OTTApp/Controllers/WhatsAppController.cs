using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;

namespace OTTApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhatsAppController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public WhatsAppController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpPost("sendMessage")]
        public async Task<IActionResult> SendMessage([FromBody] WhatsAppMessageRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.MobileNumber) || string.IsNullOrWhiteSpace(request.Message))
            {
                return BadRequest("Mobile number and message are required.");
            }

            var httpClient = _httpClientFactory.CreateClient();
            var url = "https://graph.facebook.com/v13.0/{your_whatspp_ID}/messages";
            var accessToken = ""; // Replace with your access token

            var payload = new
            {
                messaging_product = "whatsapp",
                recipient_type = "individual",
                to = request.MobileNumber,
                type = "template",
                template = new
                {
                    name = "shift_report",
                    language = new { code = "en" },
                    components = new object[]
                    {
                    new
                    {
                        type = "header",
                        parameters = new object[]
                        {
                            new
                            {
                                type = "document",
                                document = new { link = "https://www.w3.org/WAI/ER/tests/xhtml/testfiles/resources/pdf/dummy.pdf" }
                            }
                        }
                    },
                    new
                    {
                        type = "body",
                        parameters = new object[]
                        {
                            new { type = "text", text = request.Message }
                        }
                    }
                    }
                }
            };

            var jsonPayload = JsonSerializer.Serialize(payload);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            var response = await httpClient.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                return Ok("Message sent successfully.");
            }
            else
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return StatusCode((int)response.StatusCode, responseContent);
            }
        }

    }
    public class WhatsAppMessageRequest
    {
        public string MobileNumber { get; set; }
        public string Message { get; set; }
    }
}
