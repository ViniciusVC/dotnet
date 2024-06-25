namespace Console24062024{

    // abstração contrato interface. Regra para implementação 
    interface ILogger
    {
        void Log(string message);
    }

	// Implementação da Classe que mostra o Log em tela.
    class ConsoleLogger : ILogger
    {
            public void Log(string message) {
                Console.WriteLine($"LOGGER: {message}");
            }
    }

    /*
    // Implementação da classe, salva o Log em arquivo.
    class FileLogger : ILogger
    {
            public void Log(string message) {
                file.AppendAllText("log.txt", message);
            }
    }
    */
}