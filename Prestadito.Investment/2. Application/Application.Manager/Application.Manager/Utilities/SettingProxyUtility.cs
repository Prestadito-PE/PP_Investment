using Prestadito.Investment.Infrastructure.Proxies.Settings.Models;
using Prestadito.Investment.Infrastructure.Proxies.Settings.Models.Parameters;

namespace Prestadito.Investment.Application.Manager.Utilities
{
    public static class SettingProxyUtility
    {
        public static void ParameterToValueInt(this ResponseProxyModel<ParameterModel>? parameter, ref int value)
        {
            if (parameter is not null && !parameter.Error && int.TryParse(parameter.Item.StrValue, out int tempValue))
            {
                value = tempValue;
            }
        }
    }
}
