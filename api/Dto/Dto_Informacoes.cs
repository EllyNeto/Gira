namespace api.Dto
{
    public class Dto_Informacoes
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public DateTime Dataa { get; set; }
        public string Evento { get; set; } = null!;
        public string Organizacao { get; set; } = null!;
        public string Foto { get; set; }
        public DateTime DataDeRealizacao { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UsuarioId { get; set; }
        public List<string> InfoViews { get; set; }
        public string Usuario { get; set; }
    }
}

