using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GestaoLogistica.Models
{
  public partial class Permissoesperfil
  {
    public string IdPerfil { get; set; }
    public string IdPermissao { get; set; }
    public string IdPermissoesPerfil { get; set; }
    [JsonIgnore]
    public virtual Perfil IdPerfilNavigation { get; set; }
    [JsonIgnore]
    public virtual Permissao IdPermissaoNavigation { get; set; }
  }
}
