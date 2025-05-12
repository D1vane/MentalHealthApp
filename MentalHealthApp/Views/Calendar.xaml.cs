namespace MentalHealthApp;
using MentalHealthApp.ViewModels;
public partial class Calendar : ContentPage
{
	public Calendar()
	{
		InitializeComponent();
		CalendarViewModel vm = new();
		vm.FIllTheList();
		BindingContext = vm;
	}
}