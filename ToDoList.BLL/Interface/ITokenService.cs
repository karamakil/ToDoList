using ToDoList.BLL.DAL;

namespace ToDoList.BLL.Interface
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
