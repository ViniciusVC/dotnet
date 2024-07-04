using OpenQA.Selenium.DevTools.V125.Page;
using VVCBotPessoal;

Console.WriteLine("Bot iniciado...");
var web = new AutomacaoWeb();

// abrir busca e click para o V-Editor.
web.ClickVEditor();

// Capturar ações.
web.CarteiraAcoes(); 
