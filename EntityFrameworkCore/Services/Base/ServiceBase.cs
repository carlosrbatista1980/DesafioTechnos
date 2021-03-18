using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.Data;

namespace EntityFrameworkCore.Services.Base
{
    public class ServiceBase : IServiceBase
    {
        protected readonly TechnosContext _context;

        public ServiceBase()
        {
            _context = new TechnosContextFactory().CreateDbContext(Array.Empty<string>());
        }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
