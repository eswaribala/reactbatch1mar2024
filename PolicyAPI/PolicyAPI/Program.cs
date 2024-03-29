using Microsoft.Data.SqlClient;
using PolicyAPI.Configurations;
using Steeltoe.Extensions.Configuration.ConfigServer;

var builder = WebApplication.CreateBuilder(args);
//add config server
builder.Configuration.AddConfigServer();



ConfigurationManager configuration = builder.Configuration;
// Add services to the container.

var Url = configuration["url"];
var RootKey = configuration["rootkey"];


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var result = new VaultConfiguration(configuration).GetSecrets(Url,RootKey).Result;
//connection string
SqlConnectionStringBuilder providerCs = new SqlConnectionStringBuilder();
providerCs.UserID = result["username"].ToString();
providerCs.Password = result["password"].ToString();
//providerCs.InitialCatalog = "NovacPolicyDB";


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
