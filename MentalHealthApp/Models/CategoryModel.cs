
using SQLite;

namespace MentalHealthApp.Models
{
    [Table("Категория") ]
    public class CategoryModel
    {
        [Column ("IDКатегории")]
        public int CategoryID { get; set; }

        [Column ("Наименование")]
        public string NameOfCategory { get; set; }

    }
}
