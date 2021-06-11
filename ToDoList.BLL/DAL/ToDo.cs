using System;
using System.Collections.Generic;

#nullable disable

namespace ToDoList.BLL.DAL
{
    public partial class ToDo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool? IdDone { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
