using Microsoft.Extensions.DependencyInjection;

namespace Lab_10
{
    public class Mediator : IMediator
    {
        private readonly IServiceProvider _serviceProvider;

        public Mediator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
        {
            Type requestType = request.GetType();
            Type requestHandlerType = typeof(IRequestHandler<,>).MakeGenericType(requestType, typeof(TResponse));


            var handler = _serviceProvider.GetService(requestHandlerType);

            if (handler == null)
                throw new InvalidOperationException($"Handler for '{requestType.Name}' not found.");

            var handleMethod = handler.GetType().GetMethod("Handle");
            var responseTask = (Task<TResponse>)handleMethod.Invoke(handler, new object[] { request });//для чого викликається Invoke

            return await responseTask;
        }


        public async Task Publish<TNotification>(TNotification notification)
        {
            var handlerType = typeof(INotificationHandler<>).MakeGenericType(typeof(TNotification));
            var handlers = _serviceProvider.GetServices(handlerType);

            foreach (var handler in handlers)
            {
                await ((INotificationHandler<TNotification>)handler).Handle(notification);
            }
        }
    }
}