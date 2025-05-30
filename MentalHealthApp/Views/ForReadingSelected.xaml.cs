namespace MentalHealthApp.Views;
using MentalHealthApp.ViewModels;
using Popups;
using Mauiview = CommunityToolkit.Maui.Views;
public partial class ForReadingSelected : ContentPage
{
	ForReadingSelectedViewModel frVM;
	public ForReadingSelected()
	{
		InitializeComponent();
		frVM = new ForReadingSelectedViewModel();
		BindingContext = frVM;
	}

    private void AddToCalendar_Clicked(object sender, TappedEventArgs e)
    {
		Mauiview.PopupExtensions.ShowPopup(this, new ForReadingDatePickerPopup(frVM));
    }
}