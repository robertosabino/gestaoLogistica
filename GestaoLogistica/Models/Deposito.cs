using System;
using System.Collections.Generic;

namespace GestaoLogistica.Models
{
    public partial class Deposito
    {
        public Deposito()
        {
            Entregas = new HashSet<Entrega>();
        }

        public string IdDeposito { get; set; }
        public string Descricao { get; set; }
        public byte? Ativo { get; set; }
        public string Endereco { get; set; }
        public string Imagem { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public virtual ICollection<Entrega> Entregas { get; set; }
    }
}
