using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson;
using MongoDB.Driver;
using Stripe;
using CarValetAPI2.Data.Repositories.Interfaces;
using CarValetAPI2.Data.Repositories.Implementations;
using CarValetAPI2.Application.Application.Interfaces;
using CarValetAPI2.Application.Application.Implementations;
using CarValetAPI2.Data.Settings;

var builder = WebApplication.CreateBuilder(args);

//mongoDb settings
BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
BsonSerializer.RegisterSerializer(new DateTimeSerializer(BsonType.String));
StripeConfiguration.ApiKey = "sk_test_51L3qbKLEKLTwHLbQVIk7YRFgIsW0bCz593j5ERFsxILjfpWoVJboQZ1Gj0D3swVti8F9Po2PKbP97FUttBKaknlA00gq6W9Vyn";
var mongoDbSettings = builder.Configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();
builder.Services.AddSingleton<IMongoClient>(serviceProvider =>
{
    return new MongoClient(mongoDbSettings.ConnectionString);
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
                      {
                          builder.WithOrigins("http://localhost:4200", "http://localhost:4200/")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials()
                          .WithMethods("POST", "PUT", "DELETE", "GET");
                      });
});
// Add services to the container.
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IUserApplication, UserApplication>();
builder.Services.AddSingleton<IPaymentIntentRepository, PaymentIntentRepository>();
builder.Services.AddSingleton<IPaymentIntentApplication, PaymentIntentApplication>();
builder.Services.AddSingleton<IOwnerRepository, OwnerRepository>();
builder.Services.AddSingleton<IOwnerApplication, OwnerApplication>();
builder.Services.AddSingleton<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddSingleton<IAppointmentApplication, AppointmentApplication>();
builder.Services.AddSingleton<ICompanyRepository, CompanyRepository>();
builder.Services.AddSingleton<ICompanyApplication, CompanyApplication>();
builder.Services.AddSingleton<IStaffRepository, StaffRepository>();
builder.Services.AddSingleton<IStaffApplication, StaffApplication>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IUserApplication, UserApplication>();
builder.Services.AddSingleton<IWalletRepository, WalletRepository>();
builder.Services.AddSingleton<IWalletApplication, WalletApplication>();
builder.Services.AddSingleton<ILoyaltyRepository, LoyaltyRepository>();
builder.Services.AddSingleton<ILoyaltyApplication, LoyaltyApplication>();
builder.Services.AddSingleton<IShiftRepository, ShiftRepository>();
builder.Services.AddSingleton<IShiftApplication, ShiftApplication>();
builder.Services.AddControllers();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();
