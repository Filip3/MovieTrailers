using MovieTrailers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MovieTrailers.DTO;
using Google.Apis.YouTube.v3;
using Google.Apis.Services;

namespace MovieTrailers.BLL
{
    public class SearchBLL : ISearchBLL
    {
        public List<Trailer> Search(string keyword)
        {
            var imdbResult = GetImdbResult(keyword);
            
            var retrieveTrailers = GetTrailers(imdbResult);

            return retrieveTrailers;
        }

        public ImdbResult GetImdbResult(string keyword)
        {
            var imdbAPI = "http://www.imdb.com/";
            var url = string.Format("xml/find?json=1&nr=1&tt=on&q={0}", keyword);

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(imdbAPI);

            var imdbResponse = client.GetAsync(url);
            ImdbResult imdbResult = new ImdbResult();

            if (imdbResponse.Result.IsSuccessStatusCode)
            {
                string responseContent = imdbResponse.Result.Content.ReadAsStringAsync().Result;
                imdbResult = JsonConvert.DeserializeObject<ImdbResult>(responseContent);
            }

            return imdbResult;
        }

        public List<Trailer> GetTrailers(ImdbResult imdbResult)
        {
            List<Trailer> trailers = new List<Trailer>();

            foreach(var imdb in imdbResult.TitlePopular)
            {
                Trailer trailer = new Trailer();

                trailer = FillTrailerData(imdb);

                trailers.Add(trailer);
            }

            return trailers;
        }


        public Trailer FillTrailerData(Imdb imdb)
        {
            Trailer trailer = new Trailer();

            Youtube youtube = GetYouTube(imdb);

            trailer.Id = youtube.Id;
            trailer.Thumbnail = youtube.Thumbnail;
            trailer.Title = imdb.Title;
            trailer.TitleDescription = RetrieveTitleDescriptionForSearch(imdb.TitleDescription);

            return trailer;
        }

        public Youtube GetYouTube(Imdb imdb)
        {
            Youtube youtube = new Youtube();

            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyDPdiKDpjnwevDYtAMuMiFI0Zhdadl5QzY",
                ApplicationName = this.GetType().ToString()
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            var titleDescription = RetrieveTitleDescriptionForSearch(imdb.TitleDescription);

            searchListRequest.Q = string.Format("{0} {1} trailer", imdb.Title, titleDescription);
            searchListRequest.MaxResults = 1;

            // Call the search.list method to retrieve results matching the specified query term.
            var searchListResponse = searchListRequest.Execute();

            youtube.Id = searchListResponse.Items.FirstOrDefault().Id.VideoId;
            youtube.Thumbnail = searchListResponse.Items.FirstOrDefault().Snippet.Thumbnails.Default__.Url;

            return youtube;
        }

        // Retrieve substring of the title description for the search
        public string RetrieveTitleDescriptionForSearch(string titleDescription)
        {
            string result = string.Empty;

            if(!string.IsNullOrEmpty(titleDescription))
                result = titleDescription.Split(',')[0];

            return result;
        }
    }
}
