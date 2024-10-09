using VVCDotNetWorker;

var builder = Host.CreateApplicationBuilder(args);

/*
builder.Services.AddDominio(); // Adiciona os serviços do domínio ao contêiner de injeção de dependência
builder.Services.AddInfraestruturaOracle(); // Configura a infraestrutura para usar o Oracle como banco de dados
builder.Services.AddInfraestruturaHttp(); // Configura a infraestrutura para usar serviços HTTP
builder.Services.AddBrokerProvider(); // Adiciona o provedor de broker ao contêiner de injeção de dependência
builder.Services.AddLoggingEnergisa(); // Configura o logging específico da Energisa
*/

builder.Services.AddHostedService<Worker>();

var host = builder.Build();

host.Run();
