namespace ListenerInterface
{
    public interface IListener
    {
        void Write(string message, int logLevel);
    }
}