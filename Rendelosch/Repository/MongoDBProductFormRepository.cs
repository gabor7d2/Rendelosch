using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using Rendelosch.Models;

namespace Rendelosch.Repository;

public class MongoDBProductFormRepository : IProductFormRepository
{
    private readonly IMongoCollection<ProductForm> productFormsCollection;
    private readonly IMongoCollection<Submission> submissionsCollection;
    
    public MongoDBProductFormRepository()
    {
        var connectionString = Environment.GetEnvironmentVariable("MONGODB_URI");
        if (connectionString == null)
        {
            Console.WriteLine("MONGODB_URI environment variable is not set");
            Environment.Exit(0);
        }

        var client = new MongoClient(connectionString);
        //ConventionRegistry.Register("CamelCase",
       //     new ConventionPack { new CamelCaseElementNameConvention() }, _ => true);

        var database = client.GetDatabase("rendelosch");
        productFormsCollection = database.GetCollection<ProductForm>("productForms");
        submissionsCollection = database.GetCollection<Submission>("submissions");

        //var productForm = productFormsCollection.Find(c => c.Id == new ObjectId("c9d52472-9263-4610-93ca-ce16ba02c4d")).First();

        productFormsCollection.InsertOne(new ProductForm(Guid.NewGuid().ToString(), "asd", new List<Field>
        {
            new("name", "Név")
        }));
    }


    public List<ProductForm> GetProductForms()
    {
        return productFormsCollection.Find(p => true).ToList();
        
    }

    public ProductForm? GetProductForm(string formId)
    {
        return productFormsCollection.Find(p => p.Id == formId).FirstOrDefault();
    }

    public ProductForm CreateProductForm(string formTitle, List<Field> formFields)
    {
        throw new NotImplementedException();
    }

    public List<Submission>? GetSubmissionsForProductForm(string formId)
    {
        throw new NotImplementedException();
    }

    public Submission? AddSubmissionToProductForm(string formId, Dictionary<string, string> fieldData)
    {
        throw new NotImplementedException();
    }
}