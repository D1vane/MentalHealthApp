namespace MentalHealthApp.Views;
using ViewModels;
public partial class ExistingFeeling : ContentPage
{
	public ExistingFeeling()
	{
		InitializeComponent();
		BindingContext = new ExistingFeelingViewModel();
	}
}