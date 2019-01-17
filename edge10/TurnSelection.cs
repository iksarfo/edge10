using System;
using System.Collections.Generic;

namespace edge10
{
    public class TurnSelection
    {
        private static int _randomSeed = 1;

        private static readonly Dictionary<PlayerType, Func<Turn, Turn>> TurnStrategy
            = new Dictionary<PlayerType, Func<Turn, Turn>>
            {
                {PlayerType.Human, _ => _},
                {PlayerType.RandomComputer, RandomTurn},
                {PlayerType.TacticalComputer, TacticalTurn}
            };

        public TurnSelection(PlayerType playerType)
        {
            PlayerType = playerType;
        }

        public Turn GetTurn(Turn selected) =>
            TurnStrategy[PlayerType](selected);

        private PlayerType PlayerType { get; }

        private static Turn RandomTurn(Turn turn) =>
            (Turn) (new Random(_randomSeed++)
                        .Next(0, 99) % ((int) Turns.Max + 1));

        private static Turn TacticalTurn(Turn turn) =>
            turn == Turns.Max
                ? Turns.Min
                : turn + 1;
    }
}