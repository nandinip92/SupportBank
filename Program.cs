using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using SupportBank.SupportBankManagement;

var serviceProvider = new ServiceCollection()
    .AddTransient<SupportBankApp>()
    .AddLogging(loggingBuilder =>
    {
        loggingBuilder.ClearProviders();
        loggingBuilder.AddNLog();
    })
    .BuildServiceProvider();

var supportBankApp = serviceProvider.GetRequiredService<SupportBankApp>();
supportBankApp.StartService();