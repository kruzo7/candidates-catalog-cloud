using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Courses;
using CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Courses;
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

namespace FunctionApp.API.Admin.Functions.Courses
{
    public class CourseFunction
    {
        private const string _courseId = "courseId";
        private const string _route = "course";

        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        public CourseFunction(ILoggerFactory loggerFactory, IMediator mediator)
        {
            _logger = loggerFactory.CreateLogger<CourseFunction>();
            _mediator = mediator;
        }

        [OpenApiOperation(operationId: nameof(GetCourses), tags: new[] { nameof(GetCourses) }, Summary = nameof(GetCourses), Description = nameof(GetCourses), Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: ContentTypes.ApplicationJson, bodyType: typeof(List<CourseDto>), Summary = nameof(GetCourses), Description = nameof(GetCourses))]
        [Function(nameof(GetCourses))]
        public async Task<HttpResponseData> GetCourses([HttpTrigger(AuthorizationLevel.Function, HttpMethodsConsts.Get, Route = _route)] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            var courses = await _mediator.Send(new GetCoursesQuery());

            await response.WriteAsJsonAsync(courses);

            return await Task.FromResult(response);
        }

        [OpenApiOperation(operationId: nameof(GetCourse), tags: new[] { nameof(GetCourse) }, Summary = nameof(GetCourse), Description = nameof(GetCourse), Visibility = OpenApiVisibilityType.Important)]
        [OpenApiParameter(name: _courseId, In = ParameterLocation.Path, Required = true, Type = typeof(Guid))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: ContentTypes.ApplicationJson, bodyType: typeof(CourseDto), Summary = nameof(GetCourse), Description = nameof(GetCourse))]
        [Function(nameof(GetCourse))]
        public async Task<HttpResponseData> GetCourse([HttpTrigger(AuthorizationLevel.Function, HttpMethodsConsts.Get, Route = $"{_route}/{{{_courseId}}}")] HttpRequestData req, Guid courseId)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            var course = await _mediator.Send(new GetCourseQuery(courseId));

            await response.WriteAsJsonAsync(course);

            return await Task.FromResult(response);
        }

        [OpenApiOperation(operationId: nameof(CreateCourse), tags: new[] { nameof(CreateCourse) }, Summary = nameof(CreateCourse), Description = nameof(CreateCourse), Visibility = OpenApiVisibilityType.Important)]
        [OpenApiRequestBody(ContentTypes.ApplicationJson, typeof(CourseDto))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: ContentTypes.ApplicationJson, bodyType: typeof(Guid?), Summary = nameof(CreateCourse), Description = nameof(CreateCourse))]
        [Function(nameof(CreateCourse))]
        public async Task<HttpResponseData> CreateCourse([HttpTrigger(AuthorizationLevel.Function, HttpMethodsConsts.Post, Route = $"{_route}")] HttpRequestData req, [FromBody] CourseDto course)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            var courseId = await _mediator.Send(new CreateCourseCommand(course));

            await response.WriteAsJsonAsync(courseId);

            return await Task.FromResult(response);
        }

        [OpenApiOperation(operationId: nameof(UpdateCourse), tags: new[] { nameof(UpdateCourse) }, Summary = nameof(UpdateCourse), Description = nameof(UpdateCourse), Visibility = OpenApiVisibilityType.Important)]
        [OpenApiParameter(name: _courseId, In = ParameterLocation.Path, Required = true, Type = typeof(Guid))]
        [OpenApiRequestBody(ContentTypes.ApplicationJson, typeof(CourseDto))]
        [Function(nameof(UpdateCourse))]
        public async Task<HttpResponseData> UpdateCourse([HttpTrigger(AuthorizationLevel.Function, HttpMethodsConsts.Put, Route = $"{_route}/{{{_courseId}}}")] HttpRequestData req, Guid courseId, [FromBody] CourseDto course)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            await _mediator.Send(new UpdateCourseCommand(courseId, course));

            return await Task.FromResult(response);
        }

        [OpenApiOperation(operationId: nameof(DeleteCourse), tags: new[] { nameof(DeleteCourse) }, Summary = nameof(DeleteCourse), Description = nameof(DeleteCourse), Visibility = OpenApiVisibilityType.Important)]
        [OpenApiParameter(name: _courseId, In = ParameterLocation.Path, Required = true, Type = typeof(Guid))]
        [Function(nameof(DeleteCourse))]
        public async Task<HttpResponseData> DeleteCourse([HttpTrigger(AuthorizationLevel.Function, HttpMethodsConsts.Delete, Route = $"{_route}/{{{_courseId}}}")] HttpRequestData req, Guid courseId)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            await _mediator.Send(new DeleteCourseCommand(courseId));

            return await Task.FromResult(response);
        }

    }
}
