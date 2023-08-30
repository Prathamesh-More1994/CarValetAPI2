using CarValetAPI2.Data.Repositories.Interfaces;
using CarValetAPI2.Shared.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CarValetAPI2.Data.Repositories.Implementations
{
    public class OwnerRepository : IOwnerRepository
    {
        //TODO: Make a seperate MongoDBContext
        private const string databaseName = "CarValetAPI";
        private const string collectionName = "Company";

        private readonly IMongoCollection<Owner> ownerCollection;
        private readonly FilterDefinitionBuilder<Owner> filterBuilder = Builders<Owner>.Filter;
        public OwnerRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            ownerCollection = database.GetCollection<Owner>(collectionName);
        }

        public async Task CreateOwnerAsync(Owner owner)
        {
            await ownerCollection.InsertOneAsync(owner);
        }

        public async Task DeleteOwnerAsync(string id)
        {
            var filter = filterBuilder.Eq(owner => owner.OwnerId, id);
            await ownerCollection.DeleteOneAsync(filter);
        }

        public async Task<Owner> GetOwnerById(string id)
        {
            var filter = filterBuilder.Eq(owner => owner.OwnerId, id);
            return await ownerCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Owner>> GetOwnersAsync()
        {
            var filter = new BsonDocument("_t", "Owner");
            return await ownerCollection.Find<Owner>(filter).ToListAsync();
        }

        public async Task UpdateOwnerAsync(Owner owner)
        {
            var filter = filterBuilder.Eq(existingOwner => existingOwner.OwnerId, owner.OwnerId);
            await ownerCollection.ReplaceOneAsync(filter, owner);
        }
    }
}