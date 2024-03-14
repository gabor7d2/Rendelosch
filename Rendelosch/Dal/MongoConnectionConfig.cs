using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using Rendelosch.Repository;

namespace Bme.Swlab1.Mongo.Dal;

public static class MongoConnectionConfig
{
    public static void AddMongoConnection(this IServiceCollection services)
    {
        services.AddSingleton<IMongoClient>(serviceProvider =>
        {
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            var connectionString = Environment.GetEnvironmentVariable("MONGODB_URI");
            if (connectionString == null)
            {
                Console.WriteLine("MONGODB_URI environment variable is not set");
                Environment.Exit(0);
            }
            var client = new MongoClient(connectionString);
            return client;
        });

        services.AddSingleton(serviceProvider =>
        {
            var client = serviceProvider.GetRequiredService<IMongoClient>();
            
            return client.GetDatabase("rendelosch");
        });

        ConventionRegistry.Register(
            "MyConventions",
            new ConventionPack
            {
                new ElementNameConvention(),
            },
            filter: _ => true);
    }
}
