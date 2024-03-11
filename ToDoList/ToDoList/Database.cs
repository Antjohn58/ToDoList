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
        public Task<int> SaveStudentAsync(List list)
        {
            return _connection.InsertAsync(list);
        }
        public Task<int> DeleteListAsync(List list)
        {
            return _connection.DeleteAsync(list);
        }
    }
}
