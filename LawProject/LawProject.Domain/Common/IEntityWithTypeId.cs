using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Domain.Common
{
    public interface IEntityWithTypeId<TId>
    {
        TId Id { get;}
    }
}
