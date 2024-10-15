using System;
using Microsoft.AspNetCore.Mvc;
using TryBets.Users.Repository;
using TryBets.Users.Services;
using TryBets.Users.Models;
using TryBets.Users.DTO;

namespace TryBets.Users.Controllers;

[Route("[controller]")]
public class UserController : Controller
{
    private readonly IUserRepository _repository;
    public UserController(IUserRepository repository)
    {
        _repository = repository;
    }

    [HttpPost("signup")]
    public IActionResult Post([FromBody] User user)
    {
        try 
        {
            User newUser = _repository.Post(user);
            string  token = new TokenManager().Generate(newUser);
            AuthDTOResponse response = new() { Token = token };
            return Created("", response);
        } catch (Exception e) 
        {
            return BadRequest(new { message = e.Message });
        }
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] AuthDTORequest login)
    {
        try 
        {
            User existingUser = _repository.Login(login);
            var token = new TokenManager().Generate(existingUser);
            return Ok(new { token });

        } catch (Exception e) 
        {
            return BadRequest(new { message = e.Message });
        }
    }
}