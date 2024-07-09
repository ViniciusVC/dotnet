using Apicrud.Data; // incluindo o namespace Data do Context
using Apicrud.Estudante; // incluindo o namespace Data do Model

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<AppDbContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

// Rotas: 
app.AddRotasEstudantes(); // EstudantesRotas.AddRotasEstudantes(app);


app.Run();

