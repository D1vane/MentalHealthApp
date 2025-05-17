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
        int emojiStatus;

    }
}
