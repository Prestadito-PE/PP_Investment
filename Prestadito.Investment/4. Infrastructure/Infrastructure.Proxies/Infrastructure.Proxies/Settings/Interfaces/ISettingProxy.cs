using Prestadito.Investment.Infrastructure.Proxies.Settings.Models;
using Prestadito.Investment.Infrastructure.Proxies.Settings.Models.Parameters;

namespace Prestadito.Investment.Infrastructure.Proxies.Settings.Interfaces
{
    public interface ISettingProxy
    {
        ValueTask<ResponseProxyModel<ParameterModel>?> GetParameterByCode(string parameterCode);
    }
}
