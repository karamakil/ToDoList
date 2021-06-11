using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.BLL.Interface;

namespace ToDoList.BLL.DAL
{
    public partial class User : IDbObject<User>
    {

        #region Public Methods

        public User Find(string userName, string password)
        {
            using (var ctx = new ToDoListContext())
            {
                return ctx.Users.FirstOrDefault(x => x.UserName == userName && x.Password == password);
            }
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }


        public List<User> GetList()
        {
            throw new NotImplementedException();
        }

        public void Insert()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public User Find(int id)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
