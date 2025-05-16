namespace MentalHealthApp.Views;


using ViewModels;
using Popups;

using Mauiview = CommunityToolkit.Maui.Views;
public partial class Breathe : ContentPage
{
	BreatheViewModel breatheVM = new BreatheViewModel();
	public Breathe()
	{
		InitializeComponent();
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
}