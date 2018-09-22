namespace SecondApp.Interfaces
{
    public interface IRabbitSender
    {
        void SendMessage(string message);
    }
}
