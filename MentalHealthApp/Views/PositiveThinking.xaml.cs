namespace MentalHealthApp.Views;
using MentalHealthApp.ViewModels;

public partial class PositiveThinking : ContentPage
{
	public PositiveThinking()
	{
		InitializeComponent();
		BindingContext = new SubTopicsViewModel();
	}
}