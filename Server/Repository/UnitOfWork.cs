using BlazorAspNetFactory.Server.IRepository;
using BlazorAspNetFactory.Shared.Data;
using BlazorAspNetFactory.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorAspNetFactory.Shared.Models;
using Microsoft.AspNetCore.Http;

namespace BlazorAspNetFactory.Server.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TestedbContext _context;
        private  IGenericRepository<Teste1> _teste1Repositor;

        public UnitOfWork(TestedbContext context)
        {
            _context = context;
        }
        public IGenericRepository<Teste1> Teste1Repository 
            => _teste1Repositor ??= new GenericRepository<Teste1>(_context);
        //public IGenericRepository<Teste2> Teste2Repository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
