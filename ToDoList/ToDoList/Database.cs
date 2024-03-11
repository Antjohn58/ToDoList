using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;

namespace ToDoList
{
    internal class Database
    {
        private readonly SQLiteAsyncConnection _connection;
        public Database(String dbpath)
        {
            _connection = new SQLiteAsyncConnection(dbpath);
            _connection.CreateTableAsync<List>();
        }
        public Task<List<List>> GetListsAsync()
        {
            return _connection.Table<List>().ToListAsync();
        }
        public Task<int> SaveListAsync(List list)
        {
            if (list.Id != 0)
            {
                return _connection.UpdateAsync(list); 
            }
            else
            {
                return _connection.InsertAsync(list); 
            }
        }
    }
}
