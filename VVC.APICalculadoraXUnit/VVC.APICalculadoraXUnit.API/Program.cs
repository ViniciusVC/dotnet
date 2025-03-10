var builder = WebApplication.CreateBuilder(args);


Console.WriteLine("Iniciando aplicação APICalculadoraXUnit");

builder.Services.AddControllers(); // Adicionado Controlles(endpoints).

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure pipeline de desenvolvimento.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();  // Adicionado
app.MapControllers();  // Adicionado

Console.WriteLine("Abra uma pagina em com Swagger em: http://localhost:5003/swagger/index.html");

app.Run();

Console.WriteLine("API encerrada.");
