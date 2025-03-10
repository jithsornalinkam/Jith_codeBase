namespace ApplicationTracker.Contract
{
    public interface IRepositoryManager
    {
        IApplicationTrackeRepository TrackeRepository { get; }
        void Save();
    }
}
