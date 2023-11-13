using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Categorys;
using CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Categorys;
using CVGatorBeta.Commons.Constatns;
using CVGatorBeta.DTO.Categories;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System.Net;
using FromBodyAttribute = Microsoft.Azure.Functions.Worker.Http.FromBodyAttribute;

namespace FunctionApp.API.Admin.Functions.Categorys
{
    public class CategoryFunction
    {
        private const string _categoryId = "categoryId";
        private const string _route = "category";

        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        public CategoryFunction(ILoggerFactory loggerFactory, IMediator mediator)
        {
            _logger = loggerFactory.CreateLogger<CategoryFunction>();
            _mediator = mediator;
        }

        [OpenApiOperation(operationId: nameof(GetCategorys), tags: new[] { nameof(GetCategorys) }, Summary = nameof(GetCategorys), Description = nameof(GetCategorys), Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: ContentTypes.ApplicationJson, bodyType: typeof(List<CategoryDto>), Summary = nameof(GetCategorys), Description = nameof(GetCategorys))]
        [Function(nameof(GetCategorys))]
        public async Task<HttpResponseData> GetCategorys([HttpTrigger(AuthorizationLevel.Function, HttpMethodsConsts.Get, Route = _route)] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            var categorys = await _mediator.Send(new GetCategoriesQuery());

            await response.WriteAsJsonAsync(categorys);

            return await Task.FromResult(response);
        }

        [OpenApiOperation(operationId: nameof(GetCategory), tags: new[] { nameof(GetCategory) }, Summary = nameof(GetCategory), Description = nameof(GetCategory), Visibility = OpenApiVisibilityType.Important)]
        [OpenApiParameter(name: _categoryId, In = ParameterLocation.Path, Required = true, Type = typeof(Guid))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: ContentTypes.ApplicationJson, bodyType: typeof(CategoryDto), Summary = nameof(GetCategory), Description = nameof(GetCategory))]
        [Function(nameof(GetCategory))]
        public async Task<HttpResponseData> GetCategory([HttpTrigger(AuthorizationLevel.Function, HttpMethodsConsts.Get, Route = $"{_route}/{{{_categoryId}}}")] HttpRequestData req, Guid categoryId)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            var category = await _mediator.Send(new GetCategoryQuery(categoryId));

            await response.WriteAsJsonAsync(category);

            return await Task.FromResult(response);
        }

        [OpenApiOperation(operationId: nameof(CreateCategory), tags: new[] { nameof(CreateCategory) }, Summary = nameof(CreateCategory), Description = nameof(CreateCategory), Visibility = OpenApiVisibilityType.Important)]
        [OpenApiRequestBody(ContentTypes.ApplicationJson, typeof(CategoryDto))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: ContentTypes.ApplicationJson, bodyType: typeof(Guid?), Summary = nameof(CreateCategory), Description = nameof(CreateCategory))]
        [Function(nameof(CreateCategory))]
        public async Task<HttpResponseData> CreateCategory([HttpTrigger(AuthorizationLevel.Function, HttpMethodsConsts.Post, Route = $"{_route}")] HttpRequestData req, [FromBody] CategoryDto category)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            var categoryId = await _mediator.Send(new CreateCategoryCommand(category));

            await response.WriteAsJsonAsync(categoryId);

            return await Task.FromResult(response);
        }

        [OpenApiOperation(operationId: nameof(UpdateCategory), tags: new[] { nameof(UpdateCategory) }, Summary = nameof(UpdateCategory), Description = nameof(UpdateCategory), Visibility = OpenApiVisibilityType.Important)]
        [OpenApiParameter(name: _categoryId, In = ParameterLocation.Path, Required = true, Type = typeof(Guid))]
        [OpenApiRequestBody(ContentTypes.ApplicationJson, typeof(CategoryDto))]
        [Function(nameof(UpdateCategory))]
        public async Task<HttpResponseData> UpdateCategory([HttpTrigger(AuthorizationLevel.Function, HttpMethodsConsts.Put, Route = $"{_route}/{{{_categoryId}}}")] HttpRequestData req, Guid categoryId, [FromBody] CategoryDto category)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            await _mediator.Send(new UpdateCategoryCommand(categoryId, category));

            return await Task.FromResult(response);
        }

        [OpenApiOperation(operationId: nameof(DeleteCategory), tags: new[] { nameof(DeleteCategory) }, Summary = nameof(DeleteCategory), Description = nameof(DeleteCategory), Visibility = OpenApiVisibilityType.Important)]
        [OpenApiParameter(name: _categoryId, In = ParameterLocation.Path, Required = true, Type = typeof(Guid))]
        [Function(nameof(DeleteCategory))]
        public async Task<HttpResponseData> DeleteCategory([HttpTrigger(AuthorizationLevel.Function, HttpMethodsConsts.Delete, Route = $"{_route}/{{{_categoryId}}}")] HttpRequestData req, Guid categoryId)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            await _mediator.Send(new DeleteCategoryCommand(categoryId));

            return await Task.FromResult(response);
        }

    }
}
