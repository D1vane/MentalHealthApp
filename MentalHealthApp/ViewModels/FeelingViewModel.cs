using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentalHealthApp.ViewModels
{
    public partial class FeelingViewModel: ObservableObject
    {
        [ObservableProperty]
        int emojiStatus = 0;
        [ObservableProperty]
        string[] emojiDescriptionArr = { "", "1. Отвратительно", "2. Ужасно", "3. Скверно", "4. Плохо", 
            "5. Хочется грустить", "6. Бывало и лучше", "7. Хорошо", "8. Отлично", "9. Превосходно", "10. Лучше некуда" };
        [ObservableProperty]
        string emojiDescription;
    }
}
