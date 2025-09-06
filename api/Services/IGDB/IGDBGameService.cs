using IGDB;
using IGDB.Models;

namespace api.Services.IGDB;

public class IGDBGameService(IGDBClient client)
{
    public async Task<Game> GetGameById(int id)
    {
        var games = await client.QueryAsync<Game>(IGDBClient.Endpoints.Games, query: $"fields id,name,platforms.*,parent_game,genres.name,game_status.*,release_dates.date,release_dates.human,release_dates.platform.*,release_dates.status.*,summary,websites.url,websites.type.type; where id = {id};");
        var game = games.First();

        return game;
    }
}
