using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList
{
    internal class List
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Item { get; set; }
        public bool IsComplete { get; set; }
    }
}
