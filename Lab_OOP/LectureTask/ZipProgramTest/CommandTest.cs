using LectureTask.Services;
using LectureTask.Services.Commands;
using LectureTask.Services.Interfaces;
using LectureTask.Services.Strategies;
using Microsoft.Extensions.DependencyInjection;

namespace ZipProgramTest;

public class CommandTest
{
    private readonly ServiceProvider _serviceProvider;

    public CommandTest()
    {
        _serviceProvider = new ServiceCollection()
            .AddTransient<LowCompressionStrategy>()
            .BuildServiceProvider();
    }
    [Fact]
    public void ZipFileCommandShouldCreateZipFile()
    {
        string sourceFilePath = "C:\\test\\test.txt";
        string zipFilePath = "C:\\test\\testDestination.zip";

        File.WriteAllText(sourceFilePath, "This is a test file.");

        var strategy = _serviceProvider.GetService<LowCompressionStrategy>();
        var command = new ZipFileCompressionCommand();
        command.SetProperties(sourceFilePath,zipFilePath,strategy);

        // Act
        command.Execute();

        // Assert
        Assert.True(File.Exists(zipFilePath), "The zip file was created successfully.");
        if (File.Exists(sourceFilePath))
            File.Delete(sourceFilePath);
        if (File.Exists(zipFilePath))
            File.Delete(zipFilePath);
    }

    [Fact]
    public void ZipFileNotShouldCreateBecauseFileNotExist()
    {
        //Arrange
        string sourceFilePath = "C:\\test\\test22.txt";
        string zipFilePath = "C:\\test\\testNotFileDestination.zip";

        var strategy = _serviceProvider.GetService<LowCompressionStrategy>();
        var command = new ZipFileCompressionCommand();
        command.SetProperties(sourceFilePath,zipFilePath,strategy);
        // Act 
        var exception = Assert.Throws<FileNotFoundException>(() => command.Execute());
        
        // Assert
        Assert.Contains("does not exist", exception.Message);
        if (File.Exists(zipFilePath))
            File.Delete(zipFilePath);
    }
}