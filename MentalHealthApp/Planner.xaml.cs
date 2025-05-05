using Microsoft.Maui.Controls.Shapes;

namespace MentalHealthApp;

public partial class Planner : ContentPage
{
    List<Task> tasks = [];
    public Planner()
    {
        InitializeComponent();
        tasks =
        [
            new Task {
            TextTask = "��������� ������������ � ���������",
            TimeOfTask = "18:30"},
            new Task {
            TextTask = "������� � ������� �� ����������",
            TimeOfTask = ""},
        ];

        listOfTasks.ItemsSource = tasks;
        BindingContext = this;
    }

    private void AddNewTask_Clicked(object sender, TappedEventArgs e)
    {
        tasks.Add(new Task
        {
            TextTask = "��������� ������������ � ���������",
            TimeOfTask = "18:30"
        });
        //listOfTasks.ItemsSource = tasks;
    }
    public class Task
    {
        public string TextTask { get; set; }
        public string TimeOfTask { get; set; }
    }

}
