using System;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public class LogSistemaService : ServiceBase<LogSistema>,ILogSistemaService
    {
        private readonly ILogSistemaRepository _logSistemaRepository;

        public LogSistemaService(ILogSistemaRepository logSistemaRepository)
            : base(logSistemaRepository)
        {
            _logSistemaRepository = logSistemaRepository;
        }
    }
}

