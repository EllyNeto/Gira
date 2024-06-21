using System;
using System.Collections.Generic;

namespace api.Models;

public partial class Usuario
{
    public int id { get; set; }

    public string? nome { get; set; }

    public DateOnly data_de_nascimento {get; set; }

    public string? telefone { get; set; }

    public string email { get; set; } = null!;

    public string senha { get; set; } = null!;

    public short nivel_acesso { get; set; }

    public virtual ICollection<InfoView> InfoViews { get; set; } = new List<InfoView>();

    public virtual ICollection<Informacoes> Informacoes { get; set; } = new List<Informacoes>();
}
