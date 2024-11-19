using Microsoft.Extensions.Localization;
using Shop.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Shop;

[Dependency(ReplaceServices = true)]
public class ShopBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<ShopResource> _localizer;

    public ShopBrandingProvider(IStringLocalizer<ShopResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
