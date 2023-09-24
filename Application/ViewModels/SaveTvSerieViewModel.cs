using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class SaveTvSerieViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe colocar el nombre de la Serie")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Debe colocar la url de la Serie")]
        public string Link { get; set; }

        [Required(ErrorMessage = "Debe colocar la url de la imagen de portada de la Serie")]
        public string ImgLink { get; set; }

        [Required(ErrorMessage = "Debe colocar la productora de la Serie")]
        public int ProducerId { get; set; }

        [Required(ErrorMessage = "Debe colocar el genero de la Serie")]
        public int GenderId { get; set; }
    }
}
