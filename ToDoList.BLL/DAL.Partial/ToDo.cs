using System.Collections.Generic;
using System.Linq;
using ToDoList.BLL.Interface;

namespace ToDoList.BLL.DAL
{
    public partial class ToDo : IDbObject<ToDo>
    {

        #region Public Methods
        public List<ToDo> GetList()
        {
            using (var ctx = new ToDoListContext())
            {
                return ctx.ToDos.ToList();
            }
        }

        public void Delete()
        {
            using (var ctx = new ToDoListContext())
            {
                ctx.ToDos.Attach(this);
                ctx.ToDos.Remove(this);
                ctx.SaveChanges();
            }
        }

        public ToDo Find(int id)
        {
            using (var ctx = new ToDoListContext())
            {
                return ctx.ToDos.FirstOrDefault(x => x.Id == id);
            }
        }

        public void Insert()
        {
            using (var ctx = new ToDoListContext())
            {
                ctx.ToDos.Add(this);
                ctx.SaveChanges();
            }
        }

        public void Update()
        {
            using (var ctx = new ToDoListContext())
            {
                ctx.Entry(this).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                ctx.Entry(this).Property(x => x.CreationDate).IsModified = false;
                ctx.SaveChanges();
            }
        }

        #endregion
    }
}
