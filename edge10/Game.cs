namespace edge10
{
    public static class Game
    {
        public static bool IsOver(PlayerType player1, PlayerType player2, bool bothHumansPlayed)
            => player1 != PlayerType.Human
            || player2 != PlayerType.Human
            || bothHumansPlayed;
    }
}