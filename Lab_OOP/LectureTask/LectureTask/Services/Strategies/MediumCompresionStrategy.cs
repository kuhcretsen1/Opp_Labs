using System.IO.Compression;
using LectureTask.Services.Interfaces;

namespace LectureTask.Services.Strategies
{
    public class MediumCompressionStrategy : ICompressionStrategy
    {
        public CompressionLevel GetCompressionLevel()
        {
            return CompressionLevel.Optimal;
        }
    }
}