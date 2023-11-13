using AutoMapper;
using CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Candidates;
using CVGatorBeta.Admin.EntityFramework.ContextData;
using CVGatorBeta.Application.Initialize.TestData;
using CVGatorBeta.CognitiveSearch.Candidates;
using CVGatorBeta.Commons.Constatns;
using CVGatorBeta.Commons.Settings;
using CVGatorBeta.DTO.Search;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Net;
using FromBodyAttribute = Microsoft.Azure.Functions.Worker.Http.FromBodyAttribute;

namespace FunctionApp.API.Admin.Functions.Search
{
    public class SearchCandidatesFunction
    {
        private const string _route = "searchcandidate";
        private const string _settingCognitiveSearchIndexes = "InitializeCognitiveSearchIndexes";
        private const string _settingInitializeSampleTestData = "InitializeSampleTestData";

        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        private readonly IIndexCandidatesCognitive _indexCandidatesCognitive;
        private readonly IIndexerCandidatesCognitive _indexerCandidatesCognitive;

        private readonly CVGatorBetaAdminContext _context;
        private readonly IMapper _mapper;
        private readonly CVGatorSetting _cVGatorSetting;


        private readonly CancellationToken _cancellationToken;

        public SearchCandidatesFunction(
            ILoggerFactory loggerFactory,
            IMediator mediator,
            IIndexerCandidatesCognitive indexerCandidatesCognitive,
            IIndexCandidatesCognitive indexCandidatesCognitive,
            CVGatorBetaAdminContext context,
            IMapper maper,
            IOptions<CVGatorSetting> cVGatorSetting)
        {
            _cancellationToken = new CancellationTokenSource().Token;

            _logger = loggerFactory.CreateLogger<SearchCandidatesFunction>();
            _mediator = mediator;
            _indexCandidatesCognitive = indexCandidatesCognitive;
            _indexerCandidatesCognitive = indexerCandidatesCognitive;

            _context = context;
            _mapper = maper;
            _cVGatorSetting = cVGatorSetting.Value;
        }

        [OpenApiOperation(operationId: nameof(Search), tags: new[] { nameof(Search) }, Summary = nameof(Search), Description = nameof(Search), Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: ContentTypes.ApplicationJson, bodyType: typeof(SearchCandidateResponseDto), Summary = nameof(Search), Description = nameof(Search))]
        [OpenApiRequestBody(ContentTypes.ApplicationJson, typeof(SearchCandidateRequestDto))]
        [Function(nameof(Search))]
        public async Task<HttpResponseData> Search([HttpTrigger(AuthorizationLevel.Function, HttpMethodsConsts.Post, Route = _route)] HttpRequestData req, [FromBody] SearchCandidateRequestDto searchCandidateRequest)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            await SetCognitiveSearchIndex();
            await SetInitializeSampleTestData();

            var response = req.CreateResponse(HttpStatusCode.OK);

            var searchResponse = await _mediator.Send(new SearchCandidatesQuery(searchCandidateRequest));

            await response.WriteAsJsonAsync(searchResponse);

            return await Task.FromResult(response);
        }

        private async Task SetCognitiveSearchIndex()
        {
            if (_cVGatorSetting.InitializeCognitiveSearchIndexes)
            {
                await _indexCandidatesCognitive.CreateIndexCandidatesCognitive();
                await _indexerCandidatesCognitive.CreateIndexerCandidatesCognitive();

                Environment.SetEnvironmentVariable(_settingCognitiveSearchIndexes, false.ToString(), EnvironmentVariableTarget.Process);
            }
        }

        private async Task SetInitializeSampleTestData()
        {
            if (_cVGatorSetting.InitializeSampleTestData)
            {
                var testData = new TestDataMain(_context, _mapper, _cancellationToken);
                await testData.InserSampleDataToApplication();

                Environment.SetEnvironmentVariable(_settingInitializeSampleTestData, false.ToString(), EnvironmentVariableTarget.Process);
            }
        }

    }
}
