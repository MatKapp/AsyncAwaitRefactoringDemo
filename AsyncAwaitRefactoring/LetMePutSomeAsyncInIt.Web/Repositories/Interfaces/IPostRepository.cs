using LetMePutSomeAsyncInIt.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LetMePutSomeAsyncInIt.Web.Repositories.Interfaces
{
    public interface IPostRepository
    {
        Task<List<Post>> GetAll();
        Task<Post> GetByID(int id);
        Task<List<Post>> GetForUser(int userID);
    }
}