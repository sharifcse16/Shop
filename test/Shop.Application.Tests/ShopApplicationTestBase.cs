using Volo.Abp.Modularity;

namespace Shop;

public abstract class ShopApplicationTestBase<TStartupModule> : ShopTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
