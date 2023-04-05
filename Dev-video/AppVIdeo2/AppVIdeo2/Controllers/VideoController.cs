using AppVideo.Model;
using AppVIdeo2.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Server;
using Microsoft.Win32;
using StackExchange.Redis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AppVIdeo2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClient;

        public VideoController(IHttpClientFactory httpclient)
        {
            _httpClient = httpclient;
        }

        [HttpPost]
        [RequestSizeLimit(209715200)]
        [Route("GuardarVideo")]

        public async Task<IActionResult> GuardarVideo([FromForm] IFormFile postedVideo, string nombre)
        {

            try
            {
                var cache = ConnectionMultiplexer.Connect("192.168.132.129:6379");

                var data = new Archivo();
                var fecha = DateTime.Now;
                data.NombreVideo = nombre;
                IDatabase cacheDb = cache.GetDatabase();
                var d = fecha.ToString("yyyy-MM-dd");
                data.Fecha = d;
                var key = $"{data.NombreVideo}-{d}";
                var algo = JsonSerializer.Serialize(postedVideo);

                var client = _httpClient.CreateClient("Api");
                var content = await client.PostAsJsonAsync("/Guardar", data);
                var response = await content.Content.ReadAsStringAsync();



                if (cacheDb.StringGet(key) == RedisValue.Null)
                {
                    if (response == "OK")
                    {
                        cacheDb.StringSet(key, algo);
                        return StatusCode(StatusCodes.Status200OK, "OK");
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, "Sucedio un error");
                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, "cargado");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpGet]
        [Route("TraerVideos")]
        public async Task<IActionResult> TraerVideos()
        {
            var client = _httpClient.CreateClient("Api");
            var content = await client.GetAsync("/TraerVideos");
            var response = await content.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<List<Archivo2>>(response);            
           
            return StatusCode(StatusCodes.Status200OK, data);
        }

        [HttpGet]
        [Route("Video")]
        public async Task<IActionResult> Video(string id)
        {
            var cache = ConnectionMultiplexer.Connect("192.168.132.129:6379");
            IDatabase cacheDB = cache.GetDatabase();
            var resultado = cacheDB.StringGet(id).ToString();
            return StatusCode(StatusCodes.Status200OK, resultado);
        }

        [HttpGet]
        [Route("Eliminar")]

        public async Task<IActionResult> Eliminar ()
        {
            var cache = ConnectionMultiplexer.Connect("192.168.132.129:6379");
            IDatabase cacheDB = cache.GetDatabase();
            cacheDB.Execute("FLUSHALL");

            return StatusCode(StatusCodes.Status200OK, "OK");
        }

    }
}
