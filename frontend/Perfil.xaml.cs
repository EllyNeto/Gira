namespace frontend;

public partial class Perfil : ContentPage
{
	public Perfil()
	{
		InitializeComponent();
	}
    private void OnStudentHomeButtonClicked(object sender, EventArgs e)
	{
        Navigation.PushAsync(new Home()); 
    }
    private void OnAddProfileButtonClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Perfil());
    }
}
