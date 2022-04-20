namespace ListenerInterface
{
    public interface IListener
    {
        void Write(string message);
        void Log(string message);
    }
}