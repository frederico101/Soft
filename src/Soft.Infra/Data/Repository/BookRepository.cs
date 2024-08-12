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

        public List<Book> ObterProdutoFornecedor(Guid id)
        {
            return  _applicationDbContext.Books.AsNoTracking().ToList();
        }

        //public async Task<IEnumerable<Produto>> ObterProdutosFornecedores()
        //{
        //    return await Db.Produtos.AsNoTracking()
        //        .Include(f => f.Fornecedor)
        //        .OrderBy(p => p.Nome).ToListAsync();
        //}

        //public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId)
        //{
        //    return await Buscar(p => p.FornecedorId == fornecedorId);
        //}
    }
}
