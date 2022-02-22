using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(GloboTicketDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Category>> GetCategoryWithEvents(bool includePassedEvents)
        {
            //.Include is helpfull to collate get the other referenced entity 
            //information from the db based on reference.
            //Basically, .Include put a LEft Join on the entity
            //https://www.entityframeworktutorial.net/efcore/querying-in-ef-core.aspx
            var allCategories = await this.dbContext.Categories.Include(x => x.Events).ToListAsync();
            if (!includePassedEvents)
            {
                allCategories.ForEach(p => p.Events.ToList().RemoveAll(x => x.Date < DateTimeOffset.Now));
            }
            return allCategories;
        }
    }
}