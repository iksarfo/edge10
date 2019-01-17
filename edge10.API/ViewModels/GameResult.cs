using System.Runtime.Serialization;

namespace edge10.API.ViewModels
{
    [DataContract]
    public class GameResult
    {
        public GameResult(
            string text,
            GameState gameState,
            bool seriesWon = false) : this(gameState, seriesWon)
        {
            Text = text;
        }

        public GameResult(GameState gameState, bool seriesWon)
        {
            GameState = gameState.ResetWinCountIf(seriesWon);
        }

        [DataMember]
        public string Text { get; private set; }

        [DataMember]
        public GameState GameState { get; private set; }
    }
}