
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace MentalHealthApp.Models
{
    [Table("Категория")]
    public class CategoryModel
    {
        [PrimaryKey,AutoIncrement, Column("IDКатегории")]
        public int CategoryID { get; set; }

        [Column ("Наименование")]   
        public string NameOfCategory { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<ThemeModel> Themes { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<ForReadingModel> Readings { get; set; }

    }
}
