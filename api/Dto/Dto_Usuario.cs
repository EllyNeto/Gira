namespace api.Dto
{
    public class RegisterUserDto
    {
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Telefone { get; set; }
        public DateOnly Data_de_Nascimento { get; set; }
        public string Senha { get; set; } = null!;
        public string ConfirmacaoDeSenha { get; set; } = null!;
    }
}

