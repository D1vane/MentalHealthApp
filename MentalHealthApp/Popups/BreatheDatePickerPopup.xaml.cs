using CommunityToolkit.Maui.Views;
using MentalHealthApp.ViewModels;
namespace MentalHealthApp.Popups;

public partial class BreatheDatePickerPopup : Popup
{
    BreatheListViewModel breatheVM;
    BreatheViewModel bVM;
    public BreatheDatePickerPopup(BreatheListViewModel brVM)
    {
        InitializeComponent();
        breatheVM = brVM;
        BindingContext = breatheVM;
    }

    public BreatheDatePickerPopup(BreatheViewModel bVM)
    {
        InitializeComponent();
        this.bVM = bVM;
        BindingContext = this.bVM;
    }

    private void Cancel_Clicked(object sender, EventArgs e)
    {
        Close();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        if (breatheVM != null)
            breatheVM.AddBreatheToDB();
        else if (bVM != null)
            bVM.AddBreatheToDB();
        Close();
    }
}