using Domain.Entities;
using Domain.Interfaces.Services;
using Application.Interfaces;
using System;
using System.Collections;

namespace Application
{
    public class ModeloAppService : AppServiceBase<Modelo>,IModeloAppService
    {
        private readonly IModeloService _modeloService;

        public ModeloAppService(IModeloService modeloService) : base(modeloService)
        {
            _modeloService = modeloService;

        }

        public IEnumerable ObtemModeloPorFiltro(Modelo pModelo)
        {
            return _modeloService.ObtemModeloPorFiltro(pModelo);
        }

        public IEnumerable ObtemModeloPorNome(string pModelo)
        {
            return _modeloService.ObtemModeloPorNome(pModelo);
        }
    }
}
