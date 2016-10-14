using System;
using System.Collections;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public class ModeloFabricanteService : ServiceBase<ModeloFabricante>,IModeloFabricanteService
    {
        private readonly IModeloFabricanteRepository _modeloFabricanteRepository;

        public ModeloFabricanteService(IModeloFabricanteRepository modeloFabricanteRepository) : base(modeloFabricanteRepository)
        {
            _modeloFabricanteRepository = modeloFabricanteRepository;
        }
    }
}
