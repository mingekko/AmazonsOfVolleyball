namespace Backend.Core.Modell.Request
{
    public class PlayerRequest
    {
        public string Name { get; set; }
        public string ImageLink { get; set; }
        public string Club { get; set; }
        public string Birthday { get; set; }
        public string BirthPlace { get; set; }
        public int Weight { get; set; }
        public double Height { get; set; }
        public string Description { get; set; }

        public string Position { get; set; }
    }
}
