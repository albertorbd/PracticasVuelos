using Practices.Models;

namespace Practices.Data;

public interface IUserRepository
{
    public void AddUser(User user);
    public User GetUser(int userId);
    public IEnumerable<User> GetAllUsers();
    public void DeleteUser(int userId);
    public void UpdateUser(User user);
    void SaveChanges();
    /*public void AddBooking(Booking booking);*/
}
