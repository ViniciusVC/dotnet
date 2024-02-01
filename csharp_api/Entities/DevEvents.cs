
namespace csharp_api.Entities;
{
    public class DevEvent
    {

        //Construitor da classe
        public DevEvent()
        {
            Speakers=new List<DevEventSpeaker>();
            IsDeleted=false;
        }

        public Guid Id {get; set;}
        public string Title {get; set;}
        public string Description {get; set;}
        public string StartDate {get; set;}
        public string EndData {get; set;}
        public List<DevEventSpeaker> Speakers {get; set;}
        public bool IsDeleted {get; set;}

        //Metodo de atualisação 
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