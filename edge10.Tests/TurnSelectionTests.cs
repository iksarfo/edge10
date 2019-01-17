using System.Collections.Generic;
using System.Linq;
using Edge10.Models;
using NUnit.Framework;

namespace edge10.Tests
{
    [TestFixture]
    public class TurnSelectionTests
    {
        [Test]
        public void HumanTurnsArePreserved()
        {
            Assert.AreEqual(Turn.Rock, new TurnSelection(PlayerType.Human).GetTurn(Turn.Rock));
            Assert.AreEqual(Turn.Scissors, new TurnSelection(PlayerType.Human).GetTurn(Turn.Scissors));
            Assert.AreEqual(Turn.Paper, new TurnSelection(PlayerType.Human).GetTurn(Turn.Paper));
        }

        [Test]
        public void GeneratesRandomTurns()
        {
            const int maxIterations = 99;
            var turns = new List<Turn>();

            for (var i = 0; i <= maxIterations; i++)
            {
                turns.Add(new TurnSelection(PlayerType.RandomComputer)
                    .GetTurn(Turns.Min));
            }

            Assert.That(turns.Any(_ => _ == Turn.Rock));
            Assert.That(turns.Any(_ => _ == Turn.Scissors));
            Assert.That(turns.Any(_ => _ == Turn.Paper));
        }

        [Test]
        public void SuccessiveTacticalTurnsBeatPreviousTurns()
        {
            foreach (var turn in new []{ Turn.Rock, Turn.Scissors, Turn.Paper })
            {
                var successiveTurn = new TurnSelection(PlayerType.TacticalComputer).GetTurn(turn);
                
                Assert.That(Challenge.ResolveWinner(turn, successiveTurn)
                    .Equals(Result.SecondPlayerWins));
            }
        }
    }
}