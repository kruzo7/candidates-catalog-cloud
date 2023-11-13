using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Certificates;
using CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Certificates;
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

namespace FunctionApp.API.Admin.Functions.Certificates
{
    public class CertificateFunction
    {
        private const string _certificateId = "certificateId";
        private const string _route = "certificate";

        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        public CertificateFunction(ILoggerFactory loggerFactory, IMediator mediator)
        {
            _logger = loggerFactory.CreateLogger<CertificateFunction>();
            _mediator = mediator;
        }

        [OpenApiOperation(operationId: nameof(GetCertificates), tags: new[] { nameof(GetCertificates) }, Summary = nameof(GetCertificates), Description = nameof(GetCertificates), Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: ContentTypes.ApplicationJson, bodyType: typeof(List<CertificateDto>), Summary = nameof(GetCertificates), Description = nameof(GetCertificates))]
        [Function(nameof(GetCertificates))]
        public async Task<HttpResponseData> GetCertificates([HttpTrigger(AuthorizationLevel.Function, HttpMethodsConsts.Get, Route = _route)] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            var certificates = await _mediator.Send(new GetCertificatesQuery());

            await response.WriteAsJsonAsync(certificates);

            return await Task.FromResult(response);
        }

        [OpenApiOperation(operationId: nameof(GetCertificate), tags: new[] { nameof(GetCertificate) }, Summary = nameof(GetCertificate), Description = nameof(GetCertificate), Visibility = OpenApiVisibilityType.Important)]
        [OpenApiParameter(name: _certificateId, In = ParameterLocation.Path, Required = true, Type = typeof(Guid))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: ContentTypes.ApplicationJson, bodyType: typeof(CertificateDto), Summary = nameof(GetCertificate), Description = nameof(GetCertificate))]
        [Function(nameof(GetCertificate))]
        public async Task<HttpResponseData> GetCertificate([HttpTrigger(AuthorizationLevel.Function, HttpMethodsConsts.Get, Route = $"{_route}/{{{_certificateId}}}")] HttpRequestData req, Guid certificateId)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            var certificate = await _mediator.Send(new GetCertificateQuery(certificateId));

            await response.WriteAsJsonAsync(certificate);

            return await Task.FromResult(response);
        }

        [OpenApiOperation(operationId: nameof(CreateCertificate), tags: new[] { nameof(CreateCertificate) }, Summary = nameof(CreateCertificate), Description = nameof(CreateCertificate), Visibility = OpenApiVisibilityType.Important)]
        [OpenApiRequestBody(ContentTypes.ApplicationJson, typeof(CertificateDto))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: ContentTypes.ApplicationJson, bodyType: typeof(Guid?), Summary = nameof(CreateCertificate), Description = nameof(CreateCertificate))]
        [Function(nameof(CreateCertificate))]
        public async Task<HttpResponseData> CreateCertificate([HttpTrigger(AuthorizationLevel.Function, HttpMethodsConsts.Post, Route = $"{_route}")] HttpRequestData req, [FromBody] CertificateDto certificate)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            var certificateId = await _mediator.Send(new CreateCertificateCommand(certificate));

            await response.WriteAsJsonAsync(certificateId);

            return await Task.FromResult(response);
        }

        [OpenApiOperation(operationId: nameof(UpdateCertificate), tags: new[] { nameof(UpdateCertificate) }, Summary = nameof(UpdateCertificate), Description = nameof(UpdateCertificate), Visibility = OpenApiVisibilityType.Important)]
        [OpenApiParameter(name: _certificateId, In = ParameterLocation.Path, Required = true, Type = typeof(Guid))]
        [OpenApiRequestBody(ContentTypes.ApplicationJson, typeof(CertificateDto))]
        [Function(nameof(UpdateCertificate))]
        public async Task<HttpResponseData> UpdateCertificate([HttpTrigger(AuthorizationLevel.Function, HttpMethodsConsts.Put, Route = $"{_route}/{{{_certificateId}}}")] HttpRequestData req, Guid certificateId, [FromBody] CertificateDto certificate)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            await _mediator.Send(new UpdateCertificateCommand(certificateId, certificate));

            return await Task.FromResult(response);
        }

        [OpenApiOperation(operationId: nameof(DeleteCertificate), tags: new[] { nameof(DeleteCertificate) }, Summary = nameof(DeleteCertificate), Description = nameof(DeleteCertificate), Visibility = OpenApiVisibilityType.Important)]
        [OpenApiParameter(name: _certificateId, In = ParameterLocation.Path, Required = true, Type = typeof(Guid))]
        [Function(nameof(DeleteCertificate))]
        public async Task<HttpResponseData> DeleteCertificate([HttpTrigger(AuthorizationLevel.Function, HttpMethodsConsts.Delete, Route = $"{_route}/{{{_certificateId}}}")] HttpRequestData req, Guid certificateId)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            await _mediator.Send(new DeleteCertificateCommand(certificateId));

            return await Task.FromResult(response);
        }

    }
}
