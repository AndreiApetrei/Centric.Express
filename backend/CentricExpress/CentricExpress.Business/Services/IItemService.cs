using System;
using System.Collections.Generic;
using CentricExpress.Business.DTOs;

namespace CentricExpress.Business.Services
{
    public interface IItemService
    {
        IList<ItemDto> Get();

        ItemDetailsDto Get(Guid id);

        Guid Insert(ItemDto itemDto);
    }
}
