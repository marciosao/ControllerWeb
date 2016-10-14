using Domain.Entities;
using Domain.Interfaces.Services;
using Application.Interfaces;
using System.Collections.Generic;

namespace Application
{
    public class VendedorAppService : AppServiceBase<Vendedor>, IVendedorAppService
    {
        private readonly IVendedorService _vendedorService;

        public VendedorAppService(IVendedorService vendedorService) : base(vendedorService)
        {
            _vendedorService = vendedorService;
        }

        public Vendedor Login(Vendedor pUsuario)
        {
            //Criptografia.Criptografia c = new Criptografia.Criptografia();
            //string senha = c.Criptografar(pUsuario.Senha);

            var lVendedor = _vendedorService.Login(pUsuario);

            return lVendedor;
        }

        private bool Acesso(Vendedor pVendedor)
        {
            return true;
        }

        private bool Permissoes(Vendedor pVendedor)
        {
            return true;
        }
    }
}
