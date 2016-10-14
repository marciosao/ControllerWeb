using Domain.Entities;

namespace Domain.Interfaces.Services
{
    public interface IVendedorService : IServiceBase<Vendedor>
    {
        Vendedor Login(Vendedor pVendedor);
    }
}
