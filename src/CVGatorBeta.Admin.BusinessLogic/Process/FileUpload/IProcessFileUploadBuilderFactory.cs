using CVGatorBeta.Commons.Enums;

namespace CVGatorBeta.Admin.BusinessLogic.Process.FileUpload
{
    public interface IProcessFileUploadBuilderFactory
    {
        IProcessFileUploadBuilder CreateProcessBuilder(FileResource fileResource);
    }
}
