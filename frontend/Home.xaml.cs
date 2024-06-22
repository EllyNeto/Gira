using System.Collections.ObjectModel;

namespace frontend;

public partial class Home : ContentPage
{
    private ObservableCollection<Activity> activities;
    public Home()
	{
		InitializeComponent();
        activities = new ObservableCollection<Activity>();
    }
    private void OnAddActivityButtonClicked(object sender, EventArgs e)
    {
        var newActivity = new Activity
        {
            Title = $"Atividade {activities.Count + 1}: Visita ao Museu de Ciências Naturais",
            Description = "Hoje, os alunos participarão de uma excursão ao Museu de Ciências Naturais. Eles terão a oportunidade de aprender sobre história natural e participar de atividades interativas."
        };
        activities.Add(newActivity);
        DisplayActivities();
    }

    private void OnEditActivityButtonClicked(Activity activity)
    {
        var entryTitle = new Entry
        {
            Text = activity.Title,
            FontSize = 20,
            FontAttributes = FontAttributes.Bold,
            HorizontalOptions = LayoutOptions.Center,
            TextColor = Colors.Black,
        };

        var entryDescription = new Entry
        {
            Text = activity.Description,
            FontSize = 16,
            TextColor = Colors.Black,
            HorizontalOptions = LayoutOptions.Center
        };

        var saveButton = new Button
        {
            Text = "Salvar",
            BackgroundColor = Colors.LightGreen,
            FontAttributes = FontAttributes.Bold,
            TextColor = Colors.Black,
            CornerRadius = 20
        };
        saveButton.Clicked += (s, e) => OnSaveEditActivityButtonClicked(activity, entryTitle.Text, entryDescription.Text);

        var editLayout = new StackLayout
        {
            Spacing = 10,
            Children = { entryTitle, entryDescription, saveButton }
        };

        activity.Frame.Content = editLayout;
    }

    private void OnSaveEditActivityButtonClicked(Activity activity, string newTitle, string newDescription)
    {
        activity.Title = newTitle;
        activity.Description = newDescription;
        DisplayActivities();
    }

    private void OnDeleteActivityButtonClicked(Activity activity)
    {
        activities.Remove(activity);
        DisplayActivities();
    }

    private void DisplayActivities()
    {
        ActivitiesLayout.Children.Clear();
        foreach (var activity in activities)
        {
            var activityFrame = new Frame
            {
                CornerRadius = 10,
                BackgroundColor = Colors.LightYellow,
                Padding = 20,
                HasShadow = true,
                Margin = new Thickness(0, 0, 0, 20) // Espaçamento inferior entre atividades
            };

            var activityLabel = new Label
            {
                Text = activity.Title,
                FontSize = 20,
                TextColor = Colors.Black,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 0, 0, 10) // Espaçamento inferior do texto
            };

            var activityDescription = new Label
            {
                Text = activity.Description,
                TextColor = Colors.Black,
                FontSize = 16,
                HorizontalOptions = LayoutOptions.Center
            };

            // Botões de Editar e Apagar
            var editButton = new Button
            {
                Text = "Editar",
                BackgroundColor = Colors.LightGreen,
                TextColor = Colors.Black,
                FontAttributes = FontAttributes.Bold,
                CornerRadius = 20,
                Margin = new Thickness(0, 0, 10, 0)
            };
            editButton.Clicked += (s, e) => OnEditActivityButtonClicked(activity);

            var deleteButton = new Button
            {
                Text = "Apagar",
                BackgroundColor = Colors.LightGreen,
                FontAttributes = FontAttributes.Bold,
                CornerRadius = 20
            };
            deleteButton.Clicked += (s, e) => OnDeleteActivityButtonClicked(activity);

            // Layout dos botões
            var buttonLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center,
                Spacing = 20,
                Children = { editButton, deleteButton }
            };

            // Adiciona os controles à Frame
            activityFrame.Content = new StackLayout
            {
                Spacing = 10,
                BackgroundColor = Colors.LightYellow,
                Children = { activityLabel, activityDescription, buttonLayout }
            };

            // Define a frame na atividade
            activity.Frame = activityFrame;

            // Adiciona a Frame à pilha de atividades
            ActivitiesLayout.Children.Add(activityFrame);
        }
    }

    private async void OnStudentProfileButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Perfil());
    }
}

public class Activity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Frame Frame { get; set; }
}
   


