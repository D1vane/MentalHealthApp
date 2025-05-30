namespace MentalHealthApp.Popups;
using MentalHealthApp.ViewModels;
using CommunityToolkit.Maui.Views;
public partial class ForReadingDatePickerPopup : Popup
{

    ForReadingSelectedViewModel readingVM;

    public ForReadingDatePickerPopup(ForReadingSelectedViewModel rVM)
    {
        InitializeComponent();
        readingVM = rVM;
        BindingContext = readingVM;
    }

    private void Cancel_Clicked(object sender, EventArgs e)
    {
        Close();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
            readingVM.AddReadingToDB();
        Close();
    }
}