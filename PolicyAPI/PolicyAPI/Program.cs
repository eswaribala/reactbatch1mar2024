using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PolicyAPI.Configurations;
using PolicyAPI.Contexts;
using PolicyAPI.Repositories;
using Steeltoe.Extensions.Configuration.ConfigServer;


var builder = WebApplication.CreateBuilder(args);
//add config server
builder.Configuration.AddConfigServer();



ConfigurationManager configuration = builder.Configuration;
// Add services to the container.

var Url = configuration["awsvaulturl"];
var RootKey = configuration["rootkey"];


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

IDictionary<string,object> result = new VaultConfiguration(configuration).GetSecrets(Url,RootKey).Result;
Console.WriteLine(result);
////connection string
SqlConnectionStringBuilder providerCs = new SqlConnectionStringBuilder();
providerCs.UserID = result["username"].ToString();
providerCs.Password = result["password"].ToString();
providerCs.InitialCatalog = configuration["dbName"];
providerCs.DataSource = configuration["trainerservername"];
providerCs.MultipleActiveResultSets = true;
providerCs.TrustServerCertificate = true;

builder.Services.AddDbContext<PolicyContext>(o =>
o.UseSqlServer(providerCs.ToString()));
//dependency injection
builder.Services.AddTransient<IPolicyHolderRepo, PolicyHolderRepo>();
builder.Services.AddTransient<IPolicyRepo, PolicyRepo>();

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

app.MapControllers();

app.Run();
