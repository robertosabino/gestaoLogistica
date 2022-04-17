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
  public class PerfisController : Controller
  {
    private readonly IPerfilRepository repository;
    public PerfisController(IPerfilRepository _context)
    {
      repository = _context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Perfil>>> GetPerfils()
    {
      var Perfils = await repository.GetAll();
      if (Perfils == null)
      {
        return BadRequest();
      }
      return Ok(Perfils.ToList());
    }

    // GET: api/Products/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Perfil>> GetPerfil(string id)
    {
      var Perfil = await repository.GetById(id);
      if (Perfil == null)
      {
        return NotFound("Perfil não encontrado pelo id informado");
      }
      return Ok(Perfil);
    }

    // POST api/<controller>  
    [HttpPost]
    public async Task<IActionResult> PostPerfil([FromBody]Perfil Perfil)
    {
      if (Perfil == null)
      {
        return BadRequest("Perfil é null");
      }
      await repository.Insert(Perfil);
      return CreatedAtAction(nameof(GetPerfil), new { Id = Perfil.IdPerfil }, Perfil);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutPerfil(string id, Perfil Perfil)
    {
      if (id != Perfil.IdPerfil)
      {
        return BadRequest($"O código do Perfil {id} não confere");
      }
      try
      {
        await repository.Update(id, Perfil);
      }
      catch (DbUpdateConcurrencyException)
      {
        throw;
      }
      return Ok("Atualização do Perfil realizada com sucesso");
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Perfil>> DeletePerfil(string id)
    {
      var Perfil = await repository.GetById(id);
      if (Perfil == null)
      {
        return NotFound($"Perfil de {id} foi não encontrado");
      }
      await repository.Delete(id);
      return Ok(Perfil);
    }
  }
}
