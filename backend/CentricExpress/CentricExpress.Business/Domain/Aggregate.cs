using System;

namespace CentricExpress.Business.Domain
{
    public abstract class Aggregate
    {
        public Guid Id { get; protected set; }
    }
}
