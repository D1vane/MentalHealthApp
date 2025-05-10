namespace MentalHealthApp.Views;
using MentalHealthApp.ViewModels;

public partial class PositiveThinkingCards : ContentPage
{

	public PositiveThinkingCards()
	{
		InitializeComponent();
		BindingContext = new CardsThinksViewModel();
	}
}