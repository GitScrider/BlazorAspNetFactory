using BlazorAspNetFactory.Shared.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAspNetFactory.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {

        Task Save();
        IGenericRepository<Teste1> Teste1Repository { get;}
        //IGenericRepository<Teste2> Teste2Repository { get; set; }

    }
}
