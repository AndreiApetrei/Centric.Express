using System;
using System.Collections.Generic;
using CentricExpress.Business.DTOs;

namespace CentricExpress.Business.Services
{
    public interface IItemService
    {
        IEnumerable<ItemDto> Get();

        ItemDetailsDto Get(Guid id);
    }
}
