﻿using Microsoft.AspNetCore.Authentication;

namespace JeMovies.Model
{
    public class Movie
    {
        public string imdbId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }

        public string Year { get; set; }
        public string Plot { get; set; }

        public string Type { get; set; }
        public string Poster { get; set; }

    }


}
