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
  public class MercadoriasController : Controller
  {
    private readonly IMercadoriaRepository repository;
    public MercadoriasController(IMercadoriaRepository _context)
    {
      repository = _context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Mercadoria>>> GetMercadorias()
    {
      var Mercadorias = await repository.GetAll();
      if (Mercadorias == null)
      {
        return BadRequest();
      }
      return Ok(Mercadorias.ToList());
    }

    // GET: api/Products/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Mercadoria>> GetMercadoria(string id)
    {
      var Mercadoria = await repository.GetById(id);
      if (Mercadoria == null)
      {
        return NotFound("Mercadoria não encontrado pelo id informado");
      }
      return Ok(Mercadoria);
    }

    // POST api/<controller>  
    [HttpPost]
    public async Task<IActionResult> PostMercadoria([FromBody]Mercadoria Mercadoria)
    {
      if (Mercadoria == null)
      {
        return BadRequest("Mercadoria é null");
      }
      await repository.Insert(Mercadoria);
      return CreatedAtAction(nameof(GetMercadoria), new { Id = Mercadoria.IdMercadoria }, Mercadoria);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutMercadoria(string id, Mercadoria Mercadoria)
    {
      if (id != Mercadoria.IdMercadoria)
      {
        return BadRequest($"O código do Mercadoria {id} não confere");
      }
      try
      {
        await repository.Update(id, Mercadoria);
      }
      catch (DbUpdateConcurrencyException)
      {
        throw;
      }
      return Ok("Atualização do Mercadoria realizada com sucesso");
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Mercadoria>> DeleteMercadoria(string id)
    {
      var Mercadoria = await repository.GetById(id);
      if (Mercadoria == null)
      {
        return NotFound($"Mercadoria de {id} foi não encontrado");
      }
      await repository.Delete(id);
      return Ok(Mercadoria);
    }

  }
}
