namespace TrybeGames;

public class TrybeGamesDatabase
{
    public List<Game> Games = new List<Game>();

    public List<GameStudio> GameStudios = new List<GameStudio>();

    public List<Player> Players = new List<Player>();

    // 4. Crie a funcionalidade de buscar jogos desenvolvidos por um estúdio de jogos
    public List<Game> GetGamesDevelopedBy(GameStudio gameStudio)
    {
        List<Game> gamesByStudio = Games.Where(game => game.DeveloperStudio == gameStudio.Id).ToList();
        return gamesByStudio;
    }

    // 5. Crie a funcionalidade de buscar jogos jogados por uma pessoa jogadora
    public List<Game> GetGamesPlayedBy(Player player)
    {
        List<Game> gamesPlayer = Games.Where(game => game.Players.Contains(player.Id)).ToList();
        return gamesPlayer;
    }

    // 6. Crie a funcionalidade de buscar jogos comprados por uma pessoa jogadora
    public List<Game> GetGamesOwnedBy(Player playerEntry)
    {
        List<Game> gamesPlayer = Games.Where(game => playerEntry.GamesOwned.Contains(game.Id)).ToList();
        return gamesPlayer;
    }


    // 7. Crie a funcionalidade de buscar todos os jogos junto do nome do estúdio desenvolvedor
    public List<GameWithStudio> GetGamesWithStudio()
    {
        List<GameWithStudio> gamesDetails = Games.Select(game => new GameWithStudio { 
            GameName = game.Name, 
            StudioName = GameStudios.Where(studio => studio.Id == game.DeveloperStudio).Select(studio => studio.Name).FirstOrDefault(),
            NumberOfPlayers = game.Players.Count,            
            }).ToList();
        return gamesDetails;
    }
    
    // 8. Crie a funcionalidade de buscar todos os diferentes Tipos de jogos dentre os jogos cadastrados
    public List<GameType> GetGameTypes()
    {
        var gameTypes = from game in Games
                                   group game by game.GameType into types
                                   select types.Key;
        return gameTypes.ToList();
    }

    // 9. Crie a funcionalidade de buscar todos os estúdios de jogos junto dos seus jogos desenvolvidos com suas pessoas jogadoras
    public List<StudioGamesPlayers> GetStudiosWithGamesAndPlayers()
    {
        // Implementar
        throw new NotImplementedException();
    }

}
