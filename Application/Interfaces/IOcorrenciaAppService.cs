using Domain.Entities;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IOcorrenciaAppService : IAppServiceBase<Ocorrencia>
    {
        IEnumerable<Ocorrencia> ObtemOcorrenciaOrdenado();
        IEnumerable<Ocorrencia> ObtemOcorrenciaPorFiltroOrdenado(Ocorrencia pOcorrencia);
    }
}
