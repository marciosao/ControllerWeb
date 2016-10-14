using Domain.Entities;
using Domain.Interfaces.Services;
using Application.Interfaces;
using System.Collections.Generic;

namespace Application
{
    public class OcorrenciaAppService : AppServiceBase<Ocorrencia>,IOcorrenciaAppService
    {
        private readonly IOcorrenciaService _ocorrenciaService;

        public OcorrenciaAppService(IOcorrenciaService ocorrenciaService) : base(ocorrenciaService)
        {
            _ocorrenciaService = ocorrenciaService;

        }

        public IEnumerable<Ocorrencia> ObtemOcorrenciaOrdenado()
        {
            return _ocorrenciaService.ObtemOcorrenciaOrdenado();
        }


        public IEnumerable<Ocorrencia> ObtemOcorrenciaPorFiltroOrdenado(Ocorrencia pOcorrencia)
        {
            return _ocorrenciaService.ObtemOcorrenciaPorFiltroOrdenado(pOcorrencia);
        }
    }
}
