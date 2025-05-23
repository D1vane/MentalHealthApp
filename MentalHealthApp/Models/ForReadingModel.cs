
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace MentalHealthApp.Models
{
    [Table("ДляЧтения")]
    public class ForReadingModel
    {
        [PrimaryKey,AutoIncrement, Column("IDИнформации")]
        public int InformationID { get; set; }

        [Column("IDКатегории"),ForeignKey(typeof(CategoryModel))]
        public int CategoryID { get; set; }

        [Column("ДлительностьЧтения")]
        public int ReadingDuration { get; set; }

        [Column("Содержание")]
        public string Content { get; set; }

        [Column("Подразделы")]
        public string Sections { get; set; }

        [Column("Избранное")]
        public int isFavourite { get; set; }

        [Column("Изображение")]
        public string ImagePath { get; set; }

        [Column("Название")]
        public string ReadingName { get; set; }

        

        [ManyToMany(typeof(ReadingToCalendar))]
        public List<CalendarModel> Days { get; set; }

        [ManyToOne]
        public CategoryModel CurrentCategory { get; set; }

    }
}
