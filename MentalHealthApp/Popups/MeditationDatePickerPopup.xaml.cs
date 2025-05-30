namespace MentalHealthApp.Popups;

using CommunityToolkit.Maui.Views;
using MentalHealthApp.Models;
using ViewModels;
public partial class MeditationDatePickerPopup : Popup
{
	MeditationListViewModel meditationVM;
	MeditationViewModel mVM;
	public MeditationDatePickerPopup(MeditationListViewModel mlVM)
	{
		InitializeComponent();
		meditationVM = mlVM;
		BindingContext = meditationVM;
	}

    public MeditationDatePickerPopup(MeditationViewModel mlVM)
    {
        InitializeComponent();
        mVM = mlVM;
        BindingContext = mVM;
    }

    private void Cancel_Clicked(object sender, EventArgs e)
    {
		Close();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (meditationVM != null)
		    meditationVM.AddMeditationToDB();
        else if (mVM != null)
            mVM.AddMeditationToDB();
		Close();
    }
}