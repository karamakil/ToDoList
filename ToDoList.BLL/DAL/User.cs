﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList.BLL.DAL
{
    public partial class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
