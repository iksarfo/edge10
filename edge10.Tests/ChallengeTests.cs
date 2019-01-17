using Edge10.Models;
using NUnit.Framework;

namespace edge10
{
    [TestFixture]
    public class ChallengeTests
    {
        [Test]
        public void PaperBeatsRock()
        {
            Assert.That(Challenge.ResolveWinner(Turn.Rock, Turn.Paper)
                .Equals(Result.SecondPlayerWins));
        }
        
        [Test]
        public void ScissorsBeatPaper()
        {
            Assert.That(Challenge.ResolveWinner(Turn.Paper, Turn.Scissors)
                .Equals(Result.SecondPlayerWins));
        }

        [Test]
        public void FirstBeatsSecond()
        {
            Assert.That(Challenge.ResolveWinner(Turn.Paper, Turn.Rock)
                .Equals(Result.FirstPlayerWins));
        }

        [Test, TestCaseSource(typeof(Tests.TestCaseData), nameof(Tests.TestCaseData.SecondPlayerWinsCases))]
        public Result SecondBeatsFirst(Turn first, Turn second)
        {
            return Challenge.ResolveWinner(first, second);
        }
    }
}