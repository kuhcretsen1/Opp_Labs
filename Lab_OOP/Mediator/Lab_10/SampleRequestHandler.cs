using Lab_10;
namespace Lab_10
{
    public class SampleRequestHandler : IRequestHandler<SampleRequest, SampleResponse>
    {
        public Task<SampleResponse> Handle(SampleRequest request)
        {
            return Task.FromResult(new SampleResponse { ResponseMessage = $"Handled: {request.Message}" });
        }
    }
}