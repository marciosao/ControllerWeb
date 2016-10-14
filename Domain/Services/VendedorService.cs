using System;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public class VendedorService : ServiceBase<Vendedor>, IVendedorService
    {
        private readonly IVendedorRepository _vendedorRepository;

        public VendedorService(IVendedorRepository vendedorRepository): base(vendedorRepository)
        {
            _vendedorRepository = vendedorRepository;
        }

        public Vendedor Login(Vendedor pVendedor)
        {
            return _vendedorRepository.Login(pVendedor);
        }
    }
}
