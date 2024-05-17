using Microsoft.AspNetCore.Mvc;
using Practices.Business;
using Practices.Models;
using Microsoft.AspNetCore.Authorization;

namespace Practices.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;
    private readonly IUserService _userService;

    public UsersController(ILogger<UsersController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<User>> GetAllUsers()
    {
        try 
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }     
        catch (Exception ex)
        {
            _logger.LogError($"Error al obtener todos los usuarios. {ex.Message}");
            return BadRequest($"Error al obtener todos los usuarios. {ex.Message}");
        }
    }

    [HttpGet("{userEmail}")]
    public IActionResult GetUser(string userEmail)
    {
        try
        {
            var user = _userService.GetUserByEmail(userEmail);
            return Ok(user);
        }
        catch (KeyNotFoundException knfex)
        {
            _logger.LogWarning($"No se ha encontrado el usuario con email: {userEmail}. {knfex.Message}");
           return NotFound($"No se ha encontrado el usuario con email: {userEmail}. {knfex.Message}");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al obtener el usuario con email: {userEmail}. {ex.Message}");
            return BadRequest($"Error al obtener el usuario con email: {userEmail}. {ex.Message}");
        }
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] UserCreateUpdateDTO userCreateUpdateDTO)
    {
        if (!ModelState.IsValid)  {return BadRequest(ModelState); } 

        try {
            var user = _userService.RegisterUser(userCreateUpdateDTO);
            return CreatedAtAction(nameof(GetUser), new { userId = user.Id }, user);
        }     
        catch (Exception ex)
        {
            _logger.LogError($"Error al registrar el usuario. {ex.Message}");
            return BadRequest($"Error al registrar el usuario. {ex.Message}");
        }
    }

    [HttpPut("{userId}")]
    public IActionResult UpdateUser(int userId, UserCreateUpdateDTO userCreateUpdateDTO)
    {
        try {
            _userService.UpdateUser(userId, userCreateUpdateDTO);
            return NoContent();
        }     
        catch (KeyNotFoundException knfex)
        {
            _logger.LogWarning($"No se ha encontrado el usuario con ID: {userId}. {knfex.Message}");
            return NotFound($"No se ha encontrado el usuario con ID: {userId}. {knfex.Message}");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al actualizar el usuario con ID: {userId}. {ex.Message}");
            return BadRequest($"Error al actualizar el usuario con ID: {userId}. {ex.Message}");
        }
    }

    [HttpDelete("{userId}")]
    public IActionResult DeleteUser(int userId)
    {
        try
        {
            _userService.DeleteUser(userId);
            return NoContent();
        }
        catch (KeyNotFoundException knfex)
        {
            _logger.LogWarning($"No se ha encontrado el usuario con ID: {userId}. {knfex.Message}");
            return NotFound($"No se ha encontrado el usuario con ID: {userId}. {knfex.Message}");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al eliminar el usuario con ID: {userId}. {ex.Message}");
            return BadRequest($"Error al eliminar el usuario con ID: {userId}. {ex.Message}");
        }
    }

}
