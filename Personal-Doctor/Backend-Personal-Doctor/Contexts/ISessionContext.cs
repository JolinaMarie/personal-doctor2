namespace Backend_Personal_Doctor.Contexts
{
    public interface ISessionContext
    {
        int GetUserId();
        void Validate();
    }
}
