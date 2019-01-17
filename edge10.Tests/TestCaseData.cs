using System.Collections;
using Edge10.Models;

namespace edge10.Tests
{
    public class TestCaseData
    {
        public static IEnumerable SecondPlayerWinsCases
        {
            get
            {
                yield return 
                    new NUnit.Framework.TestCaseData(Turn.Rock, Turn.Paper)
                        .Returns(Result.SecondPlayerWins);
                
                yield return
                    new NUnit.Framework.TestCaseData(Turn.Paper, Turn.Scissors)
                        .Returns(Result.SecondPlayerWins);
                
                yield return
                    new NUnit.Framework.TestCaseData(Turn.Scissors, Turn.Rock)
                        .Returns(Result.SecondPlayerWins);
            }
        }  
    }
}