using System.IO.Compression;
using LectureTask.Services.Interfaces;

namespace LectureTask.Services.Strategies
{
    public class LowCompressionStrategy : ICompressionStrategy
    {
        public CompressionLevel GetCompressionLevel()
        {
            return CompressionLevel.NoCompression;
        }
    }
} 