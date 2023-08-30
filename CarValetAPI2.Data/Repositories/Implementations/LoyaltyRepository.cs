using CarValetAPI2.Data.Repositories.Interfaces;
using CarValetAPI2.Shared.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CarValetAPI2.Data.Repositories.Implementations
{
    public class LoyaltyRepository : ILoyaltyRepository
    {
        //TODO: Make a seperate MongoDBContext
        private const string databaseName = "CarValetAPI";
        private const string collectionName = "Loyalty";

        private readonly IMongoCollection<Loyalty> loyaltyCollection;
        private readonly FilterDefinitionBuilder<Loyalty> filterBuilder = Builders<Loyalty>.Filter;
        public LoyaltyRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            loyaltyCollection = database.GetCollection<Loyalty>(collectionName);
        }

        public async Task CreateLoyaltyAsync(Loyalty loyalty)
        {
            await loyaltyCollection.InsertOneAsync(loyalty);
        }

        public async Task DeleteLoyaltyAsync(string id)
        {
            var filter = filterBuilder.Eq(loyalty => loyalty.LoyaltyId, id);
            await loyaltyCollection.DeleteOneAsync(filter);
        }

        public async Task<Loyalty> GetLoyaltyById(string id)
        {
            var filter = filterBuilder.Eq(loyalty => loyalty.LoyaltyId, id);
            return await loyaltyCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Loyalty>> GetLoyaltysAsync()
        {
            return await loyaltyCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task UpdateLoyaltyAsync(Loyalty loyalty)
        {
            var filter = filterBuilder.Eq(existingLoyalty => existingLoyalty.LoyaltyId, loyalty.LoyaltyId);
            await loyaltyCollection.ReplaceOneAsync(filter, loyalty);
        }
    }
}