using System.Collections.Generic;

namespace ToDoList.BLL.Interface
{
    public interface IDbObject<T>
    {
        void Insert();
        List<T> GetList();
        T Find(int id);
        void Update();
        void Delete();
    }
}
