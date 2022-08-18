using DataAccesInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace prueba1_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMUsuario _usuarioDA;
        private readonly ILogger<UserController> _logger;
        public UserController(IMUsuario UsuarioDA, ILogger<UserController> logger)
        {
            _logger = logger;
            _usuarioDA = UsuarioDA;
        }

        // GET: api/<UserController>
        [HttpGet("ListadoPerfil", Name = "get-ObtenerListadoPerfil")]
        public async Task<IActionResult> GetUser([FromQuery] UsuarioBE parameters, int? userPerfilId)
        {
            try
            {
                var pageResult = new UsuarioBE
                {
                    cod_usuario = parameters.cod_usuario,
                    nom_usuario = parameters.nom_usuario,
                };
                var resultPage = await _usuarioDA.GetUser(pageResult, userPerfilId).ConfigureAwait(false);

                var result = resultPage.ToList();
                if (!result.Any())
                {
                    if (result.Count == 0)
                    {
                        return Ok(result);
                    }
                    return NotFound();
                }

                return Ok(result);
            }

            catch (Exception ex)
            {
                _logger.LogError("Error: " + ex.Message);
                return BadRequest(ex);
            }
        }

        // GET api/<UserController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<UserController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<UserController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<UserController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
