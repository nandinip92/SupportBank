using Microsoft.Extensions.Logging;

namespace SupportBank.SupportBankManagement;

public class SupportBankApp{

    private readonly ILogger<SupportBankApp> _logger;
    public SupportBankApp(ILogger<SupportBankApp> logger){
        _logger = logger;
    }
    public void StartService(){
        _logger.LogInformation("Bank App starting...");
        var ui = new UserInterface(_logger);
        ui.RunUI();
    }

}