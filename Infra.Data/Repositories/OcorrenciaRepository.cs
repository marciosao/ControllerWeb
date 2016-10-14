using System;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using System.Collections.Generic;
using Infra.Data.Models;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Collections.Generic;
namespace Infra.Data.Repositories
{
    public class OcorrenciaRepository : RepositoryBase<Ocorrencia>, IOcorrenciaRepository
    {
        public IEnumerable<Ocorrencia> ObtemOcorrenciaOrdenado()
        {
            int lAnoReferencia = DateTime.Now.Year - 1;
            var lListaOcorrencias = (from o in Db.OCORRENCIA
                                     where o.DataOcorrencia.Year >= lAnoReferencia
                                     select o).OrderBy(x => x.DataOcorrencia).ToList();

            return lListaOcorrencias;
        }

        public IEnumerable<Ocorrencia> ObtemOcorrenciaPorFiltroOrdenado(Ocorrencia pOcorrencia)
        {
            string lTipoEvento = null;
            if (!string.IsNullOrEmpty(pOcorrencia.TipoEvento))
            {
                lTipoEvento = pOcorrencia.TipoEvento;
            }

            int? lIdVendedor = null;
            if (pOcorrencia.IdUsuario > 0)
            {
                lIdVendedor = pOcorrencia.IdUsuario;
            }

            DateTime? lDataOcorrencia = null;
            if (pOcorrencia.DataOcorrencia != null && !pOcorrencia.DataOcorrencia.Date.ToShortDateString().Equals("01/01/0001"))
            {
                lDataOcorrencia = pOcorrencia.DataOcorrencia;
            }
            int lAnoReferencia = DateTime.Now.Year - 1;
            var lListaOcorrencias = (from o in Db.OCORRENCIA
                                     where o.DataOcorrencia.Year >= lAnoReferencia &&
                                     (o.IdUsuario == lIdVendedor || lIdVendedor == null) &&
                                     (o.TipoEvento == lTipoEvento || lTipoEvento == null) &&
                                     (o.DataOcorrencia >= lDataOcorrencia || lDataOcorrencia == null)
                                     select o).OrderByDescending(x => x.DataOcorrencia).ToList();

            return lListaOcorrencias;
        }
    }
}
