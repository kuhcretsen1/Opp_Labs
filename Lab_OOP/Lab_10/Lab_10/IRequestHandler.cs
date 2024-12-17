namespace Lab_10
{
    public interface IRequestHandler<in TRequest, TResponse>
     where TRequest : IRequest<TResponse>
    {
        Task<TResponse> Handle(TRequest request);
    }
}
