using CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Base;
using CVGatorBeta.Admin.EntityFramework.ContextData;
using CVGatorBeta.Commons.Interfaces;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Files
{
    public class GetFileQueryHandler : IQueryHandler<GetFileQuery, Stream>
    {
        private readonly CVGatorBetaAdminContext _context;
        private readonly ICloudFileCandidate _cloudFile;

        public GetFileQueryHandler(CVGatorBetaAdminContext context, ICloudFileCandidate cloudFile)
        {
            _context = context;
            _cloudFile = cloudFile;
        }

        public Task<Stream> Handle(GetFileQuery query, CancellationToken cancellationToken)
        {
            var file = _context.Files.Single(x => x.FileId == query.FileId);

            return _cloudFile.GetFromFinalAsync(file.FileName);
        }
    }
}
