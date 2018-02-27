using System;

namespace CentricExpress.Business.Domain
{
    public abstract class Aggregate
    {
        protected Aggregate(Guid id)
        {
            this.Id = id;
        }

        protected Aggregate()
        {
        }

        public Guid Id { get; protected set; }
    }
}
