namespace MentalHealthApp.Views;
using MentalHealthApp.ViewModels;
public partial class ForReading : ContentPage
{
	private ForReadingViewModel vM { get; set; }
	public ForReading()
	{
		InitializeComponent();
		vM = new ForReadingViewModel();
		BindingContext = vM;
	}
}