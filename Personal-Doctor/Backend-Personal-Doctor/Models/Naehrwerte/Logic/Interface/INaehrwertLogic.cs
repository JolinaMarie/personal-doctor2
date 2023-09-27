
using Backend_Personal_Doctor.Models.Naehrwerte.DTOs;

namespace Backend_Personal_Doctor.Models.Naehrwerte.Logic.Interface
{
    public interface INaehrwertLogic
    {
        List<Naehrwert> GetAllNaehrwerte();
        Naehrwert GetNaehrwert(int id);
    }
}
