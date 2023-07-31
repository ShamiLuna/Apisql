namespace WebApplication1.Mo
{
    public class Products
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }

        public string Image { get; set; }

        public List<Rating> Rat { get; set; } = new List<Rating>();
    }
    public class Rating
    {
        public string rate { get; set; }  
        public string count { get; set; }
    }
}
