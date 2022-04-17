using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoLogistica.Models;
using GestaoLogistica.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestaoLogistica.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class UsuariosController : Controller
  {
    private readonly IUsuarioRepository repository;
    public UsuariosController(IUsuarioRepository _context)
    {
      repository = _context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
    {
      var Usuarios = await repository.GetAll();
      if (Usuarios == null)
      {
        return BadRequest();
      }
      return Ok(Usuarios.ToList());
    }

    // GET: api/Products/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Usuario>> GetUsuario(string id)
    {
      var Usuario = await repository.GetById(id);
      if (Usuario == null)
      {
        return NotFound("Usuario não encontrado pelo id informado");
      }
      return Ok(Usuario);
    }

    // POST api/<controller>  
    [HttpPost]
    public async Task<IActionResult> PostUsuario([FromBody]Usuario Usuario)
    {
      if (Usuario == null)
      {
        return BadRequest("Usuario é null");
      }
      await repository.Insert(Usuario);
      return CreatedAtAction(nameof(GetUsuario), new { Id = Usuario.IdUsuario }, Usuario);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutUsuario(string id, Usuario Usuario)
    {
      if (id != Usuario.IdUsuario)
      {
        return BadRequest($"O código do Usuario {id} não confere");
      }
      try
      {
        await repository.Update(id, Usuario);
      }
      catch (DbUpdateConcurrencyException)
      {
        throw;
      }
      return Ok("Atualização do Usuario realizada com sucesso");
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Usuario>> DeleteUsuario(string id)
    {
      var Usuario = await repository.GetById(id);
      if (Usuario == null)
      {
        return NotFound($"Usuario de {id} foi não encontrado");
      }
      await repository.Delete(id);
      return Ok(Usuario);
    }
  }
}
