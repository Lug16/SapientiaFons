using System;
using System.ComponentModel.DataAnnotations;

namespace SapientiaFons.Models
{
    public class Subject
    {
        [Required]
        public int Id { get; set; }

        private DateTime? date;
        public ApplicationUser User { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public DateTime Date
        {
            get
            {
                return date.HasValue ? date.Value : DateTime.Now;
            }
            set
            {
                date = value;
            }
        }

        public string ShortUrl { get; set; }
    }
}