using CarValetAPI2.Data.Repositories.Interfaces;
using CarValetAPI2.Shared.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CarValetAPI2.Data.Repositories.Implementations
{
    public class AppointmentRepository : IAppointmentRepository
    {
        //TODO: Make a seperate MongoDBContext
        private const string databaseName = "CarValetAPI";
        private const string collectionName = "Appointment";

        private readonly IMongoCollection<Appointment> appointmentCollection;
        private readonly FilterDefinitionBuilder<Appointment> filterBuilder = Builders<Appointment>.Filter;
        public AppointmentRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            appointmentCollection = database.GetCollection<Appointment>(collectionName);
        }

        public async Task CreateAppointmentAsync(Appointment appointment)
        {
            await appointmentCollection.InsertOneAsync(appointment);
        }

        public async Task DeleteAppointmentAsync(string id)
        {
            var filter = filterBuilder.Eq(appointment => appointment.AppointmentId, id);
            await appointmentCollection.DeleteOneAsync(filter);
        }

        public async Task<Appointment> GetAppointmentById(string id)
        {
            var filter = filterBuilder.Eq(appointment => appointment.AppointmentId, id);
            return await appointmentCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsAsync()
        {
            return await appointmentCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task UpdateAppointmentAsync(Appointment appointment)
        {
            var filter = filterBuilder.Eq(existingAppointment => existingAppointment.AppointmentId, appointment.AppointmentId);
            await appointmentCollection.ReplaceOneAsync(filter, appointment);
        }
    }
}