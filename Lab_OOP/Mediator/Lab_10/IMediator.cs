namespace Lab_10
{
    public interface IMediator 
    {
        Task<TResponse> Send<TResponse>(IRequest<TResponse> request);
        Task Publish<TNotification>(TNotification notification);
    }
}
