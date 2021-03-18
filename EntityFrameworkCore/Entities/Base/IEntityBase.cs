using System;
using System.Collections.Generic;

namespace EntityFrameworkCore.Entities.Base
{
    public interface IEntityBase<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
    }
}