using CarValetAPI2.Data.Repositories.Interfaces;
using CarValetAPI2.Shared.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CarValetAPI2.Data.Repositories.Implementations
{
    public class WalletRepository : IWalletRepository
    {
        //TODO: Make a seperate MongoDBContext
        private const string databaseName = "CarValetAPI";
        private const string collectionName = "Wallet";

        private readonly IMongoCollection<Wallet> walletCollection;
        private readonly FilterDefinitionBuilder<Wallet> filterBuilder = Builders<Wallet>.Filter;
        public WalletRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            walletCollection = database.GetCollection<Wallet>(collectionName);
        }

        public async Task CreateWalletAsync(Wallet wallet)
        {
            await walletCollection.InsertOneAsync(wallet);
        }

        public async Task DeleteWalletAsync(string id)
        {
            var filter = filterBuilder.Eq(wallet => wallet.WalletId, id);
            await walletCollection.DeleteOneAsync(filter);
        }

        public async Task<Wallet> GetWalletById(string id)
        {
            var filter = filterBuilder.Eq(wallet => wallet.WalletId, id);
            return await walletCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Wallet>> GetWalletsAsync()
        {
            return await walletCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task UpdateWalletAsync(Wallet wallet)
        {
            var filter = filterBuilder.Eq(existingWallet => existingWallet.WalletId, wallet.WalletId);
            await walletCollection.ReplaceOneAsync(filter, wallet);
        }
    }
}