using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Web.Http;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using System.Reflection.Metadata.Ecma335;
using System.Configuration;
using System.Text;
using System.Web.Http.Results;
using System.Web.Http.Controllers;
using Microsoft.AspNetCore.Cors;
using JeMovies.Model;

namespace JeMovies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly HttpClient client;
        private static List<string> searchHistory = new List<string>();
        private static string baseUrl = "http://www.omdbapi.com/?apikey=218d2852&";
        public MoviesController() 
        { 
            client = new HttpClient();      
        }

        [HttpGet("search")]

        public async Task<Movie[]> GetMoviesAsync(string searchword)
        {   
            string path = $"{baseUrl}s={searchword}";
            try
            {
                HttpResponseMessage response = await client.GetAsync(path);
                response.EnsureSuccessStatusCode();
                searchHistory.Add(searchword);
                string responseBody= await response.Content.ReadAsStringAsync();
                SearchMovies searchresult = JsonConvert.DeserializeObject<SearchMovies>(responseBody);
                if (searchresult != null && searchresult.Search != null)
                {
                    return searchresult.Search;
                }
                else
                {
                    return new Movie[0]; 
                }
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }

        }
        [HttpGet("searchhistory")]
        public IActionResult GetSearchHistory()
        {
            var length = searchHistory.Count;
            var start = (length - 5) < 0 ? 0 : (length - 5);
            var topFive = new List<string>();
            for (var i = length - 1; i >= start; i--) 
            {
                topFive.Add(searchHistory[i]);
            }
            string json = JsonConvert.SerializeObject(topFive);

            return Content(json, "application/json");
        }

        [HttpGet("details")]
        public async Task<MovieDetails> GetDetailsAsync(string movieId)
        {
            string path = $"{baseUrl}i={movieId}";
            try
            {
                HttpResponseMessage response = await client.GetAsync(path);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                MovieDetails movieDetailsResult = JsonConvert.DeserializeObject<MovieDetails>(responseBody);
                return movieDetailsResult;
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
        }
    }
}
