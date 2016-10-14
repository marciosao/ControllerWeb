using System;
using System.Collections;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public class ModeloService : ServiceBase<Modelo>,IModeloService
    {
        private readonly IModeloRepository _modeloRepository;

        public ModeloService(IModeloRepository modeloRepository) : base(modeloRepository)
        {
            _modeloRepository = modeloRepository;

        }

        public IEnumerable ObtemModeloPorFiltro(Modelo pModelo)
        {
            return _modeloRepository.ObtemModeloPorFiltro(pModelo);
        }

        public IEnumerable ObtemModeloPorNome(string pModelo)
        {
            return _modeloRepository.ObtemModeloPorNome(pModelo);
        }
    }
}
