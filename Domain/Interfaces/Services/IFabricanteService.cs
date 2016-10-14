using Domain.Entities;
using System.Collections;
using System.Collections.Generic;

namespace Domain.Interfaces.Services
{
    public interface IFabricanteService : IServiceBase<Fabricante>
    {
        IEnumerable ObtemFabricantePorNome(string pFabricante);

        IEnumerable ObtemFabricantePorFiltro(Fabricante pFabricante);
    }
}
