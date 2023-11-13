using CVGatorBeta.Commons.Constatns;
using CVGatorBeta.Commons.Enums;
using CVGatorBeta.Commons.Validators;
using CVGatorBeta.DTO.Commons;
using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http;
using System.Net.Http.Json;

namespace StaticWebApp.CVGatorBetaBlazorWasm.HttpClients
{
    public class FileHttpClient
    {
        private readonly HttpClient _httpClient;
        
        private const long _oneMB = 1048576;
        private const long _maxBytes = _oneMB * 10;

        private readonly FileContentExtensionValidator _fileContentExtensionValidator;
        public FileHttpClient(IHttpClientFactory httpClientFactory, FileContentExtensionValidator fileContentExtensionValidator)
        {
            _httpClient = httpClientFactory.CreateClient(HttpClientsExtension.UploadFileClinet);
            _fileContentExtensionValidator = fileContentExtensionValidator;
        }

        public async Task Upload(IBrowserFile browserFile, FileDto fileDto)
        {
            ValidateSize(browserFile.Size);
            ValidateContentType(browserFile.ContentType, browserFile.Name, fileDto.FileResource);

            fileDto.CautionUserFileName = browserFile.Name;

            using var multipartContent = new MultipartFormDataContent();

            multipartContent.Add(JsonContent.Create<FileDto>(fileDto), UploadFileConsts.FileDtoName);

            using var file = new StreamContent(browserFile.OpenReadStream());
            multipartContent.Add(content: file, name: UploadFileConsts.File, fileName: UploadFileConsts.FileName);

            await _httpClient.PostAsync(UploadFileConsts.APICandidateFilePath, multipartContent);
        }
        public Task<Stream> DownloadAsync(Guid fileId)
        {
           return _httpClient.GetStreamAsync($"{UploadFileConsts.APIGetFilePath}/{fileId}");
        }

        private void ValidateContentType(string contentType, string fileName, int fileResource)
        {
            if(!_fileContentExtensionValidator.Validate(contentType, fileName, (FileResource)fileResource))
            {
                throw new FileLoadException($"Not suported file type. Only this kind: {_fileContentExtensionValidator.GetSupportedFileType((FileResource)fileResource)}");
            }
        }

        private void ValidateSize(long fileSize)
        {
            if (fileSize > _maxBytes)
            {
                throw new FileLoadException($"File size is too big. Max size is: {_maxBytes / _oneMB} MB");
            }
        }

    }
}



////TODO: upload z web aplikacji do bloba
//   funkcja trigger po uploadzie bloba - prosta walidacja i toworzenie widomosci na kolejke
//   kolejka do aktualizacji kandydata - aktualizacja kandydata

//   identyfikacja po generowanym ID pliku ???
//   proba aktualizacji np 10x ??? kandydat byl stowrzony i go jescze nie ma w bazie?? - lub wiadomość na kolejkę, żę można już procesowac plik ???
