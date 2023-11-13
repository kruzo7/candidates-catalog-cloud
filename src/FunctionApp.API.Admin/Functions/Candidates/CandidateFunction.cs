using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Candidates;
using CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Candidates;
using CVGatorBeta.Commons.Constatns;
using CVGatorBeta.DTO.Candidates;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System.Net;
using FromBodyAttribute = Microsoft.Azure.Functions.Worker.Http.FromBodyAttribute;

namespace FunctionApp.API.Admin.Functions.Candidates
{
    public class CandidateFunction
    {
        private const string _candidateId = "candidateId";
        private const string _route = "candidate";

        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        public CandidateFunction(ILoggerFactory loggerFactory, IMediator mediator)
        {
            _logger = loggerFactory.CreateLogger<CandidateFunction>();
            _mediator = mediator;
        }

        [OpenApiOperation(operationId: nameof(GetCandidates), tags: new[] { nameof(GetCandidates) }, Summary = nameof(GetCandidates), Description = nameof(GetCandidates), Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: ContentTypes.ApplicationJson, bodyType: typeof(List<CandidateDto>), Summary = nameof(GetCandidates), Description = nameof(GetCandidates))]
        [Function(nameof(GetCandidates))]
        public async Task<HttpResponseData> GetCandidates([HttpTrigger(AuthorizationLevel.Function, HttpMethodsConsts.Get, Route = _route)] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            var candidates = await _mediator.Send(new GetCandidatesQuery());

            await response.WriteAsJsonAsync(candidates);

            return await Task.FromResult(response);
        }

        [OpenApiOperation(operationId: nameof(GetCandidate), tags: new[] { nameof(GetCandidate) }, Summary = nameof(GetCandidate), Description = nameof(GetCandidate), Visibility = OpenApiVisibilityType.Important)]
        [OpenApiParameter(name: _candidateId, In = ParameterLocation.Path, Required = true, Type = typeof(Guid))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: ContentTypes.ApplicationJson, bodyType: typeof(CandidateDto), Summary = nameof(GetCandidate), Description = nameof(GetCandidate))]
        [Function(nameof(GetCandidate))]
        public async Task<HttpResponseData> GetCandidate([HttpTrigger(AuthorizationLevel.Function, HttpMethodsConsts.Get, Route = $"{_route}/{{{_candidateId}}}")] HttpRequestData req, Guid candidateId)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            var candidate = await _mediator.Send(new GetCandidateQuery(candidateId));

            await response.WriteAsJsonAsync(candidate);

            return await Task.FromResult(response);
        }

        [OpenApiOperation(operationId: nameof(CreateCandidate), tags: new[] { nameof(CreateCandidate) }, Summary = nameof(CreateCandidate), Description = nameof(CreateCandidate), Visibility = OpenApiVisibilityType.Important)]
        [OpenApiRequestBody(ContentTypes.ApplicationJson, typeof(CandidateDto))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: ContentTypes.ApplicationJson, bodyType: typeof(Guid?), Summary = nameof(CreateCandidate), Description = nameof(CreateCandidate))]
        [Function(nameof(CreateCandidate))]
        public async Task<HttpResponseData> CreateCandidate([HttpTrigger(AuthorizationLevel.Function, HttpMethodsConsts.Post, Route = $"{_route}")] HttpRequestData req, [FromBody] CandidateDto candidate)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            var candidateId = await _mediator.Send(new CreateCandidateCommand(candidate));

            await response.WriteAsJsonAsync(candidateId);

            return await Task.FromResult(response);
        }

        [OpenApiOperation(operationId: nameof(UpdateCandidate), tags: new[] { nameof(UpdateCandidate) }, Summary = nameof(UpdateCandidate), Description = nameof(UpdateCandidate), Visibility = OpenApiVisibilityType.Important)]
        [OpenApiParameter(name: _candidateId, In = ParameterLocation.Path, Required = true, Type = typeof(Guid))]
        [OpenApiRequestBody(ContentTypes.ApplicationJson, typeof(CandidateDto))]
        [Function(nameof(UpdateCandidate))]
        public async Task<HttpResponseData> UpdateCandidate([HttpTrigger(AuthorizationLevel.Function, HttpMethodsConsts.Put, Route = $"{_route}/{{{_candidateId}}}")] HttpRequestData req, Guid candidateId, [FromBody] CandidateDto candidate)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            await _mediator.Send(new UpdateCandidateCommand(candidateId, candidate));

            return await Task.FromResult(response);
        }

        [OpenApiOperation(operationId: nameof(DeleteCandidate), tags: new[] { nameof(DeleteCandidate) }, Summary = nameof(DeleteCandidate), Description = nameof(DeleteCandidate), Visibility = OpenApiVisibilityType.Important)]
        [OpenApiParameter(name: _candidateId, In = ParameterLocation.Path, Required = true, Type = typeof(Guid))]
        [Function(nameof(DeleteCandidate))]
        public async Task<HttpResponseData> DeleteCandidate([HttpTrigger(AuthorizationLevel.Function, HttpMethodsConsts.Delete, Route = $"{_route}/{{{_candidateId}}}")] HttpRequestData req, Guid candidateId)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            await _mediator.Send(new DeleteCandidateCommand(candidateId));

            return await Task.FromResult(response);
        }
    }
}
