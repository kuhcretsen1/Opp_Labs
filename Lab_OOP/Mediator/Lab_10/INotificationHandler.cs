namespace Lab_10
{
    public interface INotificationHandler<in TNotification>
    {
        Task Handle(TNotification notification);
    }
}
