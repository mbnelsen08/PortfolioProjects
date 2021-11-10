using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DvdLibraryApi.Models
{
    public class AddMovieRequest
    {
        [Required]
        public string Title { get; set; }
        public string Rating { get; set; }
        public string Director { get; set; }
        public string Notes { get; set; }
        [Required]
        public string ReleaseYear { get; set; }
    }

    public class UpdateMovieRequest
    {
        [Required]
        public int DvdId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Rating { get; set; }
        public string Director { get; set; }
        public string Notes { get; set; }
        [Required]
        public string ReleaseYear { get; set; }
    }
}