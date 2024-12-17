using Lab_10;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace Mediator_test
{
    public class UnitTest1
    {

        [Fact]
        public async Task Mediator_SendRequest_ReturnsExpectedResponse()
        {
            
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var mediator = serviceProvider.GetService<IMediator>();

            var request = new SampleRequest { Message = "Test message" };

            
            var response = await mediator.Send(request);

            
            Assert.Equal("Handled: Test message", response.ResponseMessage);
        }


        [Fact]
        public async Task Mediator_PublishNotification_CallsNotificationHandler()
        {
            
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            var mockNotificationHandler = Substitute.For<INotificationHandler<SampleNotification>>();
            serviceCollection.AddSingleton(mockNotificationHandler);

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var mediator = serviceProvider.GetService<IMediator>();

            var notification = new SampleNotification { NotificationMessage = "Test notification" };

            
            await mediator.Publish(notification);

            
            await mockNotificationHandler.Received(1).Handle(notification);
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IMediator, Mediator>();
            services.AddTransient<IRequestHandler<SampleRequest, SampleResponse>, SampleRequestHandler>();
            services.AddTransient<INotificationHandler<SampleNotification>, SampleNotificationHandler>();
        }
    }
}