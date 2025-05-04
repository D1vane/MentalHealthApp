using Microsoft.Maui.Controls.Shapes;

namespace MentalHealthApp;

public partial class Planner : ContentPage
{

	public Planner()
	{
		InitializeComponent();
	}
    private IView newTask ()
    {
        Grid grid = (new Grid
        {
            Margin = new Thickness(16, 4, 12, 4),
            ColumnSpacing = 12,
            RowDefinitions =
            {
                new RowDefinition(),
                new RowDefinition()
            },
            ColumnDefinitions =
            {
                new ColumnDefinition(WidthRequest = 12),
                new ColumnDefinition(WidthRequest = 242),
                new ColumnDefinition(WidthRequest = 10),
                new ColumnDefinition(WidthRequest = 24),
                new ColumnDefinition(WidthRequest = 24)
            }

        });
        grid.Add(new Ellipse
        {
            WidthRequest = 12,
            HeightRequest = 12,
            Fill = SolidColorBrush.Gray,
            HorizontalOptions = LayoutOptions.Start
        });
        grid.Add(new Label
        {
            Text = "Почитать Преступление и Наказание",
            FontFamily = "Roboto",
            FontSize = 14,
            LineBreakMode = LineBreakMode.TailTruncation,
            Margin = new Thickness(0, 2, 0, 0)
        }, 1, 0);
        grid.Add(new Image
        {
            Source = "cross_icon.png",

        }, 2, 0);
        grid.Add(new Image
        {
            Source = "threedots_icon.png",

        }, 3, 0);
        grid.Add(new CheckBox
        {
            Color = Color.FromArgb("#FF808080"),
            WidthRequest = 24,
            HeightRequest = 24

        }, 4, 0);
        grid.Add(new Label
        {
            Text = "18:30",
            FontFamily = "Roboto",
            FontSize = 14,
        }, 1, 1);

        Border border = new Border
        {
            StrokeShape = new RoundRectangle { CornerRadius = 20 },
            HeightRequest = 58,
            //Content = grid,

        };
        return border;
    }
    private void AddNewTask_Clicked(object sender, TappedEventArgs e)
    {
        //IView border = newTask();

        //TasksStackLayout.Children.Append(border);

    }
    public class Task
    {
        public Ellipse ColorMark { get; set; }
        public string TextTask { get; set; }
        public Image Cross { get; set; }
        public Image ThreeDots { get; set; }
        public CheckBox IsCompleted { get; set; }
        public string TimeOfTask { get; set; }
    }
}