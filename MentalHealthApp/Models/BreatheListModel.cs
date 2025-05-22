
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentalHealthApp.Models
{
    [Table("ДыхательнаяТехника")]
    public class BreatheListModel
    {
        [PrimaryKey,AutoIncrement, Column("IDДыхательнойТехники")]
        public int BreatheID { get; set; }

        [Column("Наименование")]
        public string NameOfBreathe { get; set; }

        [Column("Руководство")]
        public string Guide { get; set; }

        [Column("ДлительностьЦикла")]
        public int LoopDuration { get; set; }

        [Column("Изображение")]
        public string ImagePath { get; set; }

    }
}
