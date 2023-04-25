using System;


namespace Muzeum.Data.Sql.DAO
{
    public class Serwis
    {
        public int SerwisId { get; set; }
        public string NazwaEksponatu { get; set; }
        public int EksponatId { get; set; }
        public int MagazynId { get; set; }
        public int PracownikId { get; set; }
        public DateTime DataOtrzymania { get; set; }
        public DateTime DataZwrotu { get; set; }

        public virtual Pracownik Pracownik { get; set; }
        public virtual Eksponat Eksponat { get; set; }

    }
}