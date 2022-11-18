using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace EnerginetDemo.Infrastructure
{
    public class SampleMessageRepository
    {
        public SampleMessageRepository (SampleMessageContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        private SampleMessageContext DbContext { get; }

        public Task<SampleMessageDb> GetAsync(long id)
        {
            return DbContext.SampleMessages.SingleAsync(x => x.Id == id);
        }

        public SampleMessageDb Add(SampleMessageDb entity)
        {
            DbContext.SampleMessages.Add(entity);
            DbContext.SaveChanges();
            return entity;
        }
    }
}
