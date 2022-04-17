using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GestaoLogistica.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Entregas = new HashSet<Entrega>();
        }

        public string IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public byte? Ativo { get; set; }
        public string Email { get; set; }
        public string IdPerfil { get; set; }
        [JsonIgnore]
        public virtual Perfil IdPerfilNavigation { get; set; }
        public virtual ICollection<Entrega> Entregas { get; set; }
    }
}
