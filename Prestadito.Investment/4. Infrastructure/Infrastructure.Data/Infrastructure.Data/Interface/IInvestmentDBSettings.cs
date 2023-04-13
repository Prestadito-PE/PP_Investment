namespace Prestadito.Investment.Infrastructure.Data.Interface
{
    public interface IInvestmentDBSettings
    {
        string ConnectionURI { get; set; }
        string DatabaseName { get; set; }
    }
}
