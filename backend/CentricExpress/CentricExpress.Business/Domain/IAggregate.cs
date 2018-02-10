using System;

namespace CentricExpress.Business.Domain
{
    public interface IAggregate
    {
        Guid Id { get; set; }
    }
}
