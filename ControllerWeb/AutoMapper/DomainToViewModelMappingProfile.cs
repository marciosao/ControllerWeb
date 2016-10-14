using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ControllerWeb.ViewModels;
using Domain.Entities;
using AutoMapper;

namespace ControllerWeb.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappingProfile"; }
        }

        protected override void Configure()
        {
            //Mapper.CreateMap<DevolucaoProdutoViewModel, DevolucaoProduto>();
            //Mapper.CreateMap<DevolucaoViewModel, Devolucao>();
            //Mapper.CreateMap<FabricanteViewModel, Fabricante>();
            //Mapper.CreateMap<MenuViewModel, Menu>();
            //Mapper.CreateMap<ModeloFabricanteViewModel, ModeloFabricante>();
            //Mapper.CreateMap<ModeloViewModel, Modelo>();
            //Mapper.CreateMap<OcorrenciaViewModel, Ocorrencia>();
            //Mapper.CreateMap<PerfilMenuViewModel, PerfilMenu>();
            //Mapper.CreateMap<VendasProdutoViewModel, VendasProduto>();
            //Mapper.CreateMap<VendaViewModel, Venda>();
            //Mapper.CreateMap<PerfilViewModel, Perfil>();
            //Mapper.CreateMap<ProdutoViewModel, Produto>();
            //Mapper.CreateMap<VendedorViewModel, Vendedor>();
        }
    }
}