using MentalHealthApp.Models;
using SQLite;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentalHealthApp
{
    public class MentalHealthAppDB
    {
        private readonly SQLiteAsyncConnection _connection;
        public  SQLiteAsyncConnection Connection { get => _connection; }

        public MentalHealthAppDB(string databasePath)
        {
            _connection = new SQLiteAsyncConnection(databasePath);
            _connection.CreateTablesAsync<CategoryModel, MeditationListModel, BreatheListModel, ForReadingModel>().Wait();
            _connection.CreateTablesAsync<FeelingModel, SleepModel, PlannerTaskModel, CalendarModel>().Wait();
            _connection.DropTableAsync<PosThModel>().Wait();
            _connection.CreateTablesAsync<PosThModel,PosThCardsModel>().Wait();
            AddItems();
            UpdateItems();
        }

        private async void AddItems()
        {

        }
        private async void UpdateItems()
        {
            
            //List<PosThCardsModel> tempModels =
            //    [
            //    await Connection.Table<PosThCardsModel>().Where(x => x.ThemeName == "Отношения с начальником").FirstOrDefaultAsync(),
            //    await Connection.Table<PosThCardsModel>().Where(x => x.ThemeName == "Отношения с коллегами").FirstOrDefaultAsync(),
            //    await Connection.Table<PosThCardsModel>().Where(x => x.ThemeName == "Первый рабочий день").FirstOrDefaultAsync(),
            //    await Connection.Table<PosThCardsModel>().Where(x => x.ThemeName == "Производительность").FirstOrDefaultAsync(),
            //    await Connection.Table<PosThCardsModel>().Where(x => x.ThemeName == "Отношения с учителем").FirstOrDefaultAsync(),
            //    await Connection.Table<PosThCardsModel>().Where(x => x.ThemeName == "Отношения с товарищами").FirstOrDefaultAsync(),
            //    await Connection.Table<PosThCardsModel>().Where(x => x.ThemeName == "Первый учебный день").FirstOrDefaultAsync(),
            //    await Connection.Table<PosThCardsModel>().Where(x => x.ThemeName == "Успеваемость").FirstOrDefaultAsync(),
            //    await Connection.Table<PosThCardsModel>().Where(x => x.ThemeName == "Тревожное состояние").FirstOrDefaultAsync(),
            //    await Connection.Table<PosThCardsModel>().Where(x => x.ThemeName == "Личная гигиена").FirstOrDefaultAsync(),
            //    await Connection.Table<PosThCardsModel>().Where(x => x.ThemeName == "Здоровый образ жизни").FirstOrDefaultAsync(),
            //    await Connection.Table<PosThCardsModel>().Where(x => x.ThemeName == "Мысли о старости").FirstOrDefaultAsync(),
            //    await Connection.Table<PosThCardsModel>().Where(x => x.ThemeName == "Отношения с семьей").FirstOrDefaultAsync(),
            //    await Connection.Table<PosThCardsModel>().Where(x => x.ThemeName == "Личные обязанности").FirstOrDefaultAsync(),
            //    await Connection.Table<PosThCardsModel>().Where(x => x.ThemeName == "Домашние животные").FirstOrDefaultAsync(),
            //    await Connection.Table<PosThCardsModel>().Where(x => x.ThemeName == "Внимание ребенку").FirstOrDefaultAsync(),
            //];
            //foreach (var items in tempModels)
            //{
            //    items.CountOfCards = 6;
            //    await Connection.UpdateAsync(items);
            //}

        }

        /// <summary>
        /// Получение списка категорий
        /// </summary>
        /// <returns></returns>
        public async Task<List<CategoryModel>> GetListOfCats()
        {

            return await _connection.Table<CategoryModel>().ToListAsync();
        }

        /// <summary>
        /// Получение списка информации для чтения
        /// </summary>
        /// <returns></returns>
        public async Task<List<ForReadingModel>> GetListOfReading(int id)
        {
            return await _connection.Table<ForReadingModel>().Where(x=>x.CategoryID==id).ToListAsync();
        }

        /// <summary>
        /// Получение списка дыхательных техник
        /// </summary>
        /// <returns></returns>
        public async Task<List<BreatheListModel>> GetListOfBreathes()
        {
            return await _connection.Table<BreatheListModel>().ToListAsync();
        }

        /// <summary>
        /// Получение списка медитаций
        /// </summary>
        /// <returns></returns>
        public async Task<List<MeditationListModel>> GetListOfMeditations()
        {
            return await _connection.Table<MeditationListModel>().ToListAsync();
        }

        /// <summary>
        /// Получение списка позитивного мышления
        /// </summary>
        /// <returns></returns>
        public async Task<List<PosThCardsModel>> GetListOfSubTopics(int id)
        {
            return await _connection.Table<PosThCardsModel>().Where(x => x.CategoryID == id).ToListAsync();
        }

        /// <summary>
        /// Получение негативных и позитвных мыслей
        /// </summary>
        /// <returns></returns>
        public async Task<List<PosThModel>> GetListOfThinks(string str)
        {
            return await _connection.Table<PosThModel>().Where(x=>x.Theme==str).ToListAsync();
        }
    }
}
