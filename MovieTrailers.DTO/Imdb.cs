using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTrailers.DTO
{
    public class Imdb
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("title_description")]
        public string TitleDescription { get; set; }
        [JsonProperty("episode_title")]
        public string EpisodeTitle { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
