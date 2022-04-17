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
  public class DepositosController : Controller
  {
    private readonly IDepositoRepository repository;
    public DepositosController(IDepositoRepository _context)
    {
      repository = _context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Deposito>>> GetDepositos()
    {
      var Depositos = await repository.GetAll();
      if (Depositos == null)
      {
        return BadRequest();
      }
      return Ok(Depositos.ToList());
    }

    // GET: api/Products/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Deposito>> GetDeposito(string id)
    {
      var Deposito = await repository.GetById(id);
      if (Deposito == null)
      {
        return NotFound("Deposito não encontrado pelo id informado");
      }
      return Ok(Deposito);
    }

    // POST api/<controller>  
    [HttpPost]
    public async Task<IActionResult> PostDeposito([FromBody]Deposito Deposito)
    {
      if (Deposito == null)
      {
        return BadRequest("Deposito é null");
      }
      await repository.Insert(Deposito);
      return CreatedAtAction(nameof(GetDeposito), new { Id = Deposito.IdDeposito }, Deposito);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutDeposito(string id, Deposito Deposito)
    {
      if (id != Deposito.IdDeposito)
      {
        return BadRequest($"O código do Deposito {id} não confere");
      }
      try
      {
        await repository.Update(id, Deposito);
      }
      catch (DbUpdateConcurrencyException)
      {
        throw;
      }
      return Ok("Atualização do Deposito realizada com sucesso");
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Deposito>> DeleteDeposito(string id)
    {
      var Deposito = await repository.GetById(id);
      if (Deposito == null)
      {
        return NotFound($"Deposito de {id} foi não encontrado");
      }
      await repository.Delete(id);
      return Ok(Deposito);
    }
  }
}
