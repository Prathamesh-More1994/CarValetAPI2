using CarValetAPI2.Data.Repositories.Interfaces;
using CarValetAPI2.Shared.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CarValetAPI2.Data.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        //TODO: Make a seperate MongoDBContext
        private const string databaseName = "CarValetAPI";
        private const string collectionName = "Users";

        private readonly IMongoCollection<User> usersCollection;
        private readonly FilterDefinitionBuilder<User> filterBuilder = Builders<User>.Filter;
        public UserRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            usersCollection = database.GetCollection<User>(collectionName);
        }
        public async Task CreateUserAsync(User user)
        {
            user.CreatedDate = DateTime.Now;
            await usersCollection.InsertOneAsync(user);
        }

        public async Task DeleteUserAsync(string id)
        {
            var filter = filterBuilder.Eq(user => user.UserId, id);
            await usersCollection.DeleteOneAsync(filter);
        }

        public async Task<User> GetUserById(string id)
        {
            var filter = filterBuilder.Eq(user => user.UserId, id);
            return await usersCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await usersCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            var filter = filterBuilder.Eq(existingUser => existingUser.UserId, user.UserId);
            await usersCollection.ReplaceOneAsync(filter, user);
        }
    }
}