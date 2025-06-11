namespace MentalHealthApp.Views;
using ViewModels;
public partial class StartedBreathe : ContentPage
{
    public StartedBreathe()
    {
        InitializeComponent();
        BindingContext = new StartedBreatheViewModel();
        StartAnimation();
        
    }

    void StartAnimation()
    {
        var parentAnimation = new Animation();
        var topBarAnimation = new Animation(v => progressBarTop.Progress = v, 0, 1);
        var rightBarAnimation = new Animation(v => progressBarRight.Progress = v, 0, 1);
        var botBarAnimation = new Animation(v => progressBarBot.Progress = v, 0, 1);
        var leftBarAnimation = new Animation(v => progressBarLeft.Progress = v, 0, 1);
        parentAnimation.Add(0, 0.25, topBarAnimation);
        parentAnimation.Add(0.25, 0.5, rightBarAnimation);
        parentAnimation.Add(0.5, 0.75, botBarAnimation);
        parentAnimation.Add(0.75, 1, leftBarAnimation);
        parentAnimation.Commit(this, "ChildAnimations", length: 16000, repeat: () => IsContinue(), finished: (v, c) => progressBarRight.Progress
        = progressBarBot.Progress = progressBarLeft.Progress = 0);
    }

    bool IsContinue()
    {
        if (labelMinutes.Text == "0" && Convert.ToInt32(labelSeconds.Text) < 16)
            return false;
        else return true;
    }
   
}