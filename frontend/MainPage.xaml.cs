using frontend.IRepository;
using frontend.Dto;
using frontend.Model;

namespace frontend
{
    public partial class MainPage : ContentPage
    {
        readonly IUsuario usuariorepository = new UsuarioService();
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnLabelTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Cadastrar());
        }

        private async void OnClick(object sender, EventArgs e)
        {
            string email = usuarioo.Text;
            string password = senha.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                await Shell.Current.DisplayAlert("Erro", "Todos os campos são obrigatórios", "Ok");
                return;
            }

            Usuario usuario = await usuariorepository.Login(email, password);

            if (usuario != null)
            {
                Console.WriteLine($"Email retornado: {usuario.email}");
                Console.WriteLine($"Senha retornada: {usuario.senha}");

                await Navigation.PushAsync(new Home());
            }
            else
            {
                await DisplayAlert("Erro", "Credenciais incorretas", "Ok");
            }

        }
    }
}
