using System;
using System.Collections.Generic;

using CentricExpress.Business.DTOs;

namespace CentricExpress.Business.Services
{
    public interface IItemService
    {
        IList<ItemDto> Get();

        ItemDto Get(Guid id);

        Guid Add(ItemDto itemDto);

        ItemDto Update(Guid id, ItemDto itemDto);

        void Delete(Guid id);
    }
}
