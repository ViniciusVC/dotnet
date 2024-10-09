using VVCDotNetWorker;

var builder = Host.CreateApplicationBuilder(args);

/*
builder.Services.AddDominio(); // Adiciona os servi�os do dom�nio ao cont�iner de inje��o de depend�ncia
builder.Services.AddInfraestruturaOracle(); // Configura a infraestrutura para usar o Oracle como banco de dados
builder.Services.AddInfraestruturaHttp(); // Configura a infraestrutura para usar servi�os HTTP
builder.Services.AddBrokerProvider(); // Adiciona o provedor de broker ao cont�iner de inje��o de depend�ncia
builder.Services.AddLoggingEnergisa(); // Configura o logging espec�fico da Energisa
*/

builder.Services.AddHostedService<Worker>();

var host = builder.Build();

host.Run();
