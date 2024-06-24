using System;
using System.Collections.Generic;

namespace api.Models;

public partial class Informacoes
{
    public int id { get; set; }

    public string titulo { get; set; } = null!;

    public string descricao { get; set; } = null!;

    public DateTime? dataa { get; set; }

    public string evento { get; set; } = null!;

    public string organizacao { get; set; } = null!;

    public string? foto { get; set; }

    public DateTime data_de_realizacao { get; set; }

    public DateTime? created_at { get; set; }

    public DateTime? updated_at { get; set; }

    public int? usuarioid { get; set; }

    public virtual ICollection<InfoView> InfoViews { get; set; } = new List<InfoView>();

    public virtual Usuario? Usuario { get; set; }
}