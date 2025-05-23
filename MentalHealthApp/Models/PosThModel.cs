
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace MentalHealthApp.Models
{
    [Table("ПозитивноеМышление")]
    public class PosThModel
    {
        [PrimaryKey,AutoIncrement, Column("IDМысли")]
        public int ThinkID { get; set; }

        [Column("IDТемы"),ForeignKey(typeof(ThemeModel))]
        public int ThemeID { get; set; }

        [Column("Негативная")]
        public string NegativeThink { get; set; }

        [Column("Позитивная")]
        public string PositiveThink { get; set; }

        [Column("Избранное")]
        public int isFavourite { get; set; }

        [ManyToOne]
        public ThemeModel CurrentTheme { get; set; }

    }
}
