namespace ToDoList.BLL.Models
{
    public class UserModel
    {
        #region Properties
        public int? Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }

        #endregion
    }
}
