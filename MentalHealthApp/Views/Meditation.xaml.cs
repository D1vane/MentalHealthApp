namespace MentalHealthApp.Views;
using MentalHealthApp.ViewModels;
using Mauiview = CommunityToolkit.Maui.Views;
using Popups;
public partial class Meditation : ContentPage
{
    MeditationViewModel mlMV;
    public Meditation()
	{
		InitializeComponent();
        mlMV = new MeditationViewModel();
        BindingContext = mlMV;
    }

    private void AddToCalendar_Clicked(object sender, TappedEventArgs e)
    {
        Mauiview.PopupExtensions.ShowPopup(this, new MeditationDatePickerPopup(mlMV));
    }
}