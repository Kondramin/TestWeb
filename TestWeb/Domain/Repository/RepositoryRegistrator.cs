using Microsoft.Extensions.DependencyInjection;
using TestWeb.Domain.Repository.Base;
using TestWeb.Interfaces.Repositories;

namespace TestWeb.Domain.Repository
{
    public static class RepositoryRegistrator
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services) => services
            .AddTransient(typeof(IRepository<>), typeof(DbRepository<>))
            ;
    }
}
