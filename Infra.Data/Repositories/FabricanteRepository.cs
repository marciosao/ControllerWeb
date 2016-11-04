using System;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using System.Collections;
using System.Linq;

namespace Infra.Data.Repositories
{
    public class FabricanteRepository : RepositoryBase<Fabricante>, IFabricanteRepository
    {
        public IEnumerable ObtemFabricantePorFiltro(Fabricante pFabricante)
        {
            string lNome = null;
            if (!string.IsNullOrEmpty(pFabricante.Nome))
            {
                lNome = pFabricante.Nome;
            }

            int? lId = null;
            if (pFabricante.IdFabricante > 0)
            {
                lId = pFabricante.IdFabricante;
            }

            var lListaFabricantes = (from fbr in Db.FABRICANTE
                                  where (fbr.IdFabricante == lId || lId == null) &&
                                  (fbr.Nome.Contains(lNome) || lNome == null)
                                  select fbr).ToList();

            return lListaFabricantes;
        }

        //public Fabricante ObtemFabricantePorFiltro(Fabricante pFabricante)
        //{
        //    string lNome = null;
        //    if (!string.IsNullOrEmpty(pFabricante.Nome))
        //    {
        //        lNome = pFabricante.Nome;
        //    }

        //    int? lId = null;
        //    if (pFabricante.IdFabricante > 0)
        //    {
        //        lId = pFabricante.IdFabricante;
        //    }

        //    var lListaFabricantes = (from fbr in Db.FABRICANTE
        //                             where (fbr.IdFabricante == lId || lId == null) &&
        //                             (fbr.Nome.Contains(lNome) || lNome == null)
        //                             select fbr).ToList();

        //    return lListaFabricantes;
        //}

        public IEnumerable ObtemFabricantePorNome(string pFabricante)
        {
            var lFabricante = Db.FABRICANTE.Where(x => x.Nome.StartsWith(pFabricante)).ToList();

            return lFabricante;
        }
    }
}
