using CVGatorBeta.Commons.Enums;

namespace CVGatorBeta.Commons.Methods
{
    public static class FileNameGenerator
    {
        public static string Generate(Guid candidateId, FileResource fileResource, string fileName)
        {
            var extension = Path.GetExtension(fileName);
            return $"{candidateId}_{fileResource}{extension}";
        }
    }
}
