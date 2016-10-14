using Domain.Entities;
using Domain.Interfaces.Services;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application
{
    public class LogSistemaAppService : AppServiceBase<LogSistema>,ILogSistemaAppService
    {
        private readonly ILogSistemaService _logSistemaService;

        public LogSistemaAppService(ILogSistemaService logSistemaService) : base(logSistemaService)
        {
            _logSistemaService = logSistemaService;
        }
    }
}
