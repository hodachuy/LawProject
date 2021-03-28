using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Domain.Common
{
    public abstract class EntityBaseWithTypeId<TId> : IEntityWithTypeId<TId>
    {
        public virtual TId Id { get; protected set; }
    }
}
