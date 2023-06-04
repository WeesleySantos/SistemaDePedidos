using AutoMapper;
using SistemaPedidos.API.Data.ValueObjects;
using SistemaPedidos.API.Model;

namespace SistemaPedidos.API.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProdutoVO, Produto>();
                config.CreateMap<Produto, ProdutoVO>();
                config.CreateMap<ClienteVO, Cliente>();
                config.CreateMap<Cliente, ClienteVO>();
                config.CreateMap<PedidoVO, Pedido>();
                config.CreateMap<Pedido, PedidoVO>();
                config.CreateMap<ProdutosClienteVO, ProdutosCliente>();
                config.CreateMap<ProdutosCliente, ProdutosClienteVO>();
            });
            return mappingConfig;
        }
    }
}
