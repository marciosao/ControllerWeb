using Domain.Entities;
using Domain.Interfaces.Repositories;
using System.Linq;



namespace Infra.Data.Repositories
{
    public class VendedorRepository : RepositoryBase<Vendedor>,IVendedorRepository
    {
        public Vendedor Login(Vendedor pVendedor)
        {
            var lVendedor = Db.Vendedor.Where(x => x.Matricula == pVendedor.Matricula && x.Senha == pVendedor.Senha && x.Ativo == true).FirstOrDefault();

            return lVendedor;
        }
    }
}
