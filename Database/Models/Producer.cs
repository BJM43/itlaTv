namespace Database.Models
{
    public class Producer
    {
        public int Id { get; set; } // PK
        public string Name { get; set; }

        //Navigation properties
        public ICollection<TvSerie>? TvSeries { get; set;}
    }
}
