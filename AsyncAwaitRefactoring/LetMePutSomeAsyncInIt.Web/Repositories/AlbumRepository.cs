using LetMePutSomeAsyncInIt.Web.Models;
using LetMePutSomeAsyncInIt.Web.Repositories.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace LetMePutSomeAsyncInIt.Web.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        public async Task<List<Album>> GetAll()
        {
            using (HttpClient client = new HttpClient())
            {
                var albumJson = await client.GetStringAsync("https://jsonplaceholder.typicode.com/albums");

                return JsonConvert.DeserializeObject<List<Album>>(albumJson);
            }
        }

        public async Task<Album> GetByID(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var albumJson = await client.GetStringAsync("https://jsonplaceholder.typicode.com/albums/" + id.ToString());
                var album = JsonConvert.DeserializeObject<Album>(albumJson);

                var photosJson = await client.GetStringAsync("https://jsonplaceholder.typicode.com/photos?albumId=" + id.ToString());
                album.Photos = JsonConvert.DeserializeObject<List<Photo>>(photosJson);

                return album;
            }
        }

        public async Task<List<Album>> GetForUser(int userID)
        {
            using (HttpClient client = new HttpClient())
            {
                var albumJson = await client.GetStringAsync("https://jsonplaceholder.typicode.com/albums?userId=" + userID.ToString());
                var albums = JsonConvert.DeserializeObject<List<Album>>(albumJson);

                return albums;
            }
        }
    }
}