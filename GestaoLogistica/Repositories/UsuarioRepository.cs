using GestaoLogistica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoLogistica.Repositories
{
  public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
  {
    public UsuarioRepository(AppDbContext repositoryContext)
            : base(repositoryContext)
    {
    }
  }
}
