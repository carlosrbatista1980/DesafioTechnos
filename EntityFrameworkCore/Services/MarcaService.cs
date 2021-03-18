using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityFrameworkCore.Entities;
using EntityFrameworkCore.Services.Base;

namespace EntityFrameworkCore.Services
{
    public class MarcaService : ServiceBase
    {
        public List<Marca> GetMarcas()
        {
            return _context.Marca.ToList();
        }
    }
}
