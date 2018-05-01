using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DVDModels.Models
{
    public class EditDvdRequest
    {
        [Required]
        public int DvdId { get; set; }
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
