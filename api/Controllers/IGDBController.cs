using Microsoft.AspNetCore.Mvc;
using IGDB.Models;
using api.Services.IGDB;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IGDBController(IGDBGameService gameService) : ControllerBase
{
    // GET api/<IGDBController>/5
    [HttpGet("{id}")]
    public async Task<Game> Get(int id)
    {
        var game = await gameService.GetGameById(id);
        return game;
    }
}
