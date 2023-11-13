using CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Files;
using CVGatorBeta.Commons.Constatns;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace FunctionApp.File.Upload.Functions
{
    public class GetFileFunctions
    {
        private const string _fileId = "fileId";
        private const string _route = UploadFileConsts.APIGetFilePath;

        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        public GetFileFunctions(ILoggerFactory loggerFactory, IMediator mediator)
        {
            _logger = loggerFactory.CreateLogger<GetFileFunctions>();
            _mediator = mediator;
        }

        [Function(nameof(GetFileStreamAsync))]
        public async Task<IActionResult> GetFileStreamAsync([HttpTrigger(AuthorizationLevel.Function, HttpMethodsConsts.Get, Route = $"{_route}/{{{_fileId}}}")] HttpRequestData req, Guid fileId)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var fileStream =  await _mediator.Send(new GetFileQuery(fileId));

            return new FileStreamResult(fileStream, ContentTypes.ApplicationOctetStream);
        }
    }
}
