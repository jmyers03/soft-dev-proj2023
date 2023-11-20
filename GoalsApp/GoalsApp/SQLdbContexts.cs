using GoalsApp.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalsApp
{
    public class SQLdbContexts
    {
        public const string DatabaseFilename = "DreamCatcherSQLite.db3";
        static string DatabasePath = Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);

        public const SQLite.SQLiteOpenFlags Flags =
            SQLite.SQLiteOpenFlags.ReadWrite |
            SQLite.SQLiteOpenFlags.Create |
            SQLite.SQLiteOpenFlags.SharedCache;

        SQLiteAsyncConnection Database;

        async Task Init()
        {
            if (Database is not null)
            {
                return;
            }
            var result = await Database.CreateTableAsync<UserClass>();

        }

        public async Task<List<UserClass>> GetAllProducts()
        {
            await Init();
            return await Database.Table<UserClass>().ToListAsync();
        }

        public async Task<UserClass> GetUserAsync(int UserId)
        {
            await Init();
            return await Database.Table<UserClass>().Where(p=>p.Id == UserId).FirstOrDefaultAsync();
        }
        public async Task<int> AddUserAsync(UserClass user)  
        {
            await Init();
            if (user.Id != 0) 
            {
                return await Database.UpdateAsync(user);
            }
            else
            {
                return await Database.UpdateAsync(user);
            }
        }
    }
}