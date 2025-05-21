using MentalHealthApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentalHealthApp
{
    public class MentalHealthAppDB
    {
        private const string DB_NAME = "MentalHealthApp.db";
        private readonly SQLiteAsyncConnection _connection;
        public  SQLiteAsyncConnection Connection { get => _connection; }

        public MentalHealthAppDB()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));
        }

        public async Task<List<CategoryModel>> GetListOfCats()
        {
            return await _connection.Table<CategoryModel>().ToListAsync();
        }
        public async Task<List<ForReadingModel>> GetListOfReading(int id)
        {
            return await _connection.Table<ForReadingModel>().Where(x=>x.CategoryID==id).ToListAsync();
        }
    }
}
