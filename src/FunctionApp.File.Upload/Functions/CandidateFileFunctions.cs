using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.CandidateFiles;
using CVGatorBeta.Commons.Constatns;
using CVGatorBeta.DTO.Commons;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FunctionApp.File.Upload.Functions
{
    public class CandidateFileFunctions
    {        
        private const string _route = UploadFileConsts.APICandidateFilePath;

        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        public CandidateFileFunctions(ILoggerFactory loggerFactory, IMediator mediator)
        {
            _logger = loggerFactory.CreateLogger<CandidateFileFunctions>();
            _mediator = mediator;
        }

        [Function(nameof(UploadFile))]
        public async Task<IActionResult> UploadFile([HttpTrigger(AuthorizationLevel.Function, HttpMethodsConsts.Post, Route = _route)] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var fileDto = JsonConvert.DeserializeObject<FileDto>(req.Form[UploadFileConsts.FileDtoName][0]) ?? throw new JsonSerializationException($"Error: can't deserialize to: {nameof(FileDto)}.");
            IFormFile? file = req.Form.Files.FirstOrDefault((IFormFile?)null);

            if (file != null)
            {
                using var fileStream = file.OpenReadStream();
                await _mediator.Send(new InsertFileForPreProcessingCommand(fileDto, fileStream));
            }

            return await Task.FromResult(new OkObjectResult("OK"));
        }
        

    }
}
