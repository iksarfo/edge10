using System.Collections.Generic;
using System.Web.Http;
using edge10.API.ViewModels;

namespace edge10.API.Controllers
{
    public class PlayersController : ApiController
    {
        public IEnumerable<Player> Get()
        {
            yield return new Player("Human");
            yield return new Player("Random Computer");
            yield return new Player("Tactical Computer");
        }
    }
}