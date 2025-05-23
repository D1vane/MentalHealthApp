using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentalHealthApp.Models
{
    [Table("Медитация")]
    public class MeditationModel
    {
        [PrimaryKey, AutoIncrement, Column("IDМедитации")]
        public int MeditationID { get; set; }

        [Column("Наименование")]
        public string MeditationName { get; set; }

        [Column("Содержание")]
        public string MeditationContent { get; set; }

        [Column("Сложность")]
        public int MeditationLevel { get; set; }

        [Column("Руководство")]
        public string MeditationGuide { get; set; }

        [Column("Длительность")]
        public int MeditationDuration { get; set; }

        [Column("Изображение")]
        public string ImagePath { get; set; }

        [Column("Избранное")]
        public int IsFavourite { get; set; }

        [ManyToMany(typeof(MeditationToCalendar))]
        public List<CalendarModel> Days { get; set; }

    }
}
