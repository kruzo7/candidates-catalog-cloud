using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Employers;
using CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Employers;
using CVGatorBeta.Commons.Constatns;
using CVGatorBeta.DTO.CandidateDetails;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System.Net;
using FromBodyAttribute = Microsoft.Azure.Functions.Worker.Http.FromBodyAttribute;

namespace FunctionApp.API.Admin.Functions.Employers
{
    public class EmployerFunction
    {
        private const string _employerId = "employerId";
        private const string _route = "employer";

        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        public EmployerFunction(ILoggerFactory loggerFactory, IMediator mediator)
        {
            _logger = loggerFactory.CreateLogger<EmployerFunction>();
            _mediator = mediator;
        }

        [OpenApiOperation(operationId: nameof(GetEmployers), tags: new[] { nameof(GetEmployers) }, Summary = nameof(GetEmployers), Description = nameof(GetEmployers), Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: ContentTypes.ApplicationJson, bodyType: typeof(List<EmployerDto>), Summary = nameof(GetEmployers), Description = nameof(GetEmployers))]
        [Function(nameof(GetEmployers))]
        public async Task<HttpResponseData> GetEmployers([HttpTrigger(AuthorizationLevel.Function, HttpMethodsConsts.Get, Route = _route)] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            var employers = await _mediator.Send(new GetEmployersQuery());

            await response.WriteAsJsonAsync(employers);

            return await Task.FromResult(response);
        }

        [OpenApiOperation(operationId: nameof(GetEmployer), tags: new[] { nameof(GetEmployer) }, Summary = nameof(GetEmployer), Description = nameof(GetEmployer), Visibility = OpenApiVisibilityType.Important)]
        [OpenApiParameter(name: _employerId, In = ParameterLocation.Path, Required = true, Type = typeof(Guid))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: ContentTypes.ApplicationJson, bodyType: typeof(EmployerDto), Summary = nameof(GetEmployer), Description = nameof(GetEmployer))]
        [Function(nameof(GetEmployer))]
        public async Task<HttpResponseData> GetEmployer([HttpTrigger(AuthorizationLevel.Function, HttpMethodsConsts.Get, Route = $"{_route}/{{{_employerId}}}")] HttpRequestData req, Guid employerId)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            var employer = await _mediator.Send(new GetEmployerQuery(employerId));

            await response.WriteAsJsonAsync(employer);

            return await Task.FromResult(response);
        }

        [OpenApiOperation(operationId: nameof(CreateEmployer), tags: new[] { nameof(CreateEmployer) }, Summary = nameof(CreateEmployer), Description = nameof(CreateEmployer), Visibility = OpenApiVisibilityType.Important)]
        [OpenApiRequestBody(ContentTypes.ApplicationJson, typeof(EmployerDto))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: ContentTypes.ApplicationJson, bodyType: typeof(Guid?), Summary = nameof(CreateEmployer), Description = nameof(CreateEmployer))]
        [Function(nameof(CreateEmployer))]
        public async Task<HttpResponseData> CreateEmployer([HttpTrigger(AuthorizationLevel.Function, HttpMethodsConsts.Post, Route = $"{_route}")] HttpRequestData req, [FromBody] EmployerDto employer)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            var employerId = await _mediator.Send(new CreateEmployerCommand(employer));

            await response.WriteAsJsonAsync(employerId);

            return await Task.FromResult(response);
        }

        [OpenApiOperation(operationId: nameof(UpdateEmployer), tags: new[] { nameof(UpdateEmployer) }, Summary = nameof(UpdateEmployer), Description = nameof(UpdateEmployer), Visibility = OpenApiVisibilityType.Important)]
        [OpenApiParameter(name: _employerId, In = ParameterLocation.Path, Required = true, Type = typeof(Guid))]
        [OpenApiRequestBody(ContentTypes.ApplicationJson, typeof(EmployerDto))]
        [Function(nameof(UpdateEmployer))]
        public async Task<HttpResponseData> UpdateEmployer([HttpTrigger(AuthorizationLevel.Function, HttpMethodsConsts.Put, Route = $"{_route}/{{{_employerId}}}")] HttpRequestData req, Guid employerId, [FromBody] EmployerDto employer)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            await _mediator.Send(new UpdateEmployerCommand(employerId, employer));

            return await Task.FromResult(response);
        }

        [OpenApiOperation(operationId: nameof(DeleteEmployer), tags: new[] { nameof(DeleteEmployer) }, Summary = nameof(DeleteEmployer), Description = nameof(DeleteEmployer), Visibility = OpenApiVisibilityType.Important)]
        [OpenApiParameter(name: _employerId, In = ParameterLocation.Path, Required = true, Type = typeof(Guid))]
        [Function(nameof(DeleteEmployer))]
        public async Task<HttpResponseData> DeleteEmployer([HttpTrigger(AuthorizationLevel.Function, HttpMethodsConsts.Delete, Route = $"{_route}/{{{_employerId}}}")] HttpRequestData req, Guid employerId)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            await _mediator.Send(new DeleteEmployerCommand(employerId));

            return await Task.FromResult(response);
        }

    }
}
