using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using YempoRespiriExam.Services;

namespace YempoRespiriExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IPersonServices _personServices;

        public PersonController(IConfiguration config, IPersonServices personServices)
        {
            _config = config;
            _personServices = personServices;
        }

        /// <summary>
        /// Returns a message and api version
        /// </summary>
        /// <returns></returns>
        [Route("HelloWorld")]
        [HttpGet]
        public IActionResult GetHelloWord()
        {
            try
            {
                return new JsonResult(new {message = "hello world", version = _config.GetValue<string>("ApiVersion") }, new JsonSerializerOptions { PropertyNamingPolicy = null });
            }
            catch (Exception ex)
            {
                //Add Error Logging here
            }

            return BadRequest();
        }

        /// <summary>
        /// Returns a list of Person object
        /// </summary>
        /// <returns></returns>
        [Route("GetPersonList")]
        [HttpGet]
        public IActionResult GetPersonList()
        {
            try
            {
                var result = _personServices.Get().Result;
                return new JsonResult(result, new JsonSerializerOptions { PropertyNamingPolicy = null });
            }
            catch (Exception ex)
            {
                //Add Error Logging here
            }

            return BadRequest();
        }

        /// <summary>
        /// Returns a person object base from parameter Id
        /// </summary>
        /// <returns></returns>
        [Route("GetPerson/{id}")]
        [HttpGet]
        public IActionResult GetPerson(string id)
        {
            try
            {
                var result = _personServices.GetPerson(id).Result;
                return new JsonResult(result, new JsonSerializerOptions { PropertyNamingPolicy = null });
            }
            catch (Exception ex)
            {
                //Add Error Logging here
            }

            return BadRequest();
        }
    }
}
