using MongoDB.Bson;
using MongoDB.Driver;
using Rendelosch.Dal.Entities;
using Rendelosch.Dal.Extensions;
using Rendelosch.Models;
using Rendelosch.Repository;

namespace Rendelosch.Dal.Repository;

public class MongoDbProductFormRepository : IProductFormRepository
{
    private readonly IMongoCollection<Entities.ProductFormEntity> _productFormsCollection;
    private readonly IMongoCollection<Entities.SubmissionEntity> _submissionsCollection;
    
    public MongoDbProductFormRepository(IMongoDatabase database)
    {

        _productFormsCollection = database.GetCollection<Entities.ProductFormEntity>("productform");
        _submissionsCollection = database.GetCollection<Entities.SubmissionEntity>("submission");

        //TODO only test, remove it
        _productFormsCollection.InsertOne(new Entities.ProductFormEntity
        {
            Title = "teszt",
            Fields =
            [
                new Entities.FieldEntity()
                {
                    Key = "name",
                    Name = "Név",
                },

                new Entities.FieldEntity()
                {
                    Key = "alma",
                    Name = "Alma"
                }
            ],
            EndDate = DateTime.MaxValue,
            StartDate = DateTime.MinValue
        });
    }


    public List<ProductFormModel> GetProductForms()
    {
        var dbProductsForms =  _productFormsCollection.Find(p => true).ToList();
        return dbProductsForms.Select(p => new ProductFormModel
            {
                Id = p.Id.ToString(),
                Fields = p.Fields.ToFieldModelList(),
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
            Fields = dbProductsForm.Fields.ToFieldModelList()
        };
    }

    public ProductFormModel CreateProductForm(string formTitle, List<FieldModel> formFields, DateTime startDate, DateTime endDate)
    {
        List<FieldEntity> fields = formFields.Select(f => new FieldEntity
        {
            Key = f.Key,
            Name = f.Name
        }).ToList();
        ProductFormEntity form = new()
        {
            Title = formTitle,
            Fields = fields,
            StartDate = DateTime.MinValue,
            EndDate = DateTime.MaxValue
        };
        _productFormsCollection.InsertOne(form);

        ProductFormEntity lastInsertedForm = _productFormsCollection.Find(_ => true).SortByDescending(f => f.Id).Limit(1).FirstOrDefault();
        return new ProductFormModel
        {
            Id = lastInsertedForm.Id.ToString(),
            Title = lastInsertedForm.Title,
            Fields = lastInsertedForm.Fields.ToFieldModelList(),
            StartDate = lastInsertedForm.StartDate,
            EndDate = lastInsertedForm.EndDate
        };
    }

    public List<SubmissionModel>? GetSubmissionsForProductForm(string formId)
    {
        var dbSubmission = _submissionsCollection.Find(s => s.ProductFormId.ToString() == formId).ToList();
        return dbSubmission.Select(s => new SubmissionModel
            {
                Id = s.Id.ToString(),
                ProductFormId = formId,
                FieldData = s.FieldData
            }
        ).ToList();
    }

    public void AddSubmissionToProductForm(string formId, Dictionary<string, string> fieldData)
    {
        if( _productFormsCollection.Find(p => p.Id.ToString() == formId).FirstOrDefault() is null ) return;


        var submission = new Entities.SubmissionEntity
        {
            FieldData = fieldData,
            ProductFormId = ObjectId.Parse(formId)
        };
        _submissionsCollection.InsertOne(submission);
    }
}