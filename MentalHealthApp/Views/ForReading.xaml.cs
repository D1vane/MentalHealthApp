namespace MentalHealthApp.Views;
using MentalHealthApp.ViewModels;
public partial class ForReading : ContentPage
{
	public ForReading()
	{
		InitializeComponent();
		BindingContext = new ForReadingViewModel();
	}
}