using Practices.Models;

namespace Practices.Business;

public interface IUserService
{
    public User RegisterUser(UserCreateUpdateDTO UserCreateUpdateDTO);
    public IEnumerable<User> GetAllUsers();
    public User GetUserById(int userId);
    public User GetUserByEmail(string userEmail);
    public void UpdateUser(int userId, UserCreateUpdateDTO UserCreateUpdateDTO);
    public void DeleteUser(int userId);
}
