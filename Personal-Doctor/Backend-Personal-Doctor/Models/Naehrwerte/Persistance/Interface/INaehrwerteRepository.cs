using Backend_Personal_Doctor.Models.Naehrwerte.DTOs;

namespace Backend_Personal_Doctor.Models.Naehrwerte.Persistance.Interface
{
    public interface INaehrwerteRepository
    {
        public Naehrwert GetNaehrwert(int id);
        public List<Naehrwert> GetAllNaehrwerte();
    }
}
