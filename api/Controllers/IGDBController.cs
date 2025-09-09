using Microsoft.AspNetCore.Mvc;
using IGDB.Models;
using api.Services.IGDB;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IGDBController(IGDBGameService gameService) : ControllerBase
{
    [HttpGet("games/{id}")]
    public async Task<Game> Get(int id)
    {
        var game = await gameService.GetGameById(id);
        return game;
    }

    [HttpGet("games/search/{name}")]
    public async Task<List<SearchResult>> Search(string name, int? limit)
    {
        var games = await gameService.SearchGameByName(name, limit);
        return games;
    }

    [HttpGet("gametypes")]
    public async Task<List<GameType>> GetGameTypes()
    {
        return await gameService.GetGameTypes();
    }
}
