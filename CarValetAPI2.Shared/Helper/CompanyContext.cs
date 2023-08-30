using MongoDB.Driver;
using CarValetAPI2.Shared.Dtos;

namespace CarValetAPI2.Shared.Helper
{
    public class CompanyContext
    {
        private const string databaseName = "CarValetAPI";
        private const string collectionName = "Company";

        private readonly IMongoDatabase _database;

        public CompanyContext(IMongoClient mongoClient)
        {
            _database = mongoClient.GetDatabase(databaseName);
        }

        // public List<MongoEntity> Get()
        // {
        //     var owner = _database.GetCollection<Owner>("Company");
        //     var company = _database.GetCollection<Company>("Company");
        //     var service = _database.GetCollection<Service>("Company");
        //     //var categories = _database.GetCollection<Category>("Books");
        //     var collection = _database.GetCollection<MongoEntity>("Company");
        //     return collection.Find(company => true).ToList();
        // }

        public void AddBsonDocument(CompanyDto companyDto)
        {
            var company = Mapper.GetCompanyFromDto(companyDto);
            var owner = Mapper.GetOwnerFromDto(companyDto);
            var service = Mapper.GetServiceFromDto(companyDto);

            var collection = _database.GetCollection<MongoEntity>("Company");

            var list = new List<MongoEntity> { company, owner };
            service?.ForEach(x => list.Add(x));

            collection.InsertMany(list);

        }
    }
}