using System.IO.Compression;
using LectureTask.Services.Interfaces;

namespace LectureTask.Services.Strategies
{
    public class HighCompressionStrategy : ICompressionStrategy
    {
        public CompressionLevel GetCompressionLevel()
        {
            return CompressionLevel.Fastest;
        }
    }
}