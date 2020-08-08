using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IItemRepository
    {
         Task<Item> GetItemByIdAsync(Guid id);

         Task<IReadOnlyList<Item>> GetItemsAsync();

         Task CreateItemAsync(Item item);

         Task UpdateItemAsync(Item item);

         Task DeleteItemAsync(Guid id);
    }
}