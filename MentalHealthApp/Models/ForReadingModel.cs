
using SQLite;

namespace MentalHealthApp.Models
{
    [Table("ДляЧтения")]
    public class ForReadingModel
    {
        [Column ("IDИнформации")]
        public string InformationID { get; set; }

        [Column("IDКатегории")]
        public int CategoryID { get; set; }

        [Column("ДлительностьЧтения")]
        public int ReadingDuration { get; set; }

        [Column("Тема")]
        public string Theme { get; set; }

        [Column("Содержание")]
        public string Content { get; set; }

        [Column("Подразделы")]
        public string Sections { get; set; }

        [Column("Избранное")]
        public bool isFavourite { get; set; }

        [Column("Изображение")]
        public string ImagePath { get; set; }
    }
}
