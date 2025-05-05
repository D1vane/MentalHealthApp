using MentalHealthApp.ViewModels;

using System.Collections.ObjectModel;

namespace MentalHealthApp;

public partial class Planner : ContentPage
{
    public Planner()
    {
        InitializeComponent();
        BindingContext = new PlannerViewModel();
    }

}
