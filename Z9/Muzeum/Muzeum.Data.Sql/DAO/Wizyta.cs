using System;

namespace Muzeum.Data.Sql.DAO
{
    public class Wizyta
    {
        public int WizytaId { get; set; }
        public int OdwiedzajacyId { get; set; }
        public DateTime DataOdwiedzin { get; set; }
        public int EksponatId { get; set; }

        public virtual Gosc Gosc { get; set; }
        public virtual Eksponat Eksponat { get; set; }

    }
}