using Soft.Bussiness.Models.Books;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Soft.Bussiness.Core.Services
{
    public interface IUserServices
    {
        Task<string> GetUserAsync(User user);

    }
}
