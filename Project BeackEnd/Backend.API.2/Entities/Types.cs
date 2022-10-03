namespace Backend.API._2.Entities
{
    public class Types
    {
        public int id { get; set; }
        public string type { get; set; }

        public Types(int id, string type)
        {
            this.id = id;
            this.type = type;
        }

        public Types()
        {
        }
    }
}
