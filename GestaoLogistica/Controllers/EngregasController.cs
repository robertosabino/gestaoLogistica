using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoLogistica.Models;
using GestaoLogistica.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestaoLogistica.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class EntregasController : Controller
  {
    private readonly IEntregaRepository repository;
    public EntregasController(IEntregaRepository _context)
    {
      repository = _context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Entrega>>> GetEntregas()
    {
      var Entregas = await repository.GetAll();
      if (Entregas == null)
      {
        return BadRequest();
      }
      return Ok(Entregas.ToList());
    }

    // GET: api/Products/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Entrega>> GetEntrega(string id)
    {
      var Entrega = await repository.GetById(id);
      if (Entrega == null)
      {
        return NotFound("Entrega não encontrado pelo id informado");
      }
      return Ok(Entrega);
    }

    // POST api/<controller>  
    [HttpPost]
    public async Task<IActionResult> PostEntrega([FromBody]Entrega Entrega)
    {
      if (Entrega == null)
      {
        return BadRequest("Entrega é null");
      }
      await repository.Insert(Entrega);
      return CreatedAtAction(nameof(GetEntrega), new { Id = Entrega.IdEntrega }, Entrega);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutEntrega(string id, Entrega Entrega)
    {
      if (id != Entrega.IdEntrega)
      {
        return BadRequest($"O código do Entrega {id} não confere");
      }
      try
      {
        await repository.Update(id, Entrega);
      }
      catch (DbUpdateConcurrencyException)
      {
        throw;
      }
      return Ok("Atualização do Entrega realizada com sucesso");
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Entrega>> DeleteEntrega(string id)
    {
      var Entrega = await repository.GetById(id);
      if (Entrega == null)
      {
        return NotFound($"Entrega de {id} foi não encontrado");
      }
      await repository.Delete(id);
      return Ok(Entrega);
    }
  }
}
