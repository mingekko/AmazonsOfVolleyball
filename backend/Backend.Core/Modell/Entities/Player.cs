using Backend.Core.Modell.Request;
using System;

namespace Backend.Core.Modell.Entities
{
    public class Player : PlayerRequest
    {
        public int Id{ get; set; }

        public Player()
        {
        }

        public Player(PlayerRequest player, int id)
        {
            Id = id;
            Name = player.Name;
            ImageLink = string.IsNullOrEmpty(player.ImageLink) ?
                        null :
                        $"./assets/images/{player.ImageLink}";
            Club = player.Club;
            Birthday = DateTime.Parse(player.Birthday).ToLongDateString();
            BirthPlace = player.BirthPlace;
            Weight = player.Weight;
            Height = player.Height;
            Description = player.Description;
            Position = player.Position;
        }
    }
}
