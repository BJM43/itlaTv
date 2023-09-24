namespace Database.Models
{
    public class TvSerie
    {
        public int Id { get; set; } // PK
        public string Name { get; set; }
        public string Link { get; set; }
        public string ImgLink { get; set; }

        public int ProducerId { get; set; } // FK
        public int PrimaryGenderId { get; set;} // FK
        public int SecondaryGenderId { get; set; } // FK

        //Navigation properties
        public Producer? Producer { get; set; }
        public Gender? Gender { get; set; }

    }
}
