namespace CVGatorBeta.Commons.Interfaces
{
    public interface IFileValidatorFactory
    {
        ICollection<IFileValidator> GetValidatorsDocument();
        ICollection<IFileValidator> GetValidatorsImage();
    }
}
