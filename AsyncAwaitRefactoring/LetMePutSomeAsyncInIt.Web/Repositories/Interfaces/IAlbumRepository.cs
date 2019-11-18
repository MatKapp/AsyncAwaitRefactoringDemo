using LetMePutSomeAsyncInIt.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LetMePutSomeAsyncInIt.Web.Repositories.Interfaces
{
    public interface IAlbumRepository
    {
        Task<Album> GetByID(int id);
        Task<List<Album>> GetForUser(int userID);

        Task<List<Album>> GetAll();
    }
}