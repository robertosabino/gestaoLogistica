using System;
using System.Collections.Generic;

namespace GestaoLogistica.Models
{
    public partial class Permissao
    {
        public Permissao()
        {
            Permissoesperfil = new HashSet<Permissoesperfil>();
        }

        public string Idpermissao { get; set; }
        public string Modulo { get; set; }
        public string Nome { get; set; }
        public byte? Incluir { get; set; }
        public byte? Ler { get; set; }
        public byte? Editar { get; set; }
        public byte? Deletar { get; set; }

        public virtual ICollection<Permissoesperfil> Permissoesperfil { get; set; }
    }
}
