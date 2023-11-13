using CVGatorBeta.Admin.EntityFramework.AdminModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CVGatorBeta.Admin.EntityFramework.ChangeTrackers
{
    public class CandidateChangeTracker
    {
        public CandidateChangeTracker() { }

        public void OnAdd(ChangeTracker changeTracker)
        {
            List<Type> candidateRelatedTypes = new()
            {
                typeof(Category),
                typeof(Certificate),
                typeof(Country),
                typeof(Course),
                typeof(Employer),
                typeof(School),
            };

            var entries = changeTracker.Entries().Where(x => candidateRelatedTypes.Contains(x.Entity.GetType())).ToList();
            entries.ForEach(x => { x.State = EntityState.Unchanged; });
        }
    }
}
