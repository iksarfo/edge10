using Edge10.Models;

namespace edge10
{
    public static class Challenge
    {
        public static Result ResolveWinner(Turn first, Turn second)
        {
            if (first == second)
            {
                return Result.Draw;
            }

            if (second > first)
            {
                // higher turn wins unless it's the last one (because the last one is beaten by the first)
                return second == Turns.Max && first == Turns.Min
                    ? Result.FirstPlayerWins
                    : Result.SecondPlayerWins;
            }

            return first == Turns.Max && second == Turns.Min 
                ? Result.SecondPlayerWins
                : Result.FirstPlayerWins;
        }
    }
}