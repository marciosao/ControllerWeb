using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System.Collections.Generic;
namespace Domain.Services
{
    public class OcorrenciaService : ServiceBase<Ocorrencia>,IOcorrenciaService
    {
        private readonly IOcorrenciaRepository _ocorrenciaRepository;

        public OcorrenciaService(IOcorrenciaRepository ocorrenciaRepository) : base(ocorrenciaRepository)
        {
            _ocorrenciaRepository = ocorrenciaRepository;
        }

        public IEnumerable<Ocorrencia> ObtemOcorrenciaOrdenado()
        {
            return _ocorrenciaRepository.ObtemOcorrenciaOrdenado();
        }


        public IEnumerable<Ocorrencia> ObtemOcorrenciaPorFiltroOrdenado(Ocorrencia pOcorrencia)
        {
            return _ocorrenciaRepository.ObtemOcorrenciaPorFiltroOrdenado(pOcorrencia);
        }
    }
}
