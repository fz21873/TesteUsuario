using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroUsuario.Domain;
using CadastroUsuario.Repository.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;


namespace CadastroUsuario.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly CadastroUsuarioRepository _repository;

        public UsuarioController(CadastroUsuarioRepository repository)
        {
            _repository = repository;
        }


        // GET 
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _repository.GetAllUsuarioAsyncBy();

               if (results == null) return NotFound();

               return Ok(results);

            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falho {ex.Message}");
            }
        }

        // GET id
        [HttpGet("{IdUsuario}")]
        public async Task<IActionResult>Get(int IdUsuario)
        {
            try
            {
                var results = await _repository.GetUsuarioAsyncById(IdUsuario);
                
                return Ok(results);


            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falho {ex.Message}");
            }
        }

       

        // GET nome
        [HttpGet("getByNome/{nome}")]
        public async Task<IActionResult> Get(string nome)
        {
            try
            {
                var results = await _repository.GetAllUsuarioAsyncByNome(nome);

                if (results == null) return NotFound();

                 return Ok(results);

            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falho {ex.Message}");
            }
        }

        // GET ativo
        [HttpGet("getByAtivo/{ativo}")]
        public async Task<IActionResult> Get(bool ativo)
        {
            try
            {
                var results = await _repository.GetAllUsuarioAsyncByAtivo(ativo);
                if (results == null) return NotFound();
                return Ok(results);

            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falho {ex.Message}");
            }
        }


        // POST 
        [HttpPost]
        public async Task<IActionResult> Post(Usuario usuario)
        {
            try
            {
                _repository.Add(usuario);

                if (await _repository.SaveChangesAsync())
                {
                    return Created($"/api/usuario/{usuario.IdUsuario}", usuario);
                }
            }

            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falho {ex.Message}");
            }

            return BadRequest();


        }


        // PUT 
         [HttpPut("{IdUsuario}")]
        public async Task<IActionResult> PUT(int IdUsuario, Usuario usuario)
        {
            try
            {
                
                var usu = await _repository.GetUsuarioAsyncById(IdUsuario);

                if (usu == null) return NotFound();

               _repository.Update(usuario);

                if (await _repository.SaveChangesAsync())
                {
                    return Created($"/api/usuario/{usuario.IdUsuario}", usuario);
                }
            }

            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falho {ex.Message}");
            }

            return BadRequest();

        }

        // DELETE
        [HttpDelete("{IdUsuario}")]
        public async Task<IActionResult> Delete(int IdUsuario)
        {
            try
            {
                var usu = await _repository.GetUsuarioAsyncById(IdUsuario);

                if (usu == null) return NotFound();

                _repository.Delete(usu);

                if (await _repository.SaveChangesAsync())
                {
                    return Ok();
                }
            }

            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falho {ex.Message}");
            }

            return BadRequest();

        }

    }
}