using Domain.Entities;
using Domain.Interfaces.Services;
using Application.Interfaces;

namespace Application
{
    public class ModeloFabricanteAppService : AppServiceBase<ModeloFabricante>,IModeloFabricanteAppService
    {
        private readonly IModeloFabricanteService _modeloFabricanteService;

        public ModeloFabricanteAppService(IModeloFabricanteService modeloFabricanteService) : base(modeloFabricanteService)
        {
            _modeloFabricanteService = modeloFabricanteService;
        }
    }
}
