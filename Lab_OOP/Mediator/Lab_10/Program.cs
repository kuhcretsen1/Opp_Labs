using Lab_10;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();

        ConfigureServices(serviceCollection);

        var serviceProvider = serviceCollection.BuildServiceProvider(validateScopes: true);

        var mediator = serviceProvider.GetService<IMediator>();

        // Обробка запиту
        var request = new SampleRequest { Message = "Hello, Mediator!" };
        var response = mediator.Send(request).Result;
        Console.WriteLine(response.ResponseMessage);

        var notification = new SampleNotification { NotificationMessage = "Hello, Notification!" };
        mediator.Publish(notification).Wait();

        Console.ReadLine();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IMediator, Mediator>();
        services.AddTransient<IRequestHandler<SampleRequest, SampleResponse>, SampleRequestHandler>();
        services.AddTransient<INotificationHandler<SampleNotification>, SampleNotificationHandler>();
    }
}
