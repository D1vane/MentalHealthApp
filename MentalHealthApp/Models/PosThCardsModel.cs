
using SQLite;

namespace MentalHealthApp.Models
{
    [Table("ПозитивноеМышление")]
    public class PosThCardsModel
    {
        [PrimaryKey, AutoIncrement, Column("IDТемы")]
        public int ThemeID { get; set; }

        [Column("IDКатегории")]
        public int CategoryID { get; set; }

        [Column("Тема")]
        public string ThemeName { get; set; }

        [Column("ЧислоКарточек")]
        public int CountOfCards { get; set; }

        [Column("Изображение")]
        public string ImagePath { get; set; }
    }
}
