namespace EntAppCSLibrary.Models
{
    public class SearchModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Series { get; set; }
        public string Genre { get; set; }
        public string GamePlatform { get; set; }
        public string ScreenType { get; set; }
        public int Rating { get; set; }
        public int ItemID { get; set; }
        public bool IsMultiplayer { get; set; }
        public bool IsFinished { get; set; }
        public bool IsOwned { get; set; }

    }
}
