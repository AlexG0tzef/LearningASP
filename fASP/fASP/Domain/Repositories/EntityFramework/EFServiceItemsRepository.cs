using fASP.Domain.Entities;
using fASP.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace fASP.Domain.Repositories.EntityFramework
{
    public class EFServiceItemsRepository : IServiceItemsRepository
    {
        private readonly AppDbContext context;

        public EFServiceItemsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<ServiceItem> GetServiceItems()
        {
            return context.serviceItems;
        }

        public ServiceItem GetServiceItemById(Guid ID)
        {
            return context.serviceItems.Where(x => x.Id == ID).FirstOrDefault();
        }

        public void SaveServiceItem(ServiceItem entity)
        {
            if (entity.Id == default)
            {
                context.Entry(entity).State = EntityState.Added;
            }
            else
            {
                context.Entry(entity).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public void DeleteServiceItem(Guid ID)
        {
            context.serviceItems.Remove(new ServiceItem() { Id = ID });
            context.SaveChanges();
        }
    }
}
