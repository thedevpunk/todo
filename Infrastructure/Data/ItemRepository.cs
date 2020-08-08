using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Infrastructure.Data
{
    public class ItemRepository : IItemRepository
    {
        private readonly TodoContext _context;

        public ItemRepository(TodoContext context)
        {
            _context = context;

        }

        public async Task<Item> GetItemByIdAsync(Guid id)
        {
            var filter = Builders<Item>.Filter.Eq("Id", id);

            return await _context.Items.FindSync(filter).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<Item>> GetItemsAsync()
        {
            return await _context.Items.FindSync(new BsonDocument()).ToListAsync();
        }

        public async Task CreateItemAsync(Item item)
        {
            await _context.Items.InsertOneAsync(item);
        }

        public async Task UpdateItemAsync(Item item)
        {
            await _context.Items.ReplaceOneAsync(doc => doc.Id == item.Id, item, new ReplaceOptions{ IsUpsert = true });
        }

        public async Task DeleteItemAsync(Guid id)
        {
            var filter = Builders<Item>.Filter.Eq("Id", id);

            await _context.Items.DeleteOneAsync(filter);
        }
    }
}