namespace Lab_10
{
    public class SampleNotificationHandler : INotificationHandler<SampleNotification>
    {
        public Task Handle(SampleNotification notification)
        {
            Console.WriteLine($"Notification received: {notification.NotificationMessage}");
            return Task.CompletedTask;
        }
    }
}

