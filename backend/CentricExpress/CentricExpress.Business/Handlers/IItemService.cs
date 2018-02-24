using System.Collections.Generic;
using CentricExpress.Business.DTOs;

namespace CentricExpress.Business.Handlers
{
    public interface IItemService
    {
        IEnumerable<ItemDto> Get();

        ItemDetailsDto Get(string id);
    }
}
