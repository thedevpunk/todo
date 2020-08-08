using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IItemRepository
    {
         Task<Item> GetItemByGuidAsync(Guid guid);

         Task<IReadOnlyList<Item>> GetItemsAsync();

         Task CreateItemAsync(Item item);

         Task UpdateItemAsync(Item item);
    }
}