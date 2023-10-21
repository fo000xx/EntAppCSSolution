namespace EntAppCSLibrary.Models
{
    public class GameModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string GamePlatform { get; set; }
        public int Rating { get; set; }
        public bool IsMultiplayer { get; set; }
        public bool IsPlayed { get; set; }
        public bool IsOwned { get; set; }
    }
}
