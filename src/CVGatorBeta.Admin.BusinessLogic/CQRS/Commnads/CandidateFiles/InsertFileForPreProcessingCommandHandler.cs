using AutoMapper;
using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Base;
using CVGatorBeta.Admin.EntityFramework.AdminModels;
using CVGatorBeta.Admin.EntityFramework.ContextData;
using CVGatorBeta.Admin.EntityFramework.Extensions;
using CVGatorBeta.Commons.Enums;
using CVGatorBeta.Commons.Interfaces;
using CVGatorBeta.Commons.Methods;
using CVGatorBeta.DTO.Commons;
using MediatR;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.CandidateFiles
{
    public class InsertFileForPreProcessingCommandHandler : ICommandHandler<InsertFileForPreProcessingCommand>
    {
        private readonly CVGatorBetaAdminContext _context;
        private readonly ICloudFileCandidate _cloudFileCandidate;
        private readonly IUploadFileQueue _uploadFileQueue;
        private readonly IMapper _mapper;

        public InsertFileForPreProcessingCommandHandler(CVGatorBetaAdminContext context, ICloudFileCandidate cloudFileCandidate, IUploadFileQueue uploadFileQueue, IMapper mapper)
        {
            _context = context;
            _cloudFileCandidate = cloudFileCandidate;
            _uploadFileQueue = uploadFileQueue;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(InsertFileForPreProcessingCommand command, CancellationToken cancellationToken)
        {
            GenerateFileName(command.FileDto);

            await CreateOrUpdateCandidateFile(command.FileDto);

            using var fileStream = command.FileStream;
            await _cloudFileCandidate.UploadToTempAsync(command.FileDto, fileStream);
            
            await _uploadFileQueue.SendMessage(command.FileDto);

            return Unit.Value;
        }

        private void GenerateFileName(FileDto fileDto)
        {
            var fileName =  FileNameGenerator.Generate(fileDto.CandidateId, (FileResource)fileDto.FileResource, fileDto.CautionUserFileName);
            fileDto.FileName = fileName;
        }

        private async Task CreateOrUpdateCandidateFile(FileDto fileDto)
        {
            var file = _mapper.Map<CVGatorBeta.Admin.EntityFramework.AdminModels.File>(fileDto);
            file.UploadFileStatus = (int)UploadStatus.Waiting;


            if (fileDto.FileId.HasValue)
            {
                _context.Files.Update(file);
            }
            else
            {
                var candidate = _context.Candidates.First(x => x.CandidateId == file.CandidateId);
                var candidateFile = new CandidatesFile() { Candidate = candidate, File = file };

                _context.Files.Add(file);
                candidate.CandidatesFiles.Add(candidateFile);
            }

            _context.ChangeTracker.AddAudit();
            await _context.SaveChangesAsync();

            if (!fileDto.FileId.HasValue)
            {   
                fileDto.FileId = file.FileId;
            }
        }
    }
}
