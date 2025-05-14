namespace MentalHealthApp.Views;
using MentalHealthApp.ViewModels;
public partial class MeditationList : ContentPage
{
	public MeditationList()
	{
		InitializeComponent();
		BindingContext = new MeditationListViewModel();
	}
}