using Domain.Entities;

namespace Application.Interfaces
{
    public interface IVendedorAppService : IAppServiceBase<Vendedor>
    {
        Vendedor Login(Vendedor pUsuario);
    }
}
