using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentalHealthApp.ViewModels
{
    [QueryProperty("MName", "meditationName")]
    [QueryProperty("MTime", "meditationTime")]
    [QueryProperty("MLevel", "meditationLevel")]
    public partial class MeditationViewModel : ObservableObject
    {
        [ObservableProperty]
        string mName;
        [ObservableProperty]
        int mTime;
        [ObservableProperty]
        int mLevel;
        [ObservableProperty]
        string content = "\tВо время выполнения фокусируйтесь на дыхании и счете, отбросив посторонние мысли, оставайтесь расслабленным. Выдох должен быть более медленным, чем вдох. \n\tСовет. Если во время выполнения фокус со счета пропадает, можете считать в случайном порядке. Например, не 1..2..3..4, а 3..1..2..4, это поможет держать фокус на счете и успокоить тревожные мысли. Да и не обязательно считать от 1 до 4, можете хоть называть животных, дело вашей фантазии, главное соблюдать длительность 4 секунды";
        [ObservableProperty]
        string[] guide = "1. Вдыхайте через нос 4 секунды;2. Задержите дыхание на 4 секунды;3. Выдыхайте через рот 4 секунды;4. Задержите дыхание на 4 секунды;5. Повторение цикла в течение 5–10 минут.".Split(';');
    }
}
