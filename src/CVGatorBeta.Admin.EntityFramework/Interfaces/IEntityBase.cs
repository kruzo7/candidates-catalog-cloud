namespace CVGatorBeta.Admin.EntityFramework.Interfaces
{
    public interface IEntityBase
    {
        DateTime AudCreateOn { get; set; }
        public DateTime AudModifyOn { get; set; }
        public string AudCreateBy { get; set; }        
        public string AudModifyBy { get; set; }
    }
}
