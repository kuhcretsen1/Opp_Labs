using System.IO;
using System.IO.Compression;
using LectureTask.Services.Interfaces;

namespace LectureTask.Services.Commands
{
    public class ZipFolderCompressionCommand : ICommand
    {
        private string _sourceFilePath;
        private string _zipFilePath;
        private ICompressionStrategy _strategy;

        public void Execute()
        {
            if (_strategy == null)
                throw new InvalidOperationException("Compression strategy not set.");
            if (_sourceFilePath == null)
                throw new InvalidOperationException("Source path not set.");
            if (_zipFilePath == null)
                throw new InvalidOperationException("Destination path not set.");

            if (!Directory.Exists(_sourceFilePath))
                throw new DirectoryNotFoundException($"The directory '{_sourceFilePath}' does not exist.");
            
            Compress(_sourceFilePath, _zipFilePath, _strategy.GetCompressionLevel());
        }
        
        public void Compress(string sourceFilePath, string targetFilePath, CompressionLevel compressionLevel)
        {
            using (var archive = ZipFile.Open(targetFilePath, ZipArchiveMode.Create))
            {
                archive.CreateEntryFromFile(sourceFilePath, Path.GetFileName(sourceFilePath), compressionLevel);
            }
        }
        
        public void SetProperties(string sourceFilePath, string zipFilePath, ICompressionStrategy strategy)
        {
            _sourceFilePath = sourceFilePath;
            _zipFilePath = zipFilePath;
            _strategy = strategy;
        }
    }
}