using MentalHealthApp.Models;
using SQLite;
using SQLiteNetExtensionsAsync.Extensions;
using SQLitePCL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MentalHealthApp
{
    public class MentalHealthAppDB
    {
        private readonly SQLiteAsyncConnection _connection;
        public SQLiteAsyncConnection Connection { get => _connection; }

        public MentalHealthAppDB(string databasePath)
        {
            _connection = new SQLiteAsyncConnection(databasePath);
            //_connection.DropTableAsync<ForReadingModel>().Wait();
            //_connection.DropTableAsync<CalendarModel>().Wait();
            //_connection.DropTableAsync<FeelingToCalendar>().Wait();
            _connection.CreateTablesAsync<ForReadingModel, ReadingToCalendar, CalendarModel, TaskModel>().Wait();
            _connection.CreateTablesAsync<MeditationModel, BreatheModel, MeditationToCalendar, BreatheToCalendar>().Wait();
            _connection.CreateTablesAsync<FeelingModel, SleepModel, SleepFactorsModel, SleepToSleepFactors>().Wait();
            //_connection.DropTableAsync<CategoryModel>().Wait();
            //_connection.DropTableAsync<ThemeModel>().Wait();
            _connection.CreateTablesAsync<PosThModel, ThemeModel, CategoryModel, FeelingToCalendar>().Wait();
            //AddItems();
            //UpdateItems();
        }

        private async void AddItems()
        {
            var cats = await GetListOfCats();

            string content = "\tОтношения с руководством — дело непростое. Очень важно уметь сохранять баланс между качественным выполнением своих задач, не забывая при этом про грамотное общение с начальником. Раскрываем секреты коммуникации и уберегаем от ошибок, которые могут поставить крест на вашей карьере.\r\nНачальник — как много скрыто в этом слове. Многие из нас на дрожащих ногах заходят в кабинет своего руководителя, даже просто, чтобы поздороваться, не говоря уже о более глобальных целях. Нам кажется, что он строг и всесилен, а потому лишний раз стараемся не попадаться ему на глаза. Конечно, такая история далеко не у каждого, ведь у некоторых глава команды, напротив, старается общаться на равных, а порой и вовсе предпочитает неформальный язык. Тем не менее в обоих случаях очень важно уметь сохранять границы и все-таки принимать тот факт, что перед вами человек высшего ранга, а потому с ним важно соблюдать особые правила коммуникации.\r\nЕсли вы не хотите поставить крест на своем карьером росте и лишиться работы, стоит раз и навсегда забыть о следующих поступках.\r\nОтказ от выполнения поставленных задач повлечет за собой не только негативные последствия для компании, но и резкое снижение авторитета работника в глазах руководителя. Если вы выражаете свое несогласие и полную невозможность сделать то или иное дело, постарайтесь как можно более подробно это аргументировать и в обязательном порядке предложить что-то взамен. Помните, что ни один уважающий себя начальник не будет держать в своей команде того, кто не умеет качественно выполнять свои обязанности.\r\nФразы «Я не знаю», «Это не моя ответственность, не моя вина», «Мне за это не платят», «Это от меня не зависит» сразу вешают ярлык некомпетентности и выставляют вас далеко не в лучшем свете. В глазах окружающих вы будете выглядеть безынициативным, ненадежным и слабым работником, который не готов расти профессионально и брать ответственность за свои поступки. Руководителю крайне важно, чтобы вы приносили высокие результаты и демонстрировали эффективность своей работы, а в противном случае, вам просто найдут более качественную замену, при чем в самые короткие сроки.\r\nПовышенный тон, грубые выражения и полное несоблюдение субординации до добра не доведут (даже, если руководитель предпочитает неформальность и ставит себя в относительно равное с вами положение). Это говорит не столько о вас, как о работнике, сколько о человеке как таковом. Если руководство отметит, что вы не умеет выстраивать деловую коммуникацию (это самых важный профессиональный навык), то значит вам нельзя доверить общение с клиентами и партнерами, а потому заинтересованность в том, чтобы продолжать с вами сотрудничество, попросту сойдет на нет.\r\nЗабудьте о лжи и любом скрытие проблем в рабочих вопросах. В данном случае даже единичный случай утаивания и обмана может стоит компании огромных финансовых и репутационных потерь, а вам неминуемое увольнение. Важно уметь открыто заявлять о всех неполадках и просить помощи в их устранении, если это не получается сделать самостоятельно.\r\nОсуждать решения руководства не приветствуется ни наедине с ним, ни среди коллег. Вы можете сообщить, что вас что-то не устраивает, но чтобы тайком критиковать — нет, исключено! Начальники никогда не стремятся бороться с подчиненными за право принятия решений, а потому любое несогласие воспринимается им как неуважение к его личности и поступкам.\r\nПомните, что главное — это спокойствие, размеренность и твердый ум. Научитесь открыто и деликатно сообщать своему руководству о том, что вы с чем-то несогласны или какая-то задача кажется вам не по силам. Не бойтесь просить помощи и искать альтернативные, более уместные и тактичные фразы.\r\nНапример, вместо «Я не знаю» нужно сказать «Сейчас я не готов ответить на этот вопрос, но я разберусь и дополнительно вам сообщу».\r\nЗамените отрицание «Это не моя ответственность, не моя вина» на утверждение «Я сделал выводы из данной ситуации и впредь приложу все усилия, чтобы она не повторилась».\r\nПерестаньте акцентировать внимание на плате и вместо категоричного «Мне за это не платят», лучше намекните: «Так как это задание является существенной дополнительной нагрузкой к моему основному функционалу, я смогу выполнить его в определенные сроки. Но хочу обсудить возможность дополнительного вознаграждения в случае его успешного выполнения».\r\nИ не забывайте обосновывать свои отказы. Как вариант, вместо «Это от меня не зависит» используйте «Со своей стороны я приложу все усилия, но следует учитывать следующие факторы…»\r\nБудьте открытыми и честными. Помните, что начальник — это такой же обычный человек, который может войти в положение и даже помочь, если заранее информировать его о проблемах и попросить консультацию.\r\nПри несогласии с решением руководителя деликатно намекните ему об этом. Не забудьте аргументировать свою точку зрения и предлагать иные варианты.\r\nНаучитесь принимать критику. Она поможет вам расти и развиваться, ведь как ни крути, но ваш начальник опытнее вас, а значит наверняка знает как будет лучше.\r\nОтноситесь к нему уважительно и не повышайте голос. Избегайте обвинений в его адрес и не бойтесь задавать вопросы, но только после того, как он окончательно закончит свою речь.\r\nПомните, что компании всегда дорожат грамотными сотрудниками. Профессионалы ценились во все времена, а дипломатичные и тактичные вдвойне.\r\nКрайне важно быстро реагировать на запросы руководителя и уметь их качественно выполнять. Самодисциплина и уверенность в своих действиях никогда не пройдут незамеченными для глаз руководства. Умение выстраивать деловую коммуникацию и долгосрочные отношения с коллегами, клиентами и партнерами, обеспечивает хорошие отношения и с начальством.\r\nНе останавливайтесь на достигнутом и стремитесь всегда расширять свои личные и профессиональные навыки.\r\nНе забывайте о границах и учитесь адекватно оценивать результаты своей работы. Находя «плюсы» и «минусы» гораздо проще выстраивать дальнейшие траектории.\r\nНикогда не обсуждайте личную жизнь руководителя и уж тем более не распространяйте секреты или сплетни. Рано или поздно это станет известно всем, а значит вы неминуемо упадете в глазах окружающих. Кроме того, коллеги также могут начать относиться к вам человеку с недоверием — перестать делиться рабочей и личной информацией, опасаясь тоже стать объектами обсуждений.\r\nПомните, что за вами все фиксируется, а потому для дальнейший карьеры важно зарекомендовать себя в стенах одной компании, чтобы затем переместиться в другую. Все-таки силу характеристики с предыдущего места работы никто не отменял.\r\n";

            ForReadingModel work1 = new ForReadingModel()
            {
                ReadingDuration = 15,
                isFavourite = 0,
                ImagePath = "boss_reading.jpg",
                ReadingName = "Отношения с начальником",
                Sections = "Что не нужно делать\r\nКак себя правильно вести\r\nКак наладить отношения с начальником\r\nКак стать ценным сотрудником\r\n",
                Content = content.Replace("\r\n", "\n\t"),
                CurrentCategory = cats[0]
            };

            ForReadingModel work2 = new ForReadingModel();
            work2.ReadingDuration = 10;
            work2.isFavourite = 0;
            work2.ImagePath = "colleagues_reading.jpg";
            work2.ReadingName = "Отношения с коллегами";
            work2.CurrentCategory = cats[0];
            work2.Sections = "";
            work2.Content = "";

            ForReadingModel work3 = new ForReadingModel();
            work3.ReadingDuration = 10;
            work3.isFavourite = 0;
            work3.ImagePath = "firstdaywork_reading.jpg";
            work3.ReadingName = "Первый рабочий день";
            work3.CurrentCategory = cats[0];
            work3.Sections = "";
            work3.Content = "";

            ForReadingModel work4 = new ForReadingModel()
            {
                ReadingDuration = 10,
                isFavourite = 0,
                ImagePath = "efficiency_reading.jpg",
                ReadingName = "Производительность",
                CurrentCategory = cats[0],
                Sections = "",
                Content = ""
            };

            ForReadingModel study1 = new ForReadingModel()
            {
                ReadingDuration = 10,
                isFavourite = 0,
                ImagePath = "teacher_reading.jpg",
                ReadingName = "Отношения с учителем",
                CurrentCategory = cats[1],
                Sections = "",
                Content = ""
            };
            ForReadingModel study2 = new ForReadingModel()
            {
                ReadingDuration = 10,
                isFavourite = 0,
                ImagePath = "schoolfriends_reading.jpg",
                ReadingName = "Отношения с товарищами",
                CurrentCategory = cats[1],
                Sections = "",
                Content = ""
            };
            ForReadingModel study3 = new ForReadingModel()
            {
                ReadingDuration = 10,
                isFavourite = 0,
                ImagePath = "student_reading.jpg",
                ReadingName = "Первый учебный день",
                CurrentCategory = cats[1],
                Sections = "",
                Content = ""
            };
            ForReadingModel study4 = new ForReadingModel()
            {
                ReadingDuration = 10,
                isFavourite = 0,
                ImagePath = "schoolprogress_reading.jpg",
                ReadingName = "Успеваемость",
                CurrentCategory = cats[1],
                Sections = "",
                Content = ""
            };

            ForReadingModel health1 = new ForReadingModel()
            {
                ReadingDuration = 10,
                isFavourite = 0,
                ImagePath = "anxiety_reading.jpg",
                ReadingName = "Тревожное состояние",
                CurrentCategory = cats[2],
                Sections = "",
                Content = ""
            };
            ForReadingModel health2 = new ForReadingModel()
            {
                ReadingDuration = 10,
                isFavourite = 0,
                ImagePath = "selfheallth_reading.jpg",
                ReadingName = "Личная гигиена",
                CurrentCategory = cats[2],
                Sections = "",
                Content = ""

            };
            ForReadingModel health3 = new ForReadingModel()
            {
                ReadingDuration = 10,
                isFavourite = 0,
                ImagePath = "hls_reading.jpg",
                ReadingName = "Здоровый образ жизни",
                CurrentCategory = cats[2],
                Sections = "",
                Content = ""
            };
            ForReadingModel health4 = new ForReadingModel()
            {
                ReadingDuration = 10,
                isFavourite = 0,
                ImagePath = "oldage_reading.jpg",
                ReadingName = "Мысли о старости",
                CurrentCategory = cats[2],
                Sections = "",
                Content = ""
            };

            ForReadingModel life1 = new ForReadingModel()
            {
                ReadingDuration = 10,
                isFavourite = 0,
                ImagePath = "family_reading.jpg",
                ReadingName = "Отношения с семьей",
                CurrentCategory = cats[3],
                Sections = "",
                Content = ""
            };
            ForReadingModel life2 = new ForReadingModel()
            {
                ReadingDuration = 10,
                isFavourite = 0,
                ImagePath = "lifetodo_reading.jpg",
                ReadingName = "Личные обязанности",
                CurrentCategory = cats[3],
                Sections = "",
                Content = ""

            };
            ForReadingModel life3 = new ForReadingModel()
            {
                ReadingDuration = 10,
                isFavourite = 0,
                ImagePath = "pets_reading.jpg",
                ReadingName = "Домашние животные",
                CurrentCategory = cats[3],
                Sections = "",
                Content = ""
            };
            ForReadingModel life4 = new ForReadingModel()
            {
                ReadingDuration = 10,
                isFavourite = 0,
                ImagePath = "child_reading.jpg",
                ReadingName = "Внимание ребенку",
                CurrentCategory = cats[3],
                Sections = "",
                Content = ""
            };

            List<ForReadingModel> list = new() { work1, work2, work3, work4, study1, study2, study3, study4, life1, life2, life3, life4, health1, health2, health3, health4 };
            await _connection.InsertAllWithChildrenAsync(list);
        }
        private async void UpdateItems()
        {

            ThemeModel theme = await _connection.GetWithChildrenAsync<ThemeModel>(1);
            List<PosThModel> listOfThinks =
                [
                new() {isFavourite = 0, NegativeThink = "Начальник не замечает мои достижения и обесценивает мой труд",
                    PositiveThink = "Возможно, начальник просто не осведомлён о моих результатах — мне стоит научиться быть более заметным"},
                new() {isFavourite = 0, NegativeThink = "Начальник придирается ко мне и требует больше, чем от других сотрудников",
                    PositiveThink = "Вероятно, начальник видит во мне потенциал и потому предъявляет более высокие требования — это шанс расти профессионально"},
                new() {isFavourite = 0, NegativeThink = "Начальник предвзято относится ко мне",
                    PositiveThink = "Может быть, я интерпретирую ситуацию слишком лично. Стоит попробовать открыто обсудить рабочие моменты и уточнить ожидания, чтобы прояснить недопонимания"},
                new() {isFavourite = 0, NegativeThink = "Начальник игнорирует мои просьбы и предложения",
                    PositiveThink = "Возможно, мои идеи требуют более чёткого обоснования или подачи в нужное время"},
                new() {isFavourite = 0, NegativeThink = "Начальник намеренно не хочет повышать меня и давать новые проекты",
                    PositiveThink = "Вероятно, сейчас не лучшее время для повышения по объективным причинам. Я могу уточнить, что нужно улучшить, чтобы перейти на следующий уровень, и показать свою готовность к новым задачам"},
                new() {isFavourite = 0, NegativeThink = "Начальник не хочет повышать мне зарплату",
                    PositiveThink = "Возможно дело в обстоятельствах, не зависящих от моего начальника - мне стоит спросить его об этом напрямую"},
                ];
            theme.Thinks = listOfThinks;

            await _connection.InsertOrReplaceWithChildrenAsync(theme, true);
        }

        /// <summary>
        /// Получение списка категорий
        /// </summary>
        /// <returns></returns>
        public async Task<List<CategoryModel>> GetListOfCats()
        {

            return await _connection.GetAllWithChildrenAsync<CategoryModel>();
        }

        /// <summary>
        /// Получение списка информации для чтения
        /// </summary>
        /// <returns></returns>
        public async Task<CategoryModel> GetListOfReading(int id)
        {
            return await _connection.GetWithChildrenAsync<CategoryModel>(id);
        }

        /// <summary>
        /// Получение списка дыхательных техник
        /// </summary>
        /// <returns></returns>
        public async Task<List<BreatheModel>> GetListOfBreathes()
        {
            return await _connection.Table<BreatheModel>().ToListAsync();
        }

        /// <summary>
        /// Получение списка медитаций
        /// </summary>
        /// <returns></returns>
        public async Task<List<MeditationModel>> GetListOfMeditations()
        {
            return await _connection.Table<MeditationModel>().ToListAsync();
        }

        /// <summary>
        /// Получение списка позитивного мышления
        /// </summary>
        /// <returns></returns>
        public async Task<CategoryModel> GetListOfSubTopics(int id)
        {
            return await _connection.GetWithChildrenAsync<CategoryModel>(id);
        }

        /// <summary>
        /// Получение негативных и позитвных мыслей
        /// </summary>
        /// <returns></returns>
        public async Task<ThemeModel> GetListOfThinks(string str)
        {
            var themeName = await _connection.Table<ThemeModel>().Where(x => x.ThemeName == str).FirstOrDefaultAsync();
            return await _connection.GetWithChildrenAsync<ThemeModel>(themeName.ThemeID);
        }

        /// <summary>
        /// Получение списка эмоций
        /// </summary>
        /// <returns></returns>
        public async Task<List<FeelingModel>> GetListOfFeelings()
        {
            return await _connection.Table<FeelingModel>().ToListAsync();
        }

        /// <summary>
        /// Запись отмеченного самочувствия в БД
        /// </summary>
        /// <param name="textDate"></param>
        /// <param name="textTime"></param>
        /// <param name="feelingMark"></param>
        /// <param name="descr"></param>
        /// <returns></returns>
        public async Task<FeelingToCalendar> WriteFeelingsToDB(string textDate, string textTime, int feelingMark, string descr)
        {
            var currentDate = await _connection.Table<CalendarModel>().Where(x => x.FullDate == textDate).FirstOrDefaultAsync();

            var feeling = await _connection.Table<FeelingModel>().Where(x => x.FeelingID == feelingMark).FirstOrDefaultAsync();
            CalendarModel fullDay;

            if (currentDate != null)
            {
                fullDay = await _connection.GetWithChildrenAsync<CalendarModel>(currentDate.DayID);
                if (fullDay.Feelings != null)
                    fullDay.Feelings.Add(feeling);
                else
                    fullDay.Feelings = new List<FeelingModel>() { feeling };
                await _connection.UpdateWithChildrenAsync(fullDay);
            }
            else
            {
                await _connection.InsertAsync(new CalendarModel() { FullDate = textDate });
                currentDate = await _connection.Table<CalendarModel>().Where(x => x.FullDate == textDate).FirstOrDefaultAsync();
                fullDay = await _connection.GetWithChildrenAsync<CalendarModel>(currentDate.DayID);
                fullDay.Feelings = new List<FeelingModel>() { feeling };
                await _connection.UpdateWithChildrenAsync(fullDay);
            }

            var feelsToCalendar = await _connection.Table<FeelingToCalendar>().Where(x => x.DayID == fullDay.DayID).ToListAsync();
            var lastFeel = feelsToCalendar.Last();
            var additionalInfo = await _connection.GetWithChildrenAsync<FeelingToCalendar>(lastFeel.RelationID);
            additionalInfo.Time = textTime;
            if (descr != null)
                additionalInfo.Description = descr;
            await _connection.InsertWithChildrenAsync(additionalInfo);
            return additionalInfo;
        }
        /// <summary>
        /// Получение списка факторов сна
        /// </summary>
        /// <returns></returns>
        public async Task<List<SleepFactorsModel>> GetListOfFactors()
        {
            return await _connection.Table<SleepFactorsModel>().ToListAsync();
        }

        /// <summary>
        /// Запись отмеченного сна в БД
        /// </summary>
        /// <param name="todaySleep"></param>
        /// <returns></returns>
        public async Task<CalendarModel> WriteSleepToDB(SleepModel todaySleep)
        {
            DateTime dateTimeNow = new DateTime();
            dateTimeNow = DateTime.UtcNow + TimeZoneInfo.Local.BaseUtcOffset;
            string currentDate = dateTimeNow.ToString("dd/MM/yyyy");

            var date = await _connection.Table<CalendarModel>().Where(x => x.FullDate == currentDate).FirstOrDefaultAsync();
            if (date != null)
            {
                todaySleep.CalendarDay = date;
                await _connection.InsertWithChildrenAsync(todaySleep);
            }
            else
            {
                await _connection.InsertAsync(new CalendarModel() { FullDate = currentDate });
                date = await _connection.Table<CalendarModel>().Where(x => x.FullDate == currentDate).FirstOrDefaultAsync();
                todaySleep.CalendarDay = date;
                await _connection.InsertWithChildrenAsync(todaySleep);
            }
            var newDate = await _connection.GetWithChildrenAsync<CalendarModel>(date.DayID);
            return newDate;
        }

        public async Task<CalendarModel> GetCurrentDay(string[] date)
        {
            string formatedDate = date[0] + "/" + date[1] + "/" + date[2];
            var todayDate = await _connection.Table<CalendarModel>().Where(x => x.FullDate == formatedDate).FirstOrDefaultAsync();
            if (todayDate != null)
            {
                var todayDateWithChildren = await _connection.GetWithChildrenAsync<CalendarModel>(todayDate.DayID);
                return todayDateWithChildren;
            }
            else
            {
                await _connection.InsertAsync(new CalendarModel() { FullDate = formatedDate });
                todayDate = await _connection.Table<CalendarModel>().Where(x => x.FullDate == formatedDate).FirstOrDefaultAsync();
                var todayDateWithChildren = await _connection.GetWithChildrenAsync<CalendarModel>(todayDate.DayID);
                return todayDate;
            }
                
        }
    }
}
