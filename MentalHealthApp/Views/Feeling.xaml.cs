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
        {
            feeling.EmojiStatus = (int)slider.Value;
            feeling.EmojiDescription = feeling.FullDescriptionList[(int)slider.Value];
        }
        if (slider.Value == 0)
        {
            buttonSave.IsVisible = false;
        }
        else
            buttonSave.IsVisible = true;

    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        sliderEmoji.Value = 0;
        buttonSave.IsVisible = false;
    }
}