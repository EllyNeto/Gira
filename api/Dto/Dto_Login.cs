namespace api.Dto
{
    public class Dto_Login
    {
        public int Id { get; set; }
        public string? Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Telefone { get; set; }
        public short Nivel_Acesso { get; set; }
        public DateOnly Data_de_Nascimento { get; set; }
    }
}
