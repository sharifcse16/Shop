using Shop.Samples;
using Xunit;

namespace Shop.EntityFrameworkCore.Applications;

[Collection(ShopTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<ShopEntityFrameworkCoreTestModule>
{

}
