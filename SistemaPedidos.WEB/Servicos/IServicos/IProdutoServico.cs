using SistemaPedidos.WEB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaPedidos.WEB.Servicos.IServicos
{
    public interface IProdutoServico
    {
        Task<IEnumerable<ProdutoViewModel>> BuscarProdutos();
        Task<ProdutoViewModel> BuscarProdutoPorId(long id);
        Task<ProdutoViewModel> CriarProduto(ProdutoViewModel vo);
        Task<ProdutoViewModel> AtualizarProduto(ProdutoViewModel vo);
    }
}
