namespace MentalHealthApp.Popups;

using CommunityToolkit.Maui.Views;
using ViewModels;
public partial class GuidePopup : Popup
{
	BreatheViewModel breathe = new BreatheViewModel();
	public GuidePopup(BreatheViewModel brth)
	{
		InitializeComponent();
		breathe = brth;
		BindingContext = breathe;
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		Close();
    }
}