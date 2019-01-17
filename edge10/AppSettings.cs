using System.Configuration;

namespace edge10
{
    // It's possible to make this "application" more dynamic
    // by configuring both possible strategies and turn types (e.g. spock, lizard) in web.config, etc
    public static class AppSettings
    {
        public static int FirstToWinGamesCount => int.Parse(ConfigurationManager.AppSettings["FirstToWinGamesCount"] ?? "2");
    }
}