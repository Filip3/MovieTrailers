using MovieTrailers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieTrailers.DTO;
using System.Web.Helpers;
using MovieTrailers.Helpers;

namespace MovieTrailers.Controllers
{
    public class SearchController : ApiController
    {
        private ISearchBLL _searchBLL;

        public SearchController(ISearchBLL searchBLL)
        {
            _searchBLL = searchBLL;
        }

        // Here I would add a way to handle exceptions, for example like my other repo on GitHub, 
        // to handle the exceptions that i would catch and throw in BLL
        // Also i would use some notification system on top, for showing some message to the user, 
        // for example like tostr, bootstrap errors, or some custom implementation
        // GET api/<controller>/{keyword}
        public List<Trailer> Get(string keyword)
        {
            List<Trailer> trailers = new List<Trailer>();

            var result = MemoryCacher.GetValue(keyword);

            if (result == null)
            {
                // Search for the title in IMDB and then search for trailers in YouTube
                trailers = _searchBLL.Search(keyword);

                MemoryCacher.Add(keyword, trailers, DateTimeOffset.UtcNow.AddHours(24));
                return trailers;
            }

            return (List<Trailer>)result;
        }
    }
}