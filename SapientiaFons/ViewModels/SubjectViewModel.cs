using System;
using System.ComponentModel.DataAnnotations;

namespace SapientiaFons.ViewModels
{
    public class SubjectViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public DateTime Date { get; set; }

        public string ShortUrl { get; set; }
    }
}