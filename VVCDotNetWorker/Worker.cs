namespace VVCDotNetWorker;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger; // Log do dot net.
    private int _incremento; // Variavel simples.


    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
        _incremento = 0;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _incremento++;
                _logger.LogInformation("Worker rodadndo em: {time}", DateTimeOffset.Now);
                _logger.LogInformation("Incremento: {valor}", _incremento.ToString());  
            }
            await Task.Delay(1000, stoppingToken);
        }
    }
}
