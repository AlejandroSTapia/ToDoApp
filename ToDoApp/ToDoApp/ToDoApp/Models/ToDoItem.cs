﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Models
{
    class ToDoItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
