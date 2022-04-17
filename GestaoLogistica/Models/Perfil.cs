using System;
using System.Collections.Generic;

namespace GestaoLogistica.Models
{
    public partial class Perfil
    {
        public Perfil()
        {
            Permissoesperfil = new HashSet<Permissoesperfil>();
            Usuarios = new HashSet<Usuario>();
        }

        public string IdPerfil { get; set; }
        public string Nome { get; set; }
        public byte? Ativo { get; set; }

        public virtual ICollection<Permissoesperfil> Permissoesperfil { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
