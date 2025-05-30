namespace MentalHealthApp.Views;
using MentalHealthApp.ViewModels;
using Microsoft.Maui.Platform;
using Popups;
using Mauiview = CommunityToolkit.Maui.Views;
public partial class MeditationList : ContentPage
{
	MeditationListViewModel mlMV;
	public MeditationList()
	{
		InitializeComponent();
		mlMV = new MeditationListViewModel();
		BindingContext = mlMV;
	}

    private void AddToCalendar_Clicked(object sender, TappedEventArgs e)
    {
		Mauiview.PopupExtensions.ShowPopup(this, new MeditationDatePickerPopup(mlMV));
    }
}