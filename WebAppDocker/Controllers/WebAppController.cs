using Microsoft.AspNetCore.Mvc;

namespace WebAppDocker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebAppController : ControllerBase
    {
        private readonly ILogger<WebAppController> _logger;
        private static readonly HttpClient Client = new HttpClient();
        private string _pythonContainer = "http://172.17.0.2:8080/";

        public WebAppController(ILogger<WebAppController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/api/get")]
        public string Get()
        {
            _logger.LogInformation("call get method");
            return "Hello!!!!!";
        }

        [HttpPost("/api/post")]
        public async  Task<string> Post()
        {
            var responseBody = "nothing";
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try	
            {
                //HttpResponseMessage response = await Client.GetAsync("http://127.0.0.1:8080/");
                HttpResponseMessage response = await Client.GetAsync(_pythonContainer);
                
                _logger.LogInformation("connect to {PythonContainer}", _pythonContainer);
                
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);

                Console.WriteLine(responseBody);
            }
            catch(HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");	
                Console.WriteLine("Message :{0} ",e.Message);
            }
            
            return responseBody;
        }
    }
}