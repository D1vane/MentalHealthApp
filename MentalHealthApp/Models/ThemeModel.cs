using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentalHealthApp.Models
{
    [Table("Тема")]
    public class ThemeModel
    {
        [Column("IDТемы"), PrimaryKey, AutoIncrement]
        public int ThemeID { get; set; }

        [Column("IDКатегории"), ForeignKey(typeof(CategoryModel))]
        public int CategoryID { get; set; }

        [Column("Наименование")]
        public string ThemeName { get; set; }

        [Column("Изображение")]
        public string ImagePath { get; set; }

        [ManyToOne]
        public CategoryModel CurrentCategory { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<PosThModel> Thinks { get; set; }

    }
}
