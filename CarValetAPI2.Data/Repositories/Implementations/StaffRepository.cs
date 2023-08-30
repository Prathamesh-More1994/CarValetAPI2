using CarValetAPI2.Data.Repositories.Interfaces;
using CarValetAPI2.Shared.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CarValetAPI2.Data.Repositories.Implementations
{
    public class StaffRepository : IStaffRepository
    {
        //TODO: Make a seperate MongoDBContext
        private const string databaseName = "CarValetAPI";
        private const string collectionName = "Staff";
        private const string collection2Name = "Company";

        private readonly IMongoCollection<Staff> staffCollection;

        private readonly FilterDefinitionBuilder<Staff> filterBuilder = Builders<Staff>.Filter;
        public StaffRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            staffCollection = database.GetCollection<Staff>(collectionName);

        }

        public async Task CreateStaffAsync(Staff staff)
        {
            await staffCollection.InsertOneAsync(staff);
        }

        public async Task DeleteStaffAsync(string id)
        {
            var filter = filterBuilder.Eq(staff => staff.StaffId, id);
            await staffCollection.DeleteOneAsync(filter);
        }

        public async Task<List<Staff>> GetStaffByCompanyId(string companyId)
        {
            var filter = filterBuilder.Eq(staff => staff.CompanyId, companyId);
            return await staffCollection.Find(filter).ToListAsync();
        }

        public async Task<Staff> GetStaffById(string id)
        {
            var filter = filterBuilder.Eq(staff => staff.StaffId, id);
            return await staffCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Staff>> GetStaffsAsync()
        {
            return await staffCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task UpdateStaffAsync(Staff staff)
        {
            var filter = filterBuilder.Eq(existingStaff => existingStaff.StaffId, staff.StaffId);
            await staffCollection.ReplaceOneAsync(filter, staff);
        }
    }
}