//using Microsoft.Extensions.Logging;
//using System.ComponentModel.DataAnnotations;
//using System.Reflection.PortableExecutable;

namespace VVCDotNetWorkerAwait;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private string[] _originalList;
    private string[] _reprocessedList;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
        _originalList = [" teste 1 ", " teste 2 ", " teste 3 ", " teste 4 ", " teste 4 "];
        _reprocessedList = ["", "", "", "", ""];
    }


    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {

        var indexList = 0;

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                indexList++;
                _reprocessedList[indexList] = _originalList[indexList].Replace(' ', '_') + DateTimeOffset.Now.ToString();
                _logger.LogInformation(" Reprocesse : {valor}", _reprocessedList[indexList]);
            }
            catch (Exception ex)
            {
                indexList = 0;
                _logger.LogWarning(ex.Message);
                _logger.LogError("Item não existe na lista.");
                await Task.Delay(1000, stoppingToken);
            }
        }
    }

}
