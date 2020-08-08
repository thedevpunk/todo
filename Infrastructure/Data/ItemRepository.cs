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
            var filter = Builders<Item>.Filter.Eq(i => i.Id, id);

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
            var filter = Builders<Item>.Filter.Eq(i => i.Id, item.Id);

            await _context.Items.ReplaceOneAsync(filter, item, new ReplaceOptions{ IsUpsert = true });
        }

        public async Task DeleteItemAsync(Guid id)
        {
            var filter = Builders<Item>.Filter.Eq(i => i.Id, id);

            await _context.Items.DeleteOneAsync(filter);
        }

        public async Task MarkItemAsDone(Guid id)
        {
            var filter = Builders<Item>.Filter.Eq(i => i.Id, id);
            var update = Builders<Item>.Update.Set(i => i.IsDone, true);
            await _context.Items.UpdateOneAsync(filter, update);
        }
    }
}