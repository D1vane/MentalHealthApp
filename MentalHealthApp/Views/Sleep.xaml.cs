namespace MentalHealthApp.Views;
using ViewModels;
public partial class Sleep : ContentPage
{
	public Sleep()
	{
		InitializeComponent();
		BindingContext = new SleepViewModel();
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
}