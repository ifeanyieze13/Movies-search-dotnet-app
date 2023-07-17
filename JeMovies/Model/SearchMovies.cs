using Microsoft.AspNetCore.Authentication;
namespace JeMovies.Model
{
    public class SearchMovies
    {
        public Movie[]? Search { get; set; }
        public int totalResults { get; set; }
        public bool Response { get; set; }
    }
}
