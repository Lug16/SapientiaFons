using System;
using System.ComponentModel.DataAnnotations;

namespace SapientiaFons.ViewModels
{
    public class SubjectViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Título")]
        public string Title { get; set; }

        [StringLength(500)]
        [Display(Name = "Descripción")]
        public string Description { get; set; }

        [Display(Name = "Fecha")]
        public DateTime Date { get; set; }

        [Display(Name = "Identificador")]
        public string ShortUrl { get; set; }
    }
}