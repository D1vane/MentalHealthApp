namespace MentalHealthApp.Views;

using MentalHealthApp.Models;
using ViewModels;
public partial class Sleep : ContentPage
{
    SleepViewModel sleepVM;
	public Sleep()
	{
		InitializeComponent();
        sleepVM = new SleepViewModel();
		BindingContext = sleepVM;
	}

    private void hoursCollView_Loaded(object sender, EventArgs e)
    {
        hoursCollView.ScrollTo(7);
    }

    private void minutesCollView_Loaded(object sender, EventArgs e)
    {
        minutesCollView.ScrollTo(30);
    }

    private void minutesCollView_Scrolled(object sender, ItemsViewScrolledEventArgs e)
    {
        minutesCollView.SelectedItem = e.CenterItemIndex + 1;
    }

    private void hoursCollView_Scrolled(object sender, ItemsViewScrolledEventArgs e)
    {
        hoursCollView.SelectedItem = e.CenterItemIndex;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        List<SleepFactorsModel> selectedFctrsBfrSleep = collViewBfrSleep.SelectedItems.Cast<SleepFactorsModel>().ToList();
        List<SleepFactorsModel> selectedFctrsSleep = collViewSleep.SelectedItems.Cast<SleepFactorsModel>().ToList();
        sleepVM.WriteSleepToDB(hoursCollView.SelectedItem.ToString(), minutesCollView.SelectedItem.ToString(), selectedFctrsBfrSleep, selectedFctrsSleep);
    }

}