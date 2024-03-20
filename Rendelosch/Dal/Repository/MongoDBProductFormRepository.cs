using MongoDB.Bson;
using MongoDB.Driver;
using Rendelosch.Dal.Extensions;
using Rendelosch.Models;
using Rendelosch.Repository;

namespace Rendelosch.Dal.Repository;

public class MongoDbProductFormRepository : IProductFormRepository
{
    private readonly IMongoCollection<Entities.ProductFormDto> _productFormsCollection;
    private readonly IMongoCollection<Entities.SubmissionDto> _submissionsCollection;
    
    public MongoDbProductFormRepository(IMongoDatabase database)
    {

        _productFormsCollection = database.GetCollection<Entities.ProductFormDto>("productform");
        _submissionsCollection = database.GetCollection<Entities.SubmissionDto>("submission");

        //TODO only test, remove it
        _productFormsCollection.InsertOne(new Entities.ProductFormDto
        {
            Title = "teszt",
            Fields =
            [
                new Entities.FieldDto()
                {
                    Key = "name",
                    Name = "Név"
                },

                new Entities.FieldDto()
                {
                    Key = "alma",
                    Name = "Alma"
                }
            ]
        });
    }


    public List<ProductFormModel> GetProductForms()
    {
        var dbProductsForms =  _productFormsCollection.Find(p => true).ToList();
        return dbProductsForms.Select(p => new ProductFormModel
            {
                Id = p.Id.ToString(),
                Fields = p.Fields.ToFieldModelsList(),
                Title = p.Title
            }
        ).ToList();

    }

    public ProductFormModel? GetProductForm(string formId)
    {
        var dbProductsForm =  _productFormsCollection.Find(p => p.Id.ToString() == formId).FirstOrDefault();
        return new ProductFormModel
        {
            Id = dbProductsForm.Id.ToString(),
            Title = dbProductsForm.Title,
            Fields = dbProductsForm.Fields.ToFieldModelsList()
        };
    }

    public ProductFormModel CreateProductForm(string formTitle, List<FieldModel> formFields)
    {
        throw new NotImplementedException();
    }

    public List<SubmissionModel>? GetSubmissionsForProductForm(string formId)
    {
        var dbSubmission = _submissionsCollection.Find(s => s.FormId.ToString() == formId).ToList();
        return dbSubmission.Select(s => new SubmissionModel
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


        var submission = new Entities.SubmissionDto
        {
            FieldData = fieldData,
            FormId = ObjectId.Parse(formId)
        };
        _submissionsCollection.InsertOne(submission);
        //return submission;
    }
}