using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DvdLibraryApi.Models
{
    public class Movie
    {
        public int DvdId { get; set; }
        public string Title { get; set; }
        public string ReleaseYear { get; set; }
        public string Director { get; set; }
        public string Rating { get; set; }
        public string Notes { get; set; }
    }
}