using System.Web.Http;
using edge10.API.Models;
using edge10.API.ViewModels;

namespace edge10.API.Controllers
{
    //TODO: move all this logic into a service/model and cover with tests!
    public class GameController : ApiController
    {
        public GameResult Get([FromUri]GameState gameState)
        {
            if (!Game.IsOver(
                gameState.Player1Type,
                gameState.Player2Type,
                gameState.BothHumanPlayersPlayed))
            {
                return new GameResult(gameState, false);
            }

            var firstPlayerChooses =
                new TurnSelection(gameState.Player1Type)
                    .GetTurn(gameState.Player1Turn);

            var secondPlayerChooses =
                new TurnSelection(gameState.Player2Type)
                    .GetTurn(gameState.Player2Turn);

            var winner = Challenge.ResolveWinner(firstPlayerChooses, secondPlayerChooses);

            gameState.Player1 =
                gameState.Player1Type == PlayerType.Human
                    ? gameState.Player1
                    : (int) firstPlayerChooses;

            gameState.Player2 =
                gameState.Player2Type == PlayerType.Human
                    ? gameState.Player2
                    : (int) secondPlayerChooses;

            return GameResultHandling.GetResult(winner, gameState);
        }
    }
}