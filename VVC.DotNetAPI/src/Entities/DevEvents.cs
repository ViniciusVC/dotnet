
namespace csharp_api.Entities
{
    // Entidade Evento
    public class DevEvent
    {

        //Construitor da classe (sem parametros)  
        public DevEvent()
        {
            Speakers=new List<DevEventSpeaker>();
            IsDeleted=false;
        }

        // Propriedades da entidade DevEvent
        public Guid Id {get; set;}
        public string Title {get; set;}
        public string Description {get; set;}
        public string StartDate {get; set;}
        public string EndData {get; set;}
        public List<DevEventSpeaker> Speakers {get; set;}
        public bool IsDeleted {get; set;}

        // Metodo Update da entidade DevEvent
        public void Update(string title, string description, DateTime startDate, DateTime endDate) 
        {

            Title = title;
            Description = description;
            StartDate = startDate;
            EndData = endDate;

        }

        // Metodo de apagar
        public void Delete()
        {
            IsDeleted = true;
        }

    }
}