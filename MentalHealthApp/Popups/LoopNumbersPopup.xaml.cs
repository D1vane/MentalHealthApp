
using CommunityToolkit.Maui.Views;
namespace MentalHealthApp.Popups;
using ViewModels;
public partial class LoopNumbersPopup : Popup
{
    int number;
    BreatheViewModel breatheVM = new BreatheViewModel();
	public LoopNumbersPopup(BreatheViewModel breathe)
	{
		InitializeComponent();
        breatheVM = breathe;
		BindingContext = breatheVM;
	}

    private void CollectionView_Scrolled(object sender, ItemsViewScrolledEventArgs e)
    {
        numbersCollView.SelectedItem = e.CenterItemIndex+1;
        number = e.CenterItemIndex + 1;
    }

    private void numbersCollView_Loaded(object sender, EventArgs e)
    { 
        numbersCollView.ScrollTo(breatheVM.LoopNumbers);
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        breatheVM.LoopNumbers = number;
        breatheVM.LoopsToTime();
        Close();
    }

    private void Cancel_Clicked(object sender, EventArgs e)
    {
        Close();
    }
}