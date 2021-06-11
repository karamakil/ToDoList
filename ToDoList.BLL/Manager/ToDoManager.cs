using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.BLL.DAL;

namespace ToDoList.BLL.Manager
{
    public class ToDoManager
    {
        #region Static Methods
        public static List<ToDo> GetList()
        {
            return new ToDo().GetList();
        }

        public static ToDo GetById(int id)
        {
            return new ToDo().Find(id);
        }

        public static void Save(ToDo toDO)
        {
            if (toDO.Id > 0)
            {
                toDO.Update();
            }
            else
            {
                toDO.CreationDate = DateTime.Now;
                toDO.Insert();
            }
        }

        public static void Delete(int id)
        {
            var toDo = GetById(id);
            if (toDo != null)
            {
                toDo.Delete();
            }
        }

        #endregion
    }
}
