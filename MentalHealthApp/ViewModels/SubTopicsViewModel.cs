
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MentalHealthApp.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MentalHealthApp.ViewModels
{
    public partial class SubTopicsViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<CategoryModel> cats = new()
        {
            new() {NameOfCategory = "Работа"},
            new() {NameOfCategory = "Учеба"},
            new() {NameOfCategory = "Здоровье"},
            new() {NameOfCategory = "Быт"}

        };

        [ObservableProperty]
        private ObservableCollection<PosThModel> work = new()
        {
            new () {SubTopicName = "Отношения с начальником", ImagePath = "boss_reading.jpg"} ,
                new () {SubTopicName = "Отношения с коллегами", ImagePath = "colleagues_reading.jpg" },
                new() {SubTopicName = "Первый рабочий день", ImagePath = "firstdaywork_reading.jpg"},
                new () {SubTopicName = "Производительность", ImagePath = "efficiency_reading.jpg"}
        };
        [ObservableProperty]
        private ObservableCollection<PosThModel> study = new()
        {
            new () {SubTopicName = "Отношения с учителем", ImagePath = "teacher_reading.jpg"},
                new () {SubTopicName = "Отношения с товарищами", ImagePath = "schoolfriends_reading.jpg"},
                new() {SubTopicName = "Первый учебный день", ImagePath = "student_reading.jpg" },
                new () {SubTopicName = "Успеваемость", ImagePath = "schoolprogress_reading.jpg"}
        };
        [ObservableProperty]
        private ObservableCollection<PosThModel> health = new()
        {
            new () {SubTopicName = "Тревожное состояние", ImagePath = "anxiety_reading.jpg" },
                new () {SubTopicName = "Личная гигиена", ImagePath = "selfheallth_reading.jpg"},
                new() {SubTopicName = "Здоровый образ жизни", ImagePath = "hls_reading.jpg" },
                new () {SubTopicName = "Мысли о старости", ImagePath = "oldage_reading.jpg"}
        };
        [ObservableProperty]
        private ObservableCollection<PosThModel> life = new()
        {
            new () {SubTopicName = "Отношения с семьей", ImagePath = "family_reading.jpg"} ,
                new () {SubTopicName = "Личные обязанности", ImagePath = "lifetodo_reading.jpg"},
                new() {SubTopicName = "Домашние животные", ImagePath = "pets_reading.jpg" },
                new () {SubTopicName = "Внимание ребенку", ImagePath = "child_reading.jpg" }
        };
        [ObservableProperty]
        private ObservableCollection<PosThCardsModel> thCards = new()
        {
            new () {NegThink = "Начальник придирается ко мне и требует больше, чем от других сотрудников", PosThink = "Вероятно, начальник видит во мне потенциал и потому предъявляет более высокие требования — это шанс расти профессионально",NameOfCategory = "Работа"},
            new () {NegThink = "Начальник предвзято относится ко мне", PosThink = "Может быть, я интерпретирую ситуацию слишком лично. Стоит попробовать открыто обсудить рабочие моменты и уточнить ожидания, чтобы прояснить недопонимания",NameOfCategory = "Работа"},
           new () {NegThink = "Начальник не замечает мои достижения и обесценивает мой труд", PosThink = "Возможно, начальник просто не осведомлён о моих результатах — я могу научиться быть более активным в коммуникации", NameOfCategory = "Работа"},
            new () {NegThink = "Начальник игнорирует мои просьбы и предложения", PosThink = "Возможно, мои идеи требуют более чёткого обоснования или подачи в нужное время и формате.",NameOfCategory = "Работа"},
            new () {NegThink = "Начальник намеренно не хочет повышать меня и давать новые проекты", PosThink = "Вероятно, сейчас не лучшее время для повышения по объективным причинам. Я могу уточнить, что нужно улучшить, чтобы перейти на следующий уровень, и показать свою готовность к новым задачам",NameOfCategory = "Работа"},
        };
        [RelayCommand]
        private void GetSubTopicName(object parametr)
        {
            var param = parametr as object[];
            var subTpc = param[0];
            var tPc = param[1];
            Shell.Current.GoToAsync($"PositiveThinkingCards", new Dictionary<string, object>
            {["topicName"] = tPc,
                ["subTopicName"] = subTpc});
        }
    }
}
