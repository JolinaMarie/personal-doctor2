using Backend_Personal_Doctor.Models.Sessions.DTOs;

namespace Backend_Personal_Doctor.Models.Naehrwerte.DTOs
{
    public class Naehrwert
    {
        public int NahrungID { get; set; }
        public string Essen { get; set; }
        public decimal? Brennwert { get; set; }
        public decimal? Proteingehalt { get; set; }
        public decimal? Kohlenhydrate { get; set; }
        public decimal? Zucker { get; set; }
        public decimal? Fett { get; set; }

        internal static Naehrwert FromEfNaehrwert(EfNaehrwert efNaehrwert)
        {
            if (efNaehrwert == null)
            {
                return null;
            }

            return new Naehrwert()
            {
                NahrungID = efNaehrwert.NahrungId,
                Essen = efNaehrwert.Essen,
                Brennwert = efNaehrwert.Brennwert,
                Proteingehalt = efNaehrwert.Proteingehalt,
                Kohlenhydrate = efNaehrwert.Kohlenhydrate,
                Zucker = efNaehrwert.Zucker,
                Fett = efNaehrwert.Fett,
            };
        }
    }
}
