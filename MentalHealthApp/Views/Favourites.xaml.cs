namespace MentalHealthApp;
using MentalHealthApp.ViewModels;
public partial class Favourites : ContentPage
{
	public Favourites()
	{
		InitializeComponent();
		BindingContext = new FavouritesViewModel();
	}
}