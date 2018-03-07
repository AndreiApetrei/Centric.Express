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

        void Delete(Guid id);

        ItemDto Update(Guid id, ItemDto itemDto);
    }
}
