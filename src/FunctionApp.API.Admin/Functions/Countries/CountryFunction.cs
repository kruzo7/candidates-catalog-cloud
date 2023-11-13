using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Countries;
using CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Countries;
using CVGatorBeta.Commons.Constatns;
using CVGatorBeta.DTO.Commons;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System.Net;
using FromBodyAttribute = Microsoft.Azure.Functions.Worker.Http.FromBodyAttribute;

namespace FunctionApp.API.Admin.Functions.Countries
{
    public class CountryFunction
    {
        private const string _countryId = "countryId";
        private const string _route = "country";

        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        public CountryFunction(ILoggerFactory loggerFactory, IMediator mediator)
        {
            _logger = loggerFactory.CreateLogger<CountryFunction>();
            _mediator = mediator;
        }

        [OpenApiOperation(operationId: nameof(GetCountries), tags: new[] { nameof(GetCountries) }, Summary = nameof(GetCountries), Description = nameof(GetCountries), Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: ContentTypes.ApplicationJson, bodyType: typeof(List<CountryDto>), Summary = nameof(GetCountries), Description = nameof(GetCountries))]
        [Function(nameof(GetCountries))]
        public async Task<HttpResponseData> GetCountries([HttpTrigger(AuthorizationLevel.Function, HttpMethodsConsts.Get, Route = _route)] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            var countries = await _mediator.Send(new GetCountriesQuery());

            await response.WriteAsJsonAsync(countries);

            return await Task.FromResult(response);
        }

        [OpenApiOperation(operationId: nameof(GetCountry), tags: new[] { nameof(GetCountry) }, Summary = nameof(GetCountry), Description = nameof(GetCountry), Visibility = OpenApiVisibilityType.Important)]
        [OpenApiParameter(name: _countryId, In = ParameterLocation.Path, Required = true, Type = typeof(Guid))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: ContentTypes.ApplicationJson, bodyType: typeof(CountryDto), Summary = nameof(GetCountry), Description = nameof(GetCountry))]
        [Function(nameof(GetCountry))]
        public async Task<HttpResponseData> GetCountry([HttpTrigger(AuthorizationLevel.Function, HttpMethodsConsts.Get, Route = $"{_route}/{{{_countryId}}}")] HttpRequestData req, Guid countryId)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            var country = await _mediator.Send(new GetCountryQuery(countryId));

            await response.WriteAsJsonAsync(country);

            return await Task.FromResult(response);
        }

        [OpenApiOperation(operationId: nameof(CreateCountry), tags: new[] { nameof(CreateCountry) }, Summary = nameof(CreateCountry), Description = nameof(CreateCountry), Visibility = OpenApiVisibilityType.Important)]
        [OpenApiRequestBody(ContentTypes.ApplicationJson, typeof(CountryDto))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: ContentTypes.ApplicationJson, bodyType: typeof(Guid?), Summary = nameof(CreateCountry), Description = nameof(CreateCountry))]
        [Function(nameof(CreateCountry))]
        public async Task<HttpResponseData> CreateCountry([HttpTrigger(AuthorizationLevel.Function, HttpMethodsConsts.Post, Route = $"{_route}")] HttpRequestData req, [FromBody] CountryDto country)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            var countryId = await _mediator.Send(new CreateCountryCommand(country));

            await response.WriteAsJsonAsync(countryId);

            return await Task.FromResult(response);
        }

        [OpenApiOperation(operationId: nameof(UpdateCountry), tags: new[] { nameof(UpdateCountry) }, Summary = nameof(UpdateCountry), Description = nameof(UpdateCountry), Visibility = OpenApiVisibilityType.Important)]
        [OpenApiParameter(name: _countryId, In = ParameterLocation.Path, Required = true, Type = typeof(Guid))]
        [OpenApiRequestBody(ContentTypes.ApplicationJson, typeof(CountryDto))]
        [Function(nameof(UpdateCountry))]
        public async Task<HttpResponseData> UpdateCountry([HttpTrigger(AuthorizationLevel.Function, HttpMethodsConsts.Put, Route = $"{_route}/{{{_countryId}}}")] HttpRequestData req, Guid countryId, [FromBody] CountryDto country)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            await _mediator.Send(new UpdateCountryCommand(countryId, country));

            return await Task.FromResult(response);
        }

        [OpenApiOperation(operationId: nameof(DeleteCountry), tags: new[] { nameof(DeleteCountry) }, Summary = nameof(DeleteCountry), Description = nameof(DeleteCountry), Visibility = OpenApiVisibilityType.Important)]
        [OpenApiParameter(name: _countryId, In = ParameterLocation.Path, Required = true, Type = typeof(Guid))]
        [Function(nameof(DeleteCountry))]
        public async Task<HttpResponseData> DeleteCountry([HttpTrigger(AuthorizationLevel.Function, HttpMethodsConsts.Delete, Route = $"{_route}/{{{_countryId}}}")] HttpRequestData req, Guid countryId)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            await _mediator.Send(new DeleteCountryCommand(countryId));

            return await Task.FromResult(response);
        }

    }
}
