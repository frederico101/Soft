using Soft.Infra.Data.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Soft.Bussiness.Models.Books;
using System.Linq;

namespace Soft.Infra.Data.Repository
{

    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context) { }

    }
}
