using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Services
{
    public interface IOcorrenciaService : IServiceBase<Ocorrencia>
    {
        IEnumerable<Ocorrencia> ObtemOcorrenciaOrdenado();
        IEnumerable<Ocorrencia> ObtemOcorrenciaPorFiltroOrdenado(Ocorrencia pOcorrencia);
    }
}
