using Domain.Entities;
using Domain.Interfaces.Repositories;
using System.Collections;
using System.Linq;
using System;

namespace Infra.Data.Repositories
{
    public class ModeloRepository : RepositoryBase<Modelo>,IModeloRepository
    {
        public IEnumerable ObtemModeloPorFiltro(Modelo pModelo)
        {
            string lNome = null;
            if (!string.IsNullOrEmpty(pModelo.Nome))
            {
                lNome = pModelo.Nome;
            }

            int? lId = null;
            if (pModelo.IdModelo > 0)
            {
                lId = pModelo.IdModelo;
            }

            var lListaModelos = (from mode in Db.MODELO
                                     where (mode.IdModelo == lId || lId == null) &&
                                     (mode.Nome.Contains(lNome) || lNome == null)
                                     select mode).ToList();

            return lListaModelos;
        }

        public IEnumerable ObtemModeloPorNome(string pModelo)
        {
            var lModelo = Db.MODELO.Where(x => x.Nome.StartsWith(pModelo)).ToList();

            return lModelo;
        }
    }
}
