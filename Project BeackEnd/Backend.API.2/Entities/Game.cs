namespace Backend.API._2.Entities
{
    public class Game
    {

        public int id { get; set; }
        public string image { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int publisher { get; set; }
        public double score { get; set; }
        public string genre { get; set; }
        public int type { get; set; }
        public string tagsText { get; set; }

        //public string[] tags { get;}
        
        public List<string> tags { get; set; }
        public List<string> Tags()
        {
            return this.tags = this.tagsText.Split(",").ToList();
        }
        public Game(int id, string image, string title, string description, int publisher, double score, string genre, int type, string tags)
        {
            this.id = id;
            this.image = image;
            this.title = title;
            this.description = description;
            this.publisher = publisher;
            this.score = score;
            this.genre = genre;
            this.type = type;
            //this.tagsText = tags;
            Tags();
            //this.tags = tags.Split(",");

        }

        public Game()
        {
        }

    }
}
