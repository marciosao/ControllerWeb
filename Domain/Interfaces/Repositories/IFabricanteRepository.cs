using Domain.Entities;
using System.Collections;
using System.Collections.Generic;

namespace Domain.Interfaces.Repositories
{
    public interface IFabricanteRepository : IRepositoryBase<Fabricante>
    {
        IEnumerable ObtemFabricantePorNome(string pFabricante);

        IEnumerable ObtemFabricantePorFiltro(Fabricante pFabricante);
    }
}
