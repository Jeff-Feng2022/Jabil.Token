using StackExchange.Redis.Extensions.Core.Configuration;
using StackExchange.Redis.Extensions.Newtonsoft;
using Microsoft.Extensions.Configuration;


var builder = WebApplication.CreateBuilder(args);
 


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();



//var redisConfiguration = builder.Configuration.GetSection("Redis").Get<RedisConfiguration>();

//builder.Services.AddStackExchangeRedisExtensions<NewtonsoftSerializer>(redisConfiguration);


var app = builder.Build();
app.UseHealthChecks("/healthcheck");


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