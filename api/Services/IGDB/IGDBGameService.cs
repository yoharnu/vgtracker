using IGDB;
using IGDB.Models;
using System.Text.Json.Serialization;

namespace api.Services.IGDB;

public class SearchResult
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Year { get; set; }
    public string GameType { get; set; } = string.Empty;

    [JsonConstructor]
    public SearchResult() { }
    public SearchResult(Game game)
    {
        this.Id = game.Id ?? 0;
        this.Name = game.Name;
        this.Year = game.FirstReleaseDate?.Year ?? 0;
        this.GameType = game.GameType.Value.Type;
    }
}

public class IGDBGameService(IGDBClient client)
{
    public async Task<Game> GetGameById(int id)
    {
        var games = await client.QueryAsync<Game>(IGDBClient.Endpoints.Games, query: $"fields id,name,platforms.*,parent_game,genres.name,game_status.*,release_dates.date,release_dates.human,release_dates.platform.*,release_dates.status.*,summary,websites.url,websites.type.type; where id = {id};");
        var game = games.First();

        return game;
    }

    public async Task<List<SearchResult>> SearchGameByName(string name, int? limit = null)
    {
        if (name.Length < 2 || limit < 1) return [];

        int _limit = Math.Min(limit ?? 5, 100);

        var searchResults = await client.QueryAsync<Game>(IGDBClient.Endpoints.Games, query: $"search \"{name}\"; fields id,name,first_release_date,game_type.type,parent_game.name,parent_game.game_type; where game_type = (0,1,4,8,10,9,2) & version_parent = null; limit {_limit};");
        return searchResults
            .Select(x => new SearchResult(x))
            .ToList();
    }

    public async Task<List<GameType>> GetGameTypes()
    {
        var results = await client.QueryAsync<GameType>(IGDBClient.Endpoints.GameTypes, query: "fields *; limit 100;");
        return results.ToList();
    }
}
