using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GestaoLogistica.Models
{
  public partial class Entrega
  {
    public string IdEntrega { get; set; }
    public string IdUsuario { get; set; }
    public string IdDeposito { get; set; }
    public string Endereco { get; set; }
    public string Imagem { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public int? Situacao { get; set; }
    [JsonIgnore]
    public virtual Deposito IdDepositoNavigation { get; set; }
    [JsonIgnore]
    public virtual Usuario IdUsuarioNavigation { get; set; }
  }
}
