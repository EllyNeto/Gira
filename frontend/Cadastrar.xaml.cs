namespace frontend;

public partial class Cadastrar: ContentPage
{
	public Cadastrar()
	{
		InitializeComponent();
	}
    private async void OnClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}