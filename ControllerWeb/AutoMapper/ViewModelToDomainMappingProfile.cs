using AutoMapper;
using Domain.Entities;
using ControllerWeb.ViewModels;

namespace ControllerWeb.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappingProfile"; }
        }

        protected override void Configure()
        {
            //Mapper.CreateMap<DevolucaoProduto, DevolucaoProdutoViewModel>();
            //Mapper.CreateMap<Devolucao,DevolucaoViewModel>();
            //Mapper.CreateMap<Fabricante,FabricanteViewModel>();
            //Mapper.CreateMap<Menu,MenuViewModel>();
            //Mapper.CreateMap<ModeloFabricante,ModeloFabricanteViewModel>();
            //Mapper.CreateMap<Modelo,ModeloViewModel>();
            //Mapper.CreateMap<Ocorrencia,OcorrenciaViewModel>();
            //Mapper.CreateMap<PerfilMenu,PerfilMenuViewModel>();
            //Mapper.CreateMap<VendasProduto,VendasProdutoViewModel>();
            //Mapper.CreateMap<Venda,VendaViewModel>();
            //Mapper.CreateMap<Perfil,PerfilViewModel>();
            //Mapper.CreateMap<Produto,ProdutoViewModel>();
            //Mapper.CreateMap<Vendedor,VendedorViewModel>();
        }
    }
}