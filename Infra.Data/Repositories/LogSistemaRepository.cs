using Domain.Entities;
using Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System;
using Infra.Data.Models;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;

namespace Infra.Data.Repositories
{
    public class LogSistemaRepository : RepositoryBase<LogSistema>, ILogSistemaRepository
    {

    }
}
