using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Schools;
using CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Schools;
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

namespace FunctionApp.API.Admin.Functions.Schools
{
    public class SchoolFunction
    {
        private const string _schoolId = "schoolId";
        private const string _route = "school";

        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        public SchoolFunction(ILoggerFactory loggerFactory, IMediator mediator)
        {
            _logger = loggerFactory.CreateLogger<SchoolFunction>();
            _mediator = mediator;
        }

        [OpenApiOperation(operationId: nameof(GetSchools), tags: new[] { nameof(GetSchools) }, Summary = nameof(GetSchools), Description = nameof(GetSchools), Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: ContentTypes.ApplicationJson, bodyType: typeof(List<SchoolDto>), Summary = nameof(GetSchools), Description = nameof(GetSchools))]
        [Function(nameof(GetSchools))]
        public async Task<HttpResponseData> GetSchools([HttpTrigger(AuthorizationLevel.Function, HttpMethodsConsts.Get, Route = _route)] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            var schools = await _mediator.Send(new GetSchoolsQuery());

            await response.WriteAsJsonAsync(schools);

            return await Task.FromResult(response);
        }

        [OpenApiOperation(operationId: nameof(GetSchool), tags: new[] { nameof(GetSchool) }, Summary = nameof(GetSchool), Description = nameof(GetSchool), Visibility = OpenApiVisibilityType.Important)]
        [OpenApiParameter(name: _schoolId, In = ParameterLocation.Path, Required = true, Type = typeof(Guid))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: ContentTypes.ApplicationJson, bodyType: typeof(SchoolDto), Summary = nameof(GetSchool), Description = nameof(GetSchool))]
        [Function(nameof(GetSchool))]
        public async Task<HttpResponseData> GetSchool([HttpTrigger(AuthorizationLevel.Function, HttpMethodsConsts.Get, Route = $"{_route}/{{{_schoolId}}}")] HttpRequestData req, Guid schoolId)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            var school = await _mediator.Send(new GetSchoolQuery(schoolId));

            await response.WriteAsJsonAsync(school);

            return await Task.FromResult(response);
        }

        [OpenApiOperation(operationId: nameof(CreateSchool), tags: new[] { nameof(CreateSchool) }, Summary = nameof(CreateSchool), Description = nameof(CreateSchool), Visibility = OpenApiVisibilityType.Important)]
        [OpenApiRequestBody(ContentTypes.ApplicationJson, typeof(SchoolDto))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: ContentTypes.ApplicationJson, bodyType: typeof(Guid?), Summary = nameof(CreateSchool), Description = nameof(CreateSchool))]
        [Function(nameof(CreateSchool))]
        public async Task<HttpResponseData> CreateSchool([HttpTrigger(AuthorizationLevel.Function, HttpMethodsConsts.Post, Route = $"{_route}")] HttpRequestData req, [FromBody] SchoolDto school)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            var schoolId = await _mediator.Send(new CreateSchoolCommand(school));

            await response.WriteAsJsonAsync(schoolId);

            return await Task.FromResult(response);
        }

        [OpenApiOperation(operationId: nameof(UpdateSchool), tags: new[] { nameof(UpdateSchool) }, Summary = nameof(UpdateSchool), Description = nameof(UpdateSchool), Visibility = OpenApiVisibilityType.Important)]
        [OpenApiParameter(name: _schoolId, In = ParameterLocation.Path, Required = true, Type = typeof(Guid))]
        [OpenApiRequestBody(ContentTypes.ApplicationJson, typeof(SchoolDto))]
        [Function(nameof(UpdateSchool))]
        public async Task<HttpResponseData> UpdateSchool([HttpTrigger(AuthorizationLevel.Function, HttpMethodsConsts.Put, Route = $"{_route}/{{{_schoolId}}}")] HttpRequestData req, Guid schoolId, [FromBody] SchoolDto school)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            await _mediator.Send(new UpdateSchoolCommand(schoolId, school));

            return await Task.FromResult(response);
        }

        [OpenApiOperation(operationId: nameof(DeleteSchool), tags: new[] { nameof(DeleteSchool) }, Summary = nameof(DeleteSchool), Description = nameof(DeleteSchool), Visibility = OpenApiVisibilityType.Important)]
        [OpenApiParameter(name: _schoolId, In = ParameterLocation.Path, Required = true, Type = typeof(Guid))]
        [Function(nameof(DeleteSchool))]
        public async Task<HttpResponseData> DeleteSchool([HttpTrigger(AuthorizationLevel.Function, HttpMethodsConsts.Delete, Route = $"{_route}/{{{_schoolId}}}")] HttpRequestData req, Guid schoolId)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            await _mediator.Send(new DeleteSchoolCommand(schoolId));

            return await Task.FromResult(response);
        }

    }
}
