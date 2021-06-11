using ToDoList.BLL.DAL;

namespace ToDoList.BLL.Manager
{
    public class UserManager
    {
        #region Static Methods

        public static User Find(string userName, string password)
        {
            return new User().Find(userName, password);
        }

        #endregion
    }
}
