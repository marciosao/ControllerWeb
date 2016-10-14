using Domain.Entities;
using System.Collections;

namespace Application.Interfaces
{
    public interface IModeloAppService : IAppServiceBase<Modelo>
    {
        IEnumerable ObtemModeloPorNome(string pModelo);
        IEnumerable ObtemModeloPorFiltro(Modelo pModelo);
    }
}
