using Domain.Entities;
using System.Collections;

namespace Domain.Interfaces.Repositories
{
    public interface IModeloRepository : IRepositoryBase<Modelo>
    {
        IEnumerable ObtemModeloPorNome(string pModelo);

        IEnumerable ObtemModeloPorFiltro(Modelo pModelo);
    }
}
