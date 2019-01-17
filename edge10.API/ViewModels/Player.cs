using System.Runtime.Serialization;

namespace edge10.API.ViewModels
{
    [DataContract]
    public class Player
    {
        public Player(string type)
        {
            Type = type;
        }

        [DataMember]
        public string Type { get; private set; }
    }
}