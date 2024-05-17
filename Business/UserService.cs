using Practices.Data;
using Practices.Models;

namespace Practices.Business;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public User RegisterUser(UserCreateUpdateDTO userCreateUpdateDTO)
    {
        User user = new(userCreateUpdateDTO.Name, userCreateUpdateDTO.Email, userCreateUpdateDTO.Password, userCreateUpdateDTO.Phone, userCreateUpdateDTO.DNI);
        _userRepository.AddUser(user);
        return user;
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _userRepository.GetAllUsers();
    }

    public User GetUserById(int userId)
    {
        var user = _userRepository.GetUser(userId);
        if (user == null)
        {
            throw new KeyNotFoundException($"Usuario con ID {userId} no encontrado");
        }
        return user;
    }
    
    public void UpdateUser(int userId, UserCreateUpdateDTO userCreateUpdateDTO)
    {
        var user = _userRepository.GetUser(userId);
        if (user == null)
        {
            throw new KeyNotFoundException($"Usuario con ID {userId} no encontrado");
        }
        user.Name = userCreateUpdateDTO.Name;
        user.Email = userCreateUpdateDTO.Email;
        user.Password = userCreateUpdateDTO.Password;
        user.Phone = userCreateUpdateDTO.Phone;
        user.DNI = userCreateUpdateDTO.DNI;
        _userRepository.UpdateUser(user);
    }

    public void DeleteUser(int userId)
    {
        var user = _userRepository.GetUser(userId);
        if (user == null)
        {
            throw new KeyNotFoundException($"Usuario con ID {userId} no encontrado");
        }
        _userRepository.DeleteUser(userId);
    }
    
}