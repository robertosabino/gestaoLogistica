using GestaoLogistica.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoLogistica.Repositories
{
  public class MercadoriaRepository: GenericRepository<Mercadoria>, IMercadoriaRepository
  {
    public MercadoriaRepository(AppDbContext repositoryContext)
            : base(repositoryContext)
    {
    }
  }
}
