using Backend_Personal_Doctor.Middleware.ResultExceptionMiddleware;
using Backend_Personal_Doctor.Models.Naehrwerte.DTOs;
using Backend_Personal_Doctor.Models.Naehrwerte.Logic.Interface;
using Backend_Personal_Doctor.Models.Naehrwerte.Persistance.Interface;
using Backend_Personal_Doctor.Models.Users.DTOs;

namespace Backend_Personal_Doctor.Models.Naehrwerte.Logic
{
    public class NaehrwertLogic : INaehrwertLogic
    {
        private readonly INaehrwerteRepository _naehrwerteRepository;

        public NaehrwertLogic(INaehrwerteRepository naehrwerteRepository)
        {
            this._naehrwerteRepository = naehrwerteRepository;
        }

        public List<Naehrwert> GetAllNaehrwerte()
        {
            List<Naehrwert> naehrwert = this._naehrwerteRepository.GetAllNaehrwerte();
            if (naehrwert == null)
            {
                throw new NotFoundResultException($"Nährwerte konnten nicht gefunden werden.");
            }

            return naehrwert;
        }

        public Naehrwert GetNaehrwert(int id)
        {
            Naehrwert naehrwert = this._naehrwerteRepository.GetNaehrwert(id);
            if (naehrwert == null)
            {
                throw new NotFoundResultException($"Naehrwert mit der Id {id} nicht gefunden.");
            }

            return naehrwert;
        }
    }
}
