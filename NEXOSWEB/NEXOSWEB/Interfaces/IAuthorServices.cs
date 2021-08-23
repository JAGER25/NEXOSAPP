using NEXOSWEB.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NEXOSWEB.Interfaces
{
    public interface IAuthorServices
    {
        Task<List<AuthorViewModel>> GetAuthors(string token);
    }
}
