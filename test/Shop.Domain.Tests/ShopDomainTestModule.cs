using Volo.Abp.Modularity;

namespace Shop;

[DependsOn(
    typeof(ShopDomainModule),
    typeof(ShopTestBaseModule)
)]
public class ShopDomainTestModule : AbpModule
{

}
