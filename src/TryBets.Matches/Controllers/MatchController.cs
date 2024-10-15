using System;
using Microsoft.AspNetCore.Mvc;
using TryBets.Matches.Repository;

namespace TryBets.Matches.Controllers;

[Route("[controller]")]
public class MatchController : Controller
{
    private readonly IMatchRepository _repository;
    public MatchController(IMatchRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("{matchFinished}")]
    public IActionResult Get(bool matchFinished)
    {
        try
        {
            var matches = _repository.Get(matchFinished);
            
            if (matches == null || !matches.Any())
            {
                return NotFound("No matches found.");
            }

            return Ok(matches);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}