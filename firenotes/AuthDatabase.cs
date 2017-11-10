using System.Threading.Tasks;
using firenotes.Models;
using SQLite;

namespace firenotes
{
    public class AuthDatabase
    {
        static SQLiteAsyncConnection connection;

        public AuthDatabase(string dbPath)
        {
            connection = new SQLiteAsyncConnection(dbPath);
            connection.CreateTableAsync<User>().Wait();
        }

        public Task<User> GeUserAsync()
        {
            return connection.Table<User>().FirstOrDefaultAsync();
        }

        public Task<int> SaveUserAsync(User user)
        {
            if (user.ID != 0)
            {
                return connection.UpdateAsync(user);
            }
            return connection.InsertAsync(user);
        }

        public Task<int> DeleteUserAsync(User user)
        {
            return connection.DeleteAsync(user);
        }
    }
}
