using CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Base;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Files
{
    public class GetFileQuery : IQuery<Stream>
    {
        public Guid FileId { get; set; }

        public GetFileQuery(Guid fileId)
        {
            FileId = fileId;
        }
    }
}
