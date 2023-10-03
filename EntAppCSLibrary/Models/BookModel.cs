namespace EntAppCSLibrary.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Series { get; set; }
        public int Rating { get; set; }
        public bool IsRead { get; set; }
    }
}
