namespace MentalHealthApp.Views;
using MentalHealthApp.ViewModels;

public partial class PositiveThinking : ContentPage
{
	public PositiveThinking()
	{
		InitializeComponent();
		BindingContext = new SubTopicsViewModel();
	}

    private void GoToWorkCard_Tapped(object sender, TappedEventArgs e)
    {
        Shell.Current.GoToAsync("PositiveThinkingCards");
    }
}