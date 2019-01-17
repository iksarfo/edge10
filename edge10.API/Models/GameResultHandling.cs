using System;
using edge10.API.ViewModels;
using Edge10.Models;

namespace edge10.API.Models
{
    public static class GameResultHandling
    {
        public static GameResult GetResult(Result result, GameState gameState)
        {
            switch (result)
            {
                case Result.Draw:
                    return new GameResult("It's a draw!", gameState);

                case Result.FirstPlayerWins:
                    gameState.WonByPlayer1();

                    return gameState.Player1Wins < AppSettings.FirstToWinGamesCount
                        ? new GameResult("#1 wins!", gameState)
                        : new GameResult("#1 wins the series!", gameState, true);

                case Result.SecondPlayerWins:
                    gameState.WonByPlayer2();

                    return gameState.Player2Wins < AppSettings.FirstToWinGamesCount
                        ? new GameResult("#2 wins!", gameState)
                        : new GameResult("#2 wins the series!", gameState, true);

                default:
                    throw new ArgumentException($"Unexpected result {result}", nameof(result));
            }
        }
    }
}