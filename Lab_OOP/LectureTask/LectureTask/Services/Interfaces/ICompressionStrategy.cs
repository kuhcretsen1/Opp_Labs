using System.IO.Compression;

namespace LectureTask.Services.Interfaces;

public interface ICompressionStrategy
{
     CompressionLevel GetCompressionLevel();
}