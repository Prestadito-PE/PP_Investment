namespace Prestadito.Investment.API.Endpoints
{
    public static class EndPoints
    {
        readonly static string basePath = "/api";
        public static WebApplication UseInvestmentEndpoints(this WebApplication app)
        {
            app.UseFinancingEndpoints(basePath);

            return app;
        }
    }
}
