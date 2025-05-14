namespace MentalHealthApp.Views;
using MentalHealthApp.ViewModels;
public partial class ForReadingSelected : ContentPage
{
	public ForReadingSelected()
	{
		InitializeComponent();
		BindingContext = new ForReadingSelectedViewModel();
	}
}