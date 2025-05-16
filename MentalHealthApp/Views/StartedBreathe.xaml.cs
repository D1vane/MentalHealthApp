namespace MentalHealthApp.Views;
using ViewModels;
public partial class StartedBreathe : ContentPage
{
	public StartedBreathe()
	{
		InitializeComponent();
		BindingContext = new StartedBreatheViewModel();
	}
}