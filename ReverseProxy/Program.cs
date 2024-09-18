var builder = WebApplication.CreateBuilder(args);

// Configurando o proxy no program.cs. 
// Adiciona o serviço de proxy reverso
builder.Services.AddReverseProxy()
                .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();
// app.MapGet("/", () => "Hello World!");

// Configura o pipeline de requisições HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Mapeia o proxy reverso
app.MapReverseProxy();

app.Run();
