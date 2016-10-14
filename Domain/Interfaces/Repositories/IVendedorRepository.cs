using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IVendedorRepository : IRepositoryBase<Vendedor>
    {
        Vendedor Login(Vendedor pVendedor);
    }
}
