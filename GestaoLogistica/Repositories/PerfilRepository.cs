using GestaoLogistica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoLogistica.Repositories
{
  public class PerfilRepository: GenericRepository<Perfil>, IPerfilRepository
  {
    public PerfilRepository(AppDbContext repositoryContext)
          : base(repositoryContext)
    {
    }
  }
}
