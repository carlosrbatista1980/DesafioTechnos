using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCore.Entities.Base
{
    public class EntityBase<TEntity, TPrimaryKey> : IEntityBase<TPrimaryKey>, IDisposable 
        where TEntity : EntityBase<TEntity, TPrimaryKey>
        where TPrimaryKey : struct
    {
        public TPrimaryKey Id { get; set; }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
