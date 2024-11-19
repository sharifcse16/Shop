using Volo.Abp.Modularity;

namespace Shop;

/* Inherit from this class for your domain layer tests. */
public abstract class ShopDomainTestBase<TStartupModule> : ShopTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
