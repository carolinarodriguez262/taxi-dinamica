namespace TaxiDinamica.Web.ViewModels.Schedules
{
    using TaxiDinamica.Data.Models;
    using TaxiDinamica.Services.Mapping;

    public class ScheduleViewModel : IMapFrom<Schedule>
    {
        public int Id { get; set; }

        public string Day { get; set; }

        public string PartnerId { get; set; }
    }
}
