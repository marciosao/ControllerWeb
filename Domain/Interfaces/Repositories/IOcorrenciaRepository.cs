using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Repositories
{
    public interface IOcorrenciaRepository : IRepositoryBase<Ocorrencia>
    {
        IEnumerable<Ocorrencia> ObtemOcorrenciaOrdenado();
        IEnumerable<Ocorrencia> ObtemOcorrenciaPorFiltroOrdenado(Ocorrencia pOcorrencia);
    }
}
