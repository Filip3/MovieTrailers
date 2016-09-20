using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTrailers.DTO
{
    public class ImdbResult
    {
        [JsonProperty("title_popular")]
        public List<Imdb> TitlePopular { get; set; }
        [JsonProperty("title_exact")]
        public List<Imdb> TitleExact { get; set; }
        [JsonProperty("title_substring")]
        public List<Imdb> TitleSubstring { get; set; }
    }
}
