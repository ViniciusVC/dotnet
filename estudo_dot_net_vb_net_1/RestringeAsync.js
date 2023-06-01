// JScript File

Sys.Application.add_load(ApplicationLoadHandler)

function ApplicationLoadHandler(sender, args)
{

var esync = Sys.WebForms.PageRequestManager.getInstance().get_isInAsyncPostBack();

    if (!esync)
    {
      Sys.WebForms.PageRequestManager.getInstance().add_initializeRequest(InitializeRequest);
    }
}

var divElem = 'AlertDiv';
var messageElem = 'AlertMessage';
var exclusivePostBackElement = 'btnPesqAsync';
var lastPostBackElement;

function InitializeRequest(sender, args)
{ 
    var prm = Sys.WebForms.PageRequestManager.getInstance();
    
    if (prm.get_isInAsyncPostBack()) 
    {
          args.set_cancel(true);
          ActivateAlertDiv('visible', 'Solicitação em andamento... Aguarde. ');
          setTimeout("ActivateAlertDiv('hidden','')", 2000);
    }
}

function ActivateAlertDiv(visString, msg)
{
     var adiv = $get(divElem);
     var aspan = $get(messageElem);
     adiv.style.visibility = visString;
     aspan.innerHTML = msg;
}
if(typeof(Sys) !== "undefined") Sys.Application.notifyScriptLoaded();