
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MentalHealthApp.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MentalHealthApp.ViewModels
{
    [QueryProperty("STName", "subTopicName")]
    [QueryProperty("TName","topicName")]
    public partial class CardsThinksViewModel : ObservableObject
    {
        [ObservableProperty]
        private string sTName;
        [ObservableProperty]
        private string tName;

        [ObservableProperty]
        private ObservableCollection<PosThCardsModel> thCards = new()
        {
            new () {NegThink = "Начальник придирается ко мне и требует больше, чем от других сотрудников", PosThink = "Вероятно, начальник видит во мне потенциал и потому предъявляет более высокие требования — это шанс расти профессионально",NameOfCategory = "Работа"},
            new () {NegThink = "Начальник предвзято относится ко мне", PosThink = "Может быть, я интерпретирую ситуацию слишком лично. Стоит попробовать открыто обсудить рабочие моменты и уточнить ожидания, чтобы прояснить недопонимания",NameOfCategory = "Работа"},
           new () {NegThink = "Начальник не замечает мои достижения и обесценивает мой труд", PosThink = "Возможно, начальник просто не осведомлён о моих результатах — я могу научиться быть более активным в коммуникации", NameOfCategory = "Работа"},
            new () {NegThink = "Начальник игнорирует мои просьбы и предложения", PosThink = "Возможно, мои идеи требуют более чёткого обоснования или подачи в нужное время и формате.",NameOfCategory = "Работа"},
            new () {NegThink = "Начальник намеренно не хочет повышать меня и давать новые проекты", PosThink = "Вероятно, сейчас не лучшее время для повышения по объективным причинам. Я могу уточнить, что нужно улучшить, чтобы перейти на следующий уровень, и показать свою готовность к новым задачам",NameOfCategory = "Работа"},
        };

    }
}
