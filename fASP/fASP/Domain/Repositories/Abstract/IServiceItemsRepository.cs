using fASP.Domain.Entities;

namespace fASP.Domain.Repositories.Abstract
{
    public interface IServiceItemsRepository
    {
        IQueryable<ServiceItem> GetServiceItems();
        ServiceItem GetServiceItemById(Guid ID);
        void SaveServiceItem(ServiceItem entity);
        void DeleteServiceItem(Guid ID);
    }
}
