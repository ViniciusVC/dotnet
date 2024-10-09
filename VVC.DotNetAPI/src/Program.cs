var builder = WebApplication.CreateBuilder(args);

// Adicione serviços ao container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // Abrir Swagger caso ambinte de desenvolvimento.
    app.UseSwagger(); 
    app.UseSwaggerUI(); // Swagger Interface de usurio.
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); // mapiar controllers. 

Console.WriteLine("Acesse http://localhost:5297/swagger/ para testar aplicação.");

app.Run();
