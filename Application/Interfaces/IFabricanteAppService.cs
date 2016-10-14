using Domain.Entities;
using System.Collections;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IFabricanteAppService : IAppServiceBase<Fabricante>
    {
        IEnumerable ObtemFabricantePorNome(string pFabricante);

        IEnumerable ObtemFabricantePorFiltro(Fabricante pFabricante);
    }
}
