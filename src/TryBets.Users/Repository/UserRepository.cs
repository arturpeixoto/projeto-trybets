using TryBets.Users.Models;
using TryBets.Users.DTO;

namespace TryBets.Users.Repository;

public class UserRepository : IUserRepository
{
    protected readonly ITryBetsContext _context;
    public UserRepository(ITryBetsContext context)
    {
        _context = context;
    }

    public User Post(User user)
    {
        bool userExist = _context.Users.Any(x => x.Email == user.Email);
        if (userExist)
        {
            throw new Exception("E-mail already used");
        }

        User newUser = new()
        {
            Name = user.Name,
            Email = user.Email,
            Password = user.Password,
        };

        _context.Users.Add(newUser);
        _context.SaveChanges();
        return user;
    }

    public User Login(AuthDTORequest login)
    {
        var userExist = _context.Users.FirstOrDefault(x => x.Email == login.Email && x.Password == login.Password);
        if (userExist == null)
        {
            throw new Exception("Authentication failed");
        }
        else
        {
            return userExist;
        }
    }
}