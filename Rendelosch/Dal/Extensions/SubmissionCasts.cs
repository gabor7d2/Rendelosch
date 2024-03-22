using MongoDB.Bson;
using Rendelosch.Dal.Entities;

namespace Rendelosch.Dal.Extensions;

public static partial class Casts
{
    public static Models.SubmissionModel ToSubmissionModel(this Entities.SubmissionEntity submissionEntity)
    {
        return new Models.SubmissionModel
        {
            Id = submissionEntity.Id.ToString(),
            ProductFormId = submissionEntity.ProductFormId.ToString(),
            FieldData = submissionEntity.FieldData
        };
    }
    
    public static List<Models.SubmissionModel> ToSubmissionModelList(this IEnumerable<Entities.SubmissionEntity> submissions)
        => submissions.Select(ToSubmissionModel).ToList();

    public static Entities.SubmissionEntity ToSubmissionEntity(this Models.SubmissionModel submissionModel)
    {
        return new SubmissionEntity
        {
            ProductFormId = ObjectId.Parse(submissionModel.ProductFormId),
            FieldData = submissionModel.FieldData
        };
    }
    
    public static List<Entities.SubmissionEntity> ToSubmissionEntityList(this IEnumerable<Models.SubmissionModel> submissions)
        => submissions.Select(ToSubmissionEntity).ToList();
}