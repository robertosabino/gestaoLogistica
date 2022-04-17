using GestaoLogistica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoLogistica.Repositories
{
  public class DepositoRepository : GenericRepository<Deposito>, IDepositoRepository
  {
    public DepositoRepository(AppDbContext repositoryContext)
            : base(repositoryContext)
    {
    }
  }
}
