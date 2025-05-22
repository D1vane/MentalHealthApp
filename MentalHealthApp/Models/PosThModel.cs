
using SQLite;

namespace MentalHealthApp.Models
{
    [Table("Мысль")]
    public class PosThModel
    {
        [PrimaryKey,AutoIncrement, Column("IDМысли")]
        public int ThinkID { get; set; }

        [Column("Тема")]
        public string Theme { get; set; }

        [Column("Негативная")]
        public string NegativeThink { get; set; }

        [Column("Позитивная")]
        public string PositiveThink { get; set; }

        [Column("Избранное")]
        public int isFavourite { get; set; }

    }
}
