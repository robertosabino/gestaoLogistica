using System;
using System.Collections.Generic;

namespace GestaoLogistica.Models
{
    public partial class Mercadoria
    {
        public string IdMercadoria { get; set; }
        public string Nome { get; set; }
        public decimal? Valor { get; set; }
        public int? Estoque { get; set; }
        public string Imagem { get; set; }
    }
}
