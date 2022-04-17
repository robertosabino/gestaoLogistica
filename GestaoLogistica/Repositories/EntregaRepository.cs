using GestaoLogistica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoLogistica.Repositories
{
  public class EntregaRepository : GenericRepository<Entrega>, IEntregaRepository
  {
    public EntregaRepository(AppDbContext repositoryContext)
            : base(repositoryContext)
    {
    }
  }
}
