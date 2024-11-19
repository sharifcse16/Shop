using Xunit;

namespace Shop.EntityFrameworkCore;

[CollectionDefinition(ShopTestConsts.CollectionDefinitionName)]
public class ShopEntityFrameworkCoreCollection : ICollectionFixture<ShopEntityFrameworkCoreFixture>
{

}
