using MongoDB.Driver;
using Rendelosch.Models;

namespace Rendelosch.Repository;

public class MongoDBProductFormRepository : IProductFormRepository
{

    public MongoDBProductFormRepository()
    {
        var connectionString = Environment.GetEnvironmentVariable("MONGODB_URI");
        if (connectionString == null)
        {
            Console.WriteLine("MONGODB_URI environment variable is not set");
            Environment.Exit(0);
        }
        
        var client = new MongoClient(connectionString);

        var database = client.GetDatabase("rendelosch");
        var productFormsCollection = database.GetCollection<ProductForm>("productForms");
        var submissionsCollection = database.GetCollection<Submission>("submissions");

        var productForm = productFormsCollection.Find(c => c.Id == "c9d52472-9263-4610-93ca-ce16ba02c4d7").First();

        Console.WriteLine("Product Form: " + productForm);
    }
    
    
    public List<ProductForm> GetProductForms()
    {
        throw new NotImplementedException();
    }

    public ProductForm? GetProductForm(string formId)
    {
        throw new NotImplementedException();
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