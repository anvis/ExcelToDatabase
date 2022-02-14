using Microsoft.Extensions.DependencyInjection;
using Services;

namespace ScreenerAPI
{
  public static class ServiceDependencies
  {
    public static void AddServiceDependencies(this IServiceCollection serviceCollection)
    {
      serviceCollection.AddTransient<IMutualFundHoldingsService, MutualFundHoldingsService>();
      serviceCollection.AddTransient<IStockFundamentalsService, StockFundamentalsService>();
      serviceCollection.AddTransient<IWatchListService, WatchListService>();
      serviceCollection.AddTransient<ITransactionService, TransactionService>();
      serviceCollection.AddTransient<IStockService, StockService>();
    }
  }
}
