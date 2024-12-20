using System.IO.Compression;
using LectureTask.Services;
using LectureTask.Services.Interfaces;
using LectureTask.Services.Strategies;
using Microsoft.Extensions.DependencyInjection;

namespace ZipProgramTest;

public class StrategyTest
{
    private readonly ServiceProvider _serviceProvider;

    public StrategyTest()
    {
        _serviceProvider = new ServiceCollection()
            .AddTransient<LowCompressionStrategy>()
            .AddTransient<MediumCompressionStrategy>()
            .BuildServiceProvider();
    }
    
    [Fact]
    public void StrategyCompressShouldReturnCompressionLevelOptimal()
    {
        // Arrange
        var compressor = _serviceProvider.GetService<MediumCompressionStrategy>();

        // Act
        compressor.GetCompressionLevel();

        // Assert
        Assert.Equal(CompressionLevel.Optimal, compressor.GetCompressionLevel());
    }

    [Fact]
    public void StrategyCompressShouldReturnCompressionLevelNoCompression()
    {
        // Arrange
        var compressor = _serviceProvider.GetService<LowCompressionStrategy>();

        // Act
        compressor.GetCompressionLevel();

        // Assert
        Assert.Equal(CompressionLevel.NoCompression, compressor.GetCompressionLevel());
    }
}