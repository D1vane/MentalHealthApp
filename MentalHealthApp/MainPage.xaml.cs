using MentalHealthApp.ViewModels;
namespace MentalHealthApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        BindingContext = new MainPageViewModel();
        }
    }

}
