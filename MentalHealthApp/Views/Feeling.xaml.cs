namespace MentalHealthApp.Views;
using ViewModels;
public partial class Feeling : ContentPage
{
    readonly double sliderIncrement = 1;
    double sliderCorrectValue;
    FeelingViewModel feeling = new FeelingViewModel();
    public Feeling()
    {
        InitializeComponent();
        BindingContext = feeling;
    }

    private void sliderEmoji_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        Slider slider = (Slider)sender;
        if (feeling.EmojiStatus != (int)slider.Value)
            feeling.EmojiStatus = (int)slider.Value;

    }
}