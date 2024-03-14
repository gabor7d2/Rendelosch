using MongoDB.Bson;
using MongoDB.Driver;
using Rendelosch.Dal.Extensions;
using Rendelosch.Models;
using Rendelosch.Repository;

namespace Rendelosch.Dal.Repository;

public class MongoDbProductFormRepository : IProductFormRepository
{
    private readonly IMongoCollection<Entities.ProductForm> _productFormsCollection;
    private readonly IMongoCollection<Entities.Submission> _submissionsCollection;
    
    public MongoDbProductFormRepository(IMongoDatabase database)
    {

        _productFormsCollection = database.GetCollection<Entities.ProductForm>("productform");
        _submissionsCollection = database.GetCollection<Entities.Submission>("submission");

        //TODO only test, remove it
        _productFormsCollection.InsertOne(new Entities.ProductForm
        {
            Title = "teszt",
            Fields =
            [
                new Entities.Field()
                {
                    Key = "name",
                    Name = "Név"
                },

                new Entities.Field()
                {
                    Key = "alma",
                    Name = "Alma"
                }
            ]
        });
    }


    public List<ProductForm> GetProductForms()
    {
        var dbProductsForms =  _productFormsCollection.Find(p => true).ToList();
        return dbProductsForms.Select(p => new ProductForm
            {
                Id = p.Id.ToString(),
                Fields = p.Fields.ToFieldModelsList(),
                Title = p.Title
            }
        ).ToList();

    }

    public ProductForm? GetProductForm(string formId)
    {
        var dbProductsForm =  _productFormsCollection.Find(p => p.Id.ToString() == formId).FirstOrDefault();
        return new ProductForm
        {
            Id = dbProductsForm.Id.ToString(),
            Title = dbProductsForm.Title,
            Fields = dbProductsForm.Fields.ToFieldModelsList()
        };
    }

    public ProductForm CreateProductForm(string formTitle, List<Field> formFields)
    {
        throw new NotImplementedException();
    }

    public List<Submission>? GetSubmissionsForProductForm(string formId)
    {
        var dbSubmission = _submissionsCollection.Find(s => s.FormId.ToString() == formId).ToList();
        return dbSubmission.Select(s => new Submission
            {
                Id = s.Id.ToString(),
                FormId = formId,
                FieldData = s.FieldData
            }
        ).ToList();
    }

    public void AddSubmissionToProductForm(string formId, Dictionary<string, string> fieldData)
    {
        if( _productFormsCollection.Find(p => p.Id.ToString() == formId).FirstOrDefault() is null ) return;


        var submission = new Entities.Submission
        {
            FieldData = fieldData,
            FormId = ObjectId.Parse(formId)
        };
        _submissionsCollection.InsertOne(submission);
        //return submission;
    }
}