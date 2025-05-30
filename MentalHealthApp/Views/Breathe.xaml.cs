namespace MentalHealthApp.Views;


using ViewModels;
using Popups;

using Mauiview = CommunityToolkit.Maui.Views;
public partial class Breathe : ContentPage
{
	BreatheViewModel breatheVM;
	public Breathe()
	{
		InitializeComponent();
        breatheVM = new BreatheViewModel();
		BindingContext = breatheVM;
	}

    private void LoopNumberTapped(object sender, TappedEventArgs e)
    {
        Mauiview.PopupExtensions.ShowPopup(this,new LoopNumbersPopup(breatheVM));
    }

    private void GuideTapped(object sender, TappedEventArgs e)
    {
        Mauiview.PopupExtensions.ShowPopup(this, new GuidePopup(breatheVM));
    }

    private void AddToCalendar_Clicked(object sender, TappedEventArgs e)
    {
        Mauiview.PopupExtensions.ShowPopup(this, new BreatheDatePickerPopup(breatheVM));
    }
}