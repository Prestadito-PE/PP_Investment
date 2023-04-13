using Prestadito.Investment.Infrastructure.Data.Interface;

namespace Prestadito.Investment.Infrastructure.Data.Settings
{
    public class InvestmentDBSettings : IInvestmentDBSettings
    {
        public string ConnectionURI { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
    }
}
