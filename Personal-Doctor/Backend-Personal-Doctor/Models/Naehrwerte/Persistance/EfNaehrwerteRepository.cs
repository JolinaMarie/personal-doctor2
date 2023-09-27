using Backend_Personal_Doctor.Models.Naehrwerte.DTOs;
using Backend_Personal_Doctor.Models.Naehrwerte.Persistance.Interface;
using Backend_Personal_Doctor.Models.Users.DTOs;
using Backend_Personal_Doctor.Models.Users.Persistance.Interface;

namespace Backend_Personal_Doctor.Models.Naehrwerte.Persistance
{
    public class EfNaehrwerteRepository : INaehrwerteRepository
    {
        private readonly PersonalDoctorContext _context;

        public EfNaehrwerteRepository(PersonalDoctorContext context)
        {
            this._context = context;
        }

        public Naehrwert GetNaehrwert(int id)
        {
            EfNaehrwert efNaehrwert = _context.Naehrwerte
                .Single(efNaehrwert => efNaehrwert.NahrungId == id);

            return Naehrwert.FromEfNaehrwert(efNaehrwert);
        }

        public List<Naehrwert> GetAllNaehrwerte()
        {
            List<Naehrwert> efNaehrwert = _context.Naehrwerte
               .Select(efNaehrwert => Naehrwert.FromEfNaehrwert(efNaehrwert))
               .ToList();

            return efNaehrwert;
        }


    }
}
