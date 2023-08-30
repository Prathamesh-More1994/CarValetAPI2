using CarValetAPI2.Data.Repositories.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using CarValetAPI2.Shared.Models;

namespace CarValetAPI2.Data.Repositories.Implementations
{
    public class PaymentIntentRepository : IPaymentIntentRepository
    {
        //TODO: Make a seperate MongoDBContext
        private const string databaseName = "CarValetAPI";
        private const string collectionName = "Payment";

        private readonly IMongoCollection<Payment> paymentCollection;
        private readonly FilterDefinitionBuilder<Payment> filterBuilder = Builders<Payment>.Filter;
        public PaymentIntentRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            paymentCollection = database.GetCollection<Payment>(collectionName);
        }

        public async Task CreatePaymentAsync(Payment payment)
        {
            payment.CreatedDate = DateTime.Now;
            await paymentCollection.InsertOneAsync(payment);
        }

        public async Task<Payment> GetPaymentById(string id)
        {
            var filter = filterBuilder.Eq(payment => payment.PaymentId, id);
            return await paymentCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Payment>> GetPaymentsAsync()
        {
            return await paymentCollection.Find(new BsonDocument()).ToListAsync();
        }
    }
}