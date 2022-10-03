namespace Backend.API._2.Entities
{
    public class Publishers
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string description { get; set; }
        public string site { get; set; }
        public int games { get; set; }

        public Publishers(int id, string name, string image, string description, string site, int games)
        {
            this.id = id;
            this.name = name;
            this.image = image;
            this.description = description;
            this.site = site;
            this.games = games;
        }

        public Publishers()
        {
        }
    }
}
