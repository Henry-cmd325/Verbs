using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VerbsAPI.Context;
using VerbsAPI.Models.Requests;
using VerbsAPI.Services;

namespace VerbsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _service;
        private readonly IConfiguration _config;
        public UsuariosController(IUsuarioService service, IConfiguration config)
        {
            _service = service;
            _config = config;
        }

        [HttpGet("{id}", Name = "GetUsuario")]
        public IActionResult GetUsuario(int id)
        {
            var response = _service.GetUsuario(id);

            if (!response.Success)  return BadRequest(response);

            return Ok(response);
        }

        [HttpPost]
        public IActionResult PostUsuario(UserRequest request)
        {
            var response = _service.PostUsuario(request);

            if (!response.Success) return BadRequest(response);

            return CreatedAtRoute(nameof(GetUsuario), new {Id = response.Data.cveUsuarios}, response);
        }

        [HttpPost("Login")]
        public IActionResult LoginUsuario(UserRequest request)
        {
            var response = _service.LoginUsuario(request);

            if (!response.Success) return BadRequest(response);

            return Ok(new {Token = _service.GenerateToken(request, _config)});
        }

        [HttpPut("{id}")]
        public IActionResult PutUsuario(int id, UserRequest request)
        {
            var response = _service.PutUsuario(id, request);

            if (!response.Success) return BadRequest(response);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUsuario(int id)
        {
            var response = _service.Delete(id);

            if (!response) return BadRequest();

            return NoContent();
        }
    }
}
