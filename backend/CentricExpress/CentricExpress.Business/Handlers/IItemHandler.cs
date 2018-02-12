using System.Collections.Generic;
using CentricExpress.Business.DTOs;

namespace CentricExpress.Business.Handlers
{
    public interface IItemHandler
    {
        IEnumerable<ItemDetailsDto> Get();
    }
}
