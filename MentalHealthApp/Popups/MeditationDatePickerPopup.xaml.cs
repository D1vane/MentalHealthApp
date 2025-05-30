namespace MentalHealthApp.Popups;

using CommunityToolkit.Maui.Views;
using ViewModels;
public partial class MeditationDatePickerPopup : Popup
{
	MeditationListViewModel meditationVM;
	public MeditationDatePickerPopup(MeditationListViewModel mlVM)
	{
		InitializeComponent();
		meditationVM = mlVM;
		BindingContext = meditationVM;
	}

    private void Cancel_Clicked(object sender, EventArgs e)
    {
		Close();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
		meditationVM.AddMeditationToDB();
		Close();
    }
}