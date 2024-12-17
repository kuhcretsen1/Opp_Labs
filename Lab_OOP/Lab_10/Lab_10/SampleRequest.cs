using Lab_10;

namespace Lab_10
{
    public class SampleRequest : IRequest<SampleResponse>
    {
        public string Message { get; set; }
    }
}

