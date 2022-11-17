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
            //serviceProvider.AddScoped(typeof(ILoginService), typeof(LoginService));
            //serviceProvider.AddScoped(typeof(IUserRepository), typeof(UserRepository));

            /* Generic repository */
            //serviceProvider.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        }
    }
}