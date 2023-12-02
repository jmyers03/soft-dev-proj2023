//using GoalsApp.Models;
//using SQLite;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace GoalsApp
//{
//    public class SQLdbContexts6
//    {
//        public const string DatabaseFilename = "DreamCatcherSQLite.db3";
//        static string DatabasePath = Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);

//        public const SQLite.SQLiteOpenFlags Flags =
//            SQLite.SQLiteOpenFlags.ReadWrite |
//            SQLite.SQLiteOpenFlags.Create |
//            SQLite.SQLiteOpenFlags.SharedCache;

//        SQLiteAsyncConnection Database;

//        async Task Init()
//        {
//            if (Database is not null)
//            {
//                return;
//            }
//            var result = await Database.CreateTableAsync<User>();

//        }

//        public async Task<List<User>> GetAllProducts()
//        {
//            await Init();
//            return await Database.Table<User>().ToListAsync();
//        }

//        public async Task<User> GetUserAsync(int UserId)
//        {
//            await Init();
//            return await Database.Table<User>().Where(p=>p.Id == UserId).FirstOrDefaultAsync();
//        }
//        public async Task<int> AddUserAsync(User user)  
//        {
//            await Init();
//            if (user.Id != 0) 
//            {
//                return await Database.UpdateAsync(user);
//            }
//            else
//            {
//                return await Database.UpdateAsync(user);
//            }
//        }
//    }
//}