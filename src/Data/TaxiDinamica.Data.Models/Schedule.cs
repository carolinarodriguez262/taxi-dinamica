namespace TaxiDinamica.Data.Models
{
    using TaxiDinamica.Data.Common.Models;

    public class Schedule : BaseDeletableModel<int>
    {
        public string Day { get; set; }

        public string PartnerId { get; set; }

        public virtual Partner Partner { get; set; }
    }
}
