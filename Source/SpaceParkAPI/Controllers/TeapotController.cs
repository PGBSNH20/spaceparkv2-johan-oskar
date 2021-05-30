using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpaceParkAPI.Models;

namespace SpaceParkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeapotController : ControllerBase
    {
        private SpaceParkContext _context;

        public TeapotController(SpaceParkContext context)
        {
            _context = context;
        }

        /// <summary>
        /// I'm a teapot.
        /// </summary>
        // GET: api/<TeapotController>
        [HttpGet]
        public void Get()
        {
            Response.StatusCode = StatusCodes.Status418ImATeapot;
            Response.WriteAsync("I'm a teapot");
        }
    }
}
