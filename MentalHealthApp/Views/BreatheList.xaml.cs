namespace MentalHealthApp.Views;
using ViewModels;
public partial class BreatheList : ContentPage
{
	public BreatheList()
	{
		InitializeComponent();
		BindingContext = new BreatheListViewModel();
	}
}