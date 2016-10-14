using System.Collections;
using Domain.Entities;

namespace Domain.Interfaces.Services
{
    public interface IModeloService : IServiceBase<Modelo>
    {
        IEnumerable ObtemModeloPorNome(string pModelo);
        IEnumerable ObtemModeloPorFiltro(Modelo pModelo);
    }
}
