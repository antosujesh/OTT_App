namespace OTTApp.Models
{
    public class MovieList
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Rating { get; set; }
        public string CreatedDate { get; set; }
    }

    public class MovieListReq
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Rating { get; set; }

    }
}
