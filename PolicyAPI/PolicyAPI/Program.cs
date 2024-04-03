using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PolicyAPI.Configurations;
using PolicyAPI.Contexts;
using PolicyAPI.Repositories;
using Steeltoe.Extensions.Configuration.ConfigServer;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Steeltoe.Extensions.Configuration;
using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;
using System.Text.Json;
using PolicyAPI.Schemas;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;

var builder = WebApplication.CreateBuilder(args);
//step to add config server
builder.Configuration.AddConfigServer();
ConfigurationManager configuration = builder.Configuration;
var Url = configuration["awsvaulturl"].ToString();
var RootKey = configuration["rootkey"].ToString();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


//IDictionary<string,Object> result = new VaultConfiguration(configuration)
 //   .GetSecrets(RootKey,Url).Result;
SqlConnectionStringBuilder providerCs 
    = new SqlConnectionStringBuilder();
providerCs.UserID = "sa";
providerCs.Password = "Vignesh@95";
//providerCs.Password = "Vignesh@95";
//providerCs.DataSource = configuration["trainerservername"];
providerCs.DataSource = "34.201.251.242,1403";
providerCs.InitialCatalog = "PolicyDb";
providerCs.MultipleActiveResultSets = true;
providerCs.TrustServerCertificate = true;

builder.Services.AddDbContext<PolicyContext>(o =>
o.UseSqlServer(providerCs.ToString()));

builder.Services.AddTransient<IPolicyHolderRepo, PolicyHolderRepo>();

builder.Services.AddTransient<IPolicyRepo, PolicyRepo>();

builder.Services.AddTransient<IAddressRepo, AddressRepo>();

builder.Services.AddTransient<IVehicleRepo, VehicleRepo>();

builder.Services.AddEndpointsApiExplorer();



builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "PolicyAPI", Version = "v1" });
});
builder.Services.AddApiVersioning(opt =>
{
    opt.DefaultApiVersion = new ApiVersion(1, 0);
    opt.AssumeDefaultVersionWhenUnspecified = true;
    opt.ReportApiVersions = true;
    opt.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                                                    new HeaderApiVersionReader("x-api-version"),
                                                    new MediaTypeApiVersionReader("x-api-version"));
});

builder.Services.AddVersionedApiExplorer(setup =>
{
    setup.GroupNameFormat = "'v'VVV";
    setup.SubstituteApiVersionInUrl = true;
});
var policyName = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policyName,
                      builder =>
                      {
                          builder
                             .WithOrigins("http://localhost:*", "")
                             //.WithOrigins("http://localhost:3000")
                             // specifying the allowed origin
                             // .WithMethods("GET") // defining the allowed HTTP method
                             .AllowAnyOrigin()
                             // .WithHeaders(HeaderNames.ContentType, "ApiKey")
                             .AllowAnyMethod()
                            .AllowAnyHeader(); // allowing any header to be sent
                      });
});

builder.Services.AddScoped<PolicySchema>();

builder.Services.AddGraphQL()
               .AddSystemTextJson()
               .AddGraphTypes(typeof(PolicySchema), ServiceLifetime.Scoped);




var app = builder.Build();
var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                description.GroupName.ToUpperInvariant());
        }
    });
}
app.UseGraphQL<PolicySchema>();
app.UseGraphQLPlayground(options: new PlaygroundOptions());
app.UseHttpsRedirection();
app.UseCors(policyName);

app.UseAuthorization();

app.MapControllers();

app.Run();
