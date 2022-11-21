using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EnerginetDemo.Infrastructure
{
    public class SampleMessageRepository
    {
        public SampleMessageRepository (SampleMessageDbContext dbDbContext)
        {
            DbDbContext = dbDbContext ?? throw new ArgumentNullException(nameof(dbDbContext));
        }

        private SampleMessageDbContext DbDbContext { get; }

        public Task<SampleMessageDb> GetAsync(long id)
        {
            return DbDbContext.SampleMessages.SingleAsync(x => x.Id == id);
        }

        public SampleMessageDb Add(SampleMessageDb entity)
        {
            DbDbContext.SampleMessages.Add(entity);
            DbDbContext.SaveChanges();
            return entity;
        }
    }
}
