namespace MentalHealthApp.Views;
using MentalHealthApp.ViewModels;
public partial class Meditation : ContentPage
{
	public Meditation()
	{
		InitializeComponent();
		BindingContext = new MeditationViewModel();
	}
}