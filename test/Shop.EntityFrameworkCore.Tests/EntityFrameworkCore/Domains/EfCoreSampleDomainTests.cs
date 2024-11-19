using Shop.Samples;
using Xunit;

namespace Shop.EntityFrameworkCore.Domains;

[Collection(ShopTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<ShopEntityFrameworkCoreTestModule>
{

}
