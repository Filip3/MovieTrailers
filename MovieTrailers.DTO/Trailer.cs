using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTrailers.DTO
{
    public class Trailer
    {
        public string Id { get; set; }
        public string Thumbnail { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TitleDescription { get; set; }
        public string Video { get; set; }
    }
}
