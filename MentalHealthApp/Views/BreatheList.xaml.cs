namespace MentalHealthApp.Views;

using Microsoft.Maui.Platform;
using ViewModels;
using Popups;
using Mauiview = CommunityToolkit.Maui.Views;
public partial class BreatheList : ContentPage
{
    BreatheListViewModel brMV;
    public BreatheList()
	{
		InitializeComponent();
        brMV = new BreatheListViewModel();
        BindingContext = brMV;
    }

    private void AddToCalendar_Clicked(object sender, TappedEventArgs e)
    {
        Mauiview.PopupExtensions.ShowPopup(this, new BreatheDatePickerPopup(brMV));
    }
}