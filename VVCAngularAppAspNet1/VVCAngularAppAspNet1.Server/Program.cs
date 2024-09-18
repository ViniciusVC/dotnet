var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Rodando Swagger pra testar a API.

var app = builder.Build();

app.UseDefaultFiles(); // Redireciona automaticamente as solicitações de diretórios para arquivos padrão como index.html.
app.UseStaticFiles(); // Configura o middleware para servir arquivos estáticos, como arquivos CSS, JavaScript e imagens, a partir do diretório wwwroot por padrão.

// Swagger so abre em dev.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
