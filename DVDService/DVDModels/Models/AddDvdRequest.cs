using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDModels.Models
{
    public class AddDvdRequest
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public int RealeaseYear { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        public string Notes { get; set; }
    }
}
