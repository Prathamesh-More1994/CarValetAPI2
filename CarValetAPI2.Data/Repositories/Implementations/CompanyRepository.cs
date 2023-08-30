using CarValetAPI2.Data.Repositories.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using CarValetAPI2.Shared.Dtos;
using CarValetAPI2.Shared.Helper;
using CarValetAPI2.Shared.Models;

namespace CarValetAPI2.Data.Repositories.Implementations
{
    public class CompanyRepository : ICompanyRepository
    {
        //TODO: Make a seperate MongoDBContext
        private const string databaseName = "CarValetAPI";
        private const string collectionName = "Company";

        private readonly IMongoCollection<Company> companyCollection;
        private readonly IMongoCollection<MongoEntity> mongoEntityCollection;
        private readonly FilterDefinitionBuilder<Company> filterBuilder = Builders<Company>.Filter;
        public CompanyRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            companyCollection = database.GetCollection<Company>(collectionName);
            mongoEntityCollection = database.GetCollection<MongoEntity>(collectionName);
        }

        public async Task CreateCompanyAsync(Company company)
        {
            await companyCollection.InsertOneAsync(company);
        }


        public async Task CreateCompanyDemoAsync(CompanyDto companyDto)
        {
            var company = Mapper.GetCompanyFromDto(companyDto);
            var owner = Mapper.GetOwnerFromDto(companyDto);
            var service = Mapper.GetServiceFromDto(companyDto);

            //var collection = _database.GetCollection<MongoEntity>("Company");

            var list = new List<MongoEntity> { company, owner };
            service?.ForEach(x => list.Add(x));

            await mongoEntityCollection.InsertManyAsync(list);
        }

        public async Task DeleteCompanyAsync(string id)
        {
            var filter = filterBuilder.Eq(company => company.CompanyId, id);
            await companyCollection.DeleteOneAsync(filter);
        }

        public async Task<IEnumerable<Company>> GetCompaniesByLocationAsync(Location location)
        {
            var filter = new BsonDocument("_t", collectionName);
            return await companyCollection.Find<Company>(filter).ToListAsync();
        }

        public async Task<Company> GetCompanyById(string id)
        {
            var filter = filterBuilder.Eq(company => company.CompanyId, id);
            return await companyCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Company>> GetCompanysAsync()
        {
            var filter = new BsonDocument("_t", collectionName);
            return await companyCollection.Find<Company>(filter).ToListAsync();
        }

        public async Task UpdateCompanyAsync(Company company)
        {
            var filter = filterBuilder.Eq(existingCompany => existingCompany.CompanyId, company.CompanyId);
            await companyCollection.ReplaceOneAsync(filter, company);
        }
    }
}