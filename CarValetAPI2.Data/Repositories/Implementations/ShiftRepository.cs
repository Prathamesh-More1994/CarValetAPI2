using CarValetAPI2.Data.Repositories.Interfaces;
using CarValetAPI2.Shared.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CarValetAPI2.Data.Repositories.Implementations
{
    public class ShiftRepository : IShiftRepository
    {
        //TODO: Make a seperate MongoDBContext
        private const string databaseName = "CarValetAPI";
        private const string collectionName = "Shift";

        private readonly IMongoCollection<Shift> ShiftCollection;
        private readonly FilterDefinitionBuilder<Shift> filterBuilder = Builders<Shift>.Filter;
        public ShiftRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            ShiftCollection = database.GetCollection<Shift>(collectionName);
        }

        public async Task CreateShiftAsync(Shift Shift)
        {
            await ShiftCollection.InsertOneAsync(Shift);
        }

        public async Task DeleteShiftAsync(string id)
        {
            var filter = filterBuilder.Eq(Shift => Shift.ShiftId, id);
            await ShiftCollection.DeleteOneAsync(filter);
        }

        public async Task<Shift> GetShiftById(string id)
        {
            var filter = filterBuilder.Eq(Shift => Shift.ShiftId, id);
            return await ShiftCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Shift>> GetShiftsAsync()
        {
            return await ShiftCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task UpdateShiftAsync(Shift Shift)
        {
            var filter = filterBuilder.Eq(existingShift => existingShift.ShiftId, Shift.ShiftId);
            await ShiftCollection.ReplaceOneAsync(filter, Shift);
        }
    }
}