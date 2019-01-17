using System;
using System.Runtime.Serialization;

namespace edge10.API.ViewModels
{
    [DataContract]
    public class GameState
    {
        [DataMember]
        public int Player1 { get; set; }

        [DataMember]
        public int Player2 { get; set; }

        [DataMember]
        public bool BothHumanPlayersPlayed { get; set; }

        [DataMember]
        public PlayerType Player1Type { get; set; }

        [DataMember]
        public PlayerType Player2Type { get; set; }

        [DataMember]
        public int Player1Wins { get; set; }

        [DataMember]
        public int Player2Wins { get; set; }

        public Turn Player1Turn => (Turn) Math.Max(0, Player1 - PlayerRockValues.Player1);

        public Turn Player2Turn => (Turn) Math.Max(0, Player2 - PlayerRockValues.Player2);

        public void WonByPlayer1() => Player1Wins++;
        
        public void WonByPlayer2() => Player2Wins++;

        public GameState ResetWinCountIf(bool seriesWon)
        {
            if (seriesWon)
            {
                ResetWinCount();
            }

            return this;
        }

        private void ResetWinCount()
        {
            Player1Wins = 0;
            Player2Wins = 0;
        }
    }
}