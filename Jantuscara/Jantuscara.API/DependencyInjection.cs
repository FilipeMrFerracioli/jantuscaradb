using Jantuscara.Repository;

namespace Jantuscara.API
{
    public class DependencyInjection
    {
        public static void Register(IServiceCollection serviceProvider)
        {
            RepositoryDependence(serviceProvider);
        }

        private static void RepositoryDependence(IServiceCollection serviceProvider)
        {
            /* From generic repository */


            /* From own repository */
            serviceProvider.AddScoped(typeof(IItemService), typeof(ItemService));
            serviceProvider.AddScoped(typeof(IItemRepository), typeof(ItemRepository));

            serviceProvider.AddScoped(typeof(IRequestService), typeof(RequestService));
            serviceProvider.AddScoped(typeof(IRequestRepository), typeof(RequestRepository));

            serviceProvider.AddScoped(typeof(ICustomerService), typeof(CustomerService));
            serviceProvider.AddScoped(typeof(ICustomerRepository), typeof(CustomerRepository));

            serviceProvider.AddScoped(typeof(IRequestItemService), typeof(RequestItemService));
            serviceProvider.AddScoped(typeof(IRequestItemRepository), typeof(RequestItemRepository));

            /* Generic repository */
            //serviceProvider.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        }
    }
}