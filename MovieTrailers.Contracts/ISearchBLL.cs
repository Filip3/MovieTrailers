using MovieTrailers.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTrailers.Contracts
{
    public interface ISearchBLL
    {
        List<Trailer> Search(string keyword);
        ImdbResult GetImdbResult(string keyword);
        List<Trailer> GetTrailers(ImdbResult imdbResult);
        Trailer FillTrailerData(Imdb imdb);
        Youtube GetYouTube(Imdb imdb);
        string RetrieveTitleDescriptionForSearch(string titleDescription);
    }
}
