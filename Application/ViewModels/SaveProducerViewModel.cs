﻿using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class SaveProducerViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe colocar el nombre de la Productora")]
        public string Name { get; set; }
    }
}
